<?php

if((isset($_SESSION['userId'])) && ($_POST['requestManage'] == 'historicRequests')){
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./requestModellerHistor.php');

    $userArea = $_SESSION['userArea'];
    $limit = $_POST['limit'];
    $offset = $_POST['offset'];
    $screenLimits = [10, 25, 50, 100];
    $rightToManageRequests = $_SESSION['userRights'][9];
    
    $getFullRowNumberOfHistoric = new getHistoricFullNumber();
    $getFullRowNumberOfHistoric ->setConnectionDatas($conn);
    $fullRowOfHistorRecords = $getFullRowNumberOfHistoric->executeQueryGetTheNumberOfHistoricRequests($userArea);
    if ($fullRowOfHistorRecords != false) {
        $pageFullNumbers = ceil((int)$fullRowOfHistorRecords/(int)$limit);
        
        $selecter = "<div id='selecter'>";
        for($i = 1; $i < $pageFullNumbers + 1; $i++){
            $selecterNextValue = (int)$limit * ($i -1);
            if ($offset == $selecterNextValue){
                $selecter .= "<a id='actualHistoricOffset' value='{$selecterNextValue}'><strong>{$i}</strong></a>";
            }else{
                $selecter .= "<a class='selectedHistoricPageOffset btn' value='{$selecterNextValue}'>{$i}</a>";
            }
        }
        $selecter .= "</div>";
    }else{
        $selecter = "<div id='selecter'><p>Nincs megjeleníthető elem!</p></div>";
    }    
        
    $screener = "<div id='screener' class='row'>";
    $screener .= "<div class='col-md-4'><p>Megjelenítés: </p>"
            . "<select id='requestHistoricScreenLimit'>";
    for ($i = 0; $i < count($screenLimits); $i++) {
        $screener .= "<option value='{$screenLimits[$i]}' ";
        if ($screenLimits[$i] == $limit) {
            $screener .= "selected";
        }
        $screener .= " >$screenLimits[$i]</option>";
    }
    $screener .= "</select>";
    $screener .= "<button id='requestHistoricScreen' class='btn btn-primary'>Szűrés</button></div>";
        $screener .= "<div class='col-md-5'><p>Nézetváltás: </p><button id='requestShowCancelled'"
            . " class='btn btn-success'>Lemondott kérések</button></div>";
    $screener .= "</div>";
        
    $table = "<table class='table table-striped table-sm table-hover'>";
    $table .= "<tr class='table-success'><th colspan='7'>Átvett kérések listája</th></tr>";
    $table .= "<tr class='table-success'>"
        . "<th>Terméknév</th>"
        . "<th>Kiszerelés</th>"
        . "<th>Menny. egység</th>"
        . "<th>Beszállító</th>"
        . "<th>Darab</th>"
        . "<th>Kérés ideje</th>"
        . "<th>Keres teljesült</th>";
    $table .= "</tr>";
    
    $getTheHistoricRrequests = new getHistoricRequestsOfUserPlace();
    $getTheHistoricRrequests -> setConnectionDatas($conn, $limit, $offset);
    $cancelledRequestDatas = $getTheHistoricRrequests ->executeQueryGetHistoricRequests($userArea);
    
    if ($cancelledRequestDatas != false){ 
        while($strippingRow = $cancelledRequestDatas -> fetch_assoc() ){
            $table .= "<tr>";
            $table .= "<td  class='historicRequestDetails btn' value='{$strippingRow['keres_id']}'>"
                . "{$strippingRow['termek_nev']}</td>";
            $table .= "<td>{$strippingRow['termek_kiszerel']}</td>";
            $table .= "<td>{$strippingRow['termek_egyseg']}</td>";
            $table .= "<td>{$strippingRow['beszallito_id']}</td>";
            $table .= "<td>{$strippingRow['keres_mennyiseg']}</td>";
            $table .= "<td>{$strippingRow['keres_datum']}</td>";
            $table .= "<td>{$strippingRow['keres_teljesit']}</td>";
            $table .= "</tr>";
        }
        

    }else{
        $table .= "<tr>Adatlekérdezési hiba!</tr>";
    }
    $table .= "</table>";
    
    echo $screener.$table.$selecter;
}

