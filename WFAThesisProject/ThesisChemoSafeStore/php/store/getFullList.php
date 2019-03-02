<?php

if ((isset($_SESSION['userId'])) && ($_POST['storeManage'] == 'normal')) {
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./storeModeller.php');

    $limit = $_POST['limit'];
    $offset = $_POST['offset'];
    if ($_POST['keyword'] != null) {
        $keyWord = $_POST['keyword'];
    } else {
        $keyWord = "";
    }
    $rightToManageRequests = $_SESSION['userRights'][9];

    $screenLimiSteps = [10, 25, 50, 100];

    $fullRowGetter = new getTheRecordnumber();
    $fullRowGetter->setConnectDetails($conn);
    $fullRowNumber = $fullRowGetter->executeQueryRecordAmountWhithScreen($keyWord);

    if ($fullRowNumber != false) {
        $amountOfPartNumber = ceil((int) $fullRowNumber / (int) $limit);

        $selecter = "<div id='selecter'><p>";
        for ($i = 1; $i < $amountOfPartNumber + 1; $i++) {
            $selecterNextValue = (int) $limit * ($i - 1);
            if ((int) $offset == $selecterNextValue) {
                $selecter .= "<a id='actualOffset' value='{$selecterNextValue}'><strong>{$i}</strong></a>";
            } else {
                $selecter .= "<a class='selectedStorePageOffset btn' value='{$selecterNextValue}'>{$i}</a>";
            }
        }
        $selecter .= "</p><div>";
    } else {
        $selecter = "<p>Nincs megjeleníthető elem!</p>";
    }


    $screener = "<div id='screener' class='row '><div class='col-md-4'><p>Megjelenítés: </p>"
            . "<select id='storeScreenLimit'>";
    for ($i = 0; $i < count($screenLimiSteps); $i++) {
        $screener .= "<option value='{$screenLimiSteps[$i]}'";
        if ($screenLimiSteps[$i] == (int) $limit) {
            $screener .= " selected ";
        }
        $screener .= ">{$screenLimiSteps[$i]}</option>";
    }
    $screener .= "</select></div>";

    $screener .= "<div class='col-md-6'><p>Keresett terméknév: </p>"
            . "<input type='text' name='screenword' value=";
    if ($keyWord != "%") {
        $screener .= "'{$keyWord}'>";
    } else {
        $screener .= "''>";
    }
    $screener .= "<button id='storeScreen' class='btn btn-primary'>Szűrés</button></div></div>";

    $table = "<table class='table table-striped table-sm table-hover'>";
    $table .= "<tr class='table-success'>"
            . "<th>Terméknév</th>"
            . "<th>Kiszerelés</th>"
            . "<th>Menny. egység</th>"
            . "<th>Beszállító</th>"
            . "<th></th>";
    $table .= "</tr>";
    $records = new getTheStrippingTable();
    $records->setConnectDetails($conn, $limit, $offset);
    $resultQuery = $records->executeQueryGetScreenedProducts($keyWord);
    //skull with bones      &#9760
    
    if ($resultQuery != null) {
        while ($rows = $resultQuery->fetch_assoc()) {
            $table .= "<tr>";
            $table .= "<td class='detailsSurface btn' value='{$rows['termek_quant_id']}'>"
                    . "{$rows['termek_nev']}</td>";
            $table .= "<td>{$rows['termek_kiszerel']}</td>";
            $table .= "<td>{$rows['termek_egyseg']}</td>";
            $table .= "<td>{$rows['beszallito_id']}</td>";
            $table .= "<td id='datasheetFromList' value='{$rows['termek_biztons']}'"
                    . " class='btn sheet'><img src='./style/sheets.png'</td>";
            if ($rightToManageRequests == '2') {
                $table .= "<td id='storeStartRequestingFromListPage' value='{$rows['termek_quant_id']}'"
                        . "class='btn'><img src='./style/cart2.png'></td>";
            }
            $table .= "</tr>";
        }
    } else {
        $table .= "<tr>Adatlekérési hiba</tr>";
    }
    $table .= "</table>";

    echo $screener . $table . $selecter;
}






