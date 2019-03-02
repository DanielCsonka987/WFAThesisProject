<?php

if((isset($_SESSION['userId'])) && ($_POST['requestManage'] == 'cancelledRequests')){
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./requestModellerCancelled.php');
    $userArea = $_SESSION['userArea'];
    $limit = $_POST['limit'];
    $offset = $_POST['offset'];
    
    $screenLimits = [10, 25, 50, 100];
    $rightToManageRequests = $_SESSION['userRights'][9];
    
    $getTheCancelledRequestsAmount = new getCancelledRequestRecordNumber();
    $getTheCancelledRequestsAmount -> setConnectionDatas($conn);
    $fullRowsNumber = $getTheCancelledRequestsAmount ->executeQueryGetCancelledRequests($userArea);
    
    if ($fullRowsNumber != false) {
        $pageFullNumbers = ceil((int)$fullRowsNumber/(int)$limit);
        
        $selecter = "<div id='selecter'>";
        for($i = 1; $i < $pageFullNumbers + 1; $i++){
            $selecterNextValue = (int)$limit * ($i -1);
            if ($offset == $selecterNextValue){
                $selecter .= "<a id='actualCancelledOffset' value='{$selecterNextValue}'>"
                . "<strong>{$i}</strong></a>";
            }else{
                $selecter .= "<a class='selectedCancelledPageOffset btn' value='{$selecterNextValue}'>{$i}</a>";
            }
        }
    }else{
        $selecter = "<div id='selecter'><p>Nincs megjeleníthető elem!</p></div>";
    }    
        
    $screener = "<div id='screener' class='row'>";
    $screener .= "<div class='col-md-4'><p>Megjelenítés: </p>"
            . "<select id='requestCancelledScreenLimit'>";
    for ($i = 0; $i < count($screenLimits); $i++) {
        $screener .= "<option value='{$screenLimits[$i]}' ";
        if ($screenLimits[$i] == $limit) {
            $screener .= "selected";
        }
        $screener .= " >$screenLimits[$i]</option>";
    }
    $screener .= "</select>";
    $screener .= "<button id='requestCancelledScreen' class='btn btn-primary'>Szűrés</button></div>";
        $screener .= "<div class='col-md-5'><p>Nézetváltás: </p><button id='requestShowNormal'"
            . " class='btn btn-success'>Jelenlegi kérések</button></div>";
    $screener .= "</div>";
        
    $table = "<table class='table table-striped table-sm table-hover'>";
    $table .= "<tr class='table-success'><th colspan='8'>Lemondott kérések listája</th></tr>";
    $table .= "<tr class='table-success'>"
        . "<th>Terméknév</th>"
        . "<th>Kiszerelés</th>"
        . "<th>Menny. egység</th>"
        . "<th>Beszállító</th>"
        . "<th>Darab</th>"
        . "<th>Lemondta</th>"
        . "<th>Kérés ideje</th>";
    if($rightToManageRequests == '2'){
        $table .= "<th></th>";
    }
    $table .= "</tr>";
    
    $getCancelledRecords = new getCancelledRequestsOfUserPlace();
    $getCancelledRecords ->setConnectionDatas($conn, $limit, $offset);
    $cancelledRequestDatas = $getCancelledRecords->executeQueryGetCancelledRequests($userArea);
    if ($cancelledRequestDatas != false){ 
        while($strippingRow = $cancelledRequestDatas -> fetch_assoc() ){
            $table .= "<tr>";
            $table .= "<td   class='cancelledRequestDetails btn' value='{$strippingRow['keres_id']}'>"
                . "{$strippingRow['termek_nev']}</td>";
            $table .= "<td>{$strippingRow['termek_kiszerel']}</td>";
            $table .= "<td>{$strippingRow['termek_egyseg']}</td>";
            $table .= "<td>{$strippingRow['beszallito_id']}</td>";
            $table .= "<td>{$strippingRow['keres_mennyiseg']}</td>";
            $table .= "<td>{$strippingRow['vez_nev']}" 
                    . ' ' . "{$strippingRow['ker_nev']}</td>";
            $table .= "<td>{$strippingRow['keres_datum']}</td>";
            if($rightToManageRequests == '2'){
                $table .= "<td class='startRenewCancelled btn' value='{$strippingRow['keres_id']}'>"
                . "<img src='./style/renew.png'></td>";
            }
            $table .= "</tr>";
        }
    }else{
        $table .= "<tr>Adatlekérdezési hiba!</tr>";
    }
    $table .= "</table>";
    
    echo $screener.$table.$selecter;
}

