<?php

if((isset($_SESSION['userId'])) && ($_POST['requestManage'] == 'actualRequests')){
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./requestModellerActive.php');

    $userArea = $_SESSION['userArea'];
    $limit = $_POST['limit'];
    $offset = $_POST['offset'];
    $screenLimits = [10, 25, 50, 100];
    $rightToManageRequests = $_SESSION['userRights'][9];

    $getterOfFullPagesAmount = new getActiveRequestFullNumber();
    $getterOfFullPagesAmount -> setConnectionDatas($conn);
    $fullRowsNumber = $getterOfFullPagesAmount -> executeActiveRercordCounting($userArea);
    if ($fullRowsNumber != false) {
        
        $pageFullNumbers = ceil((int)$fullRowsNumber/(int)$limit);
        
        $selecter = "<div id='selecter'><p>";
        for($i = 1; $i < $pageFullNumbers + 1; $i++){
            $selecterNextValue = (int)$limit * ($i -1);
            if ($offset == $selecterNextValue){
                $selecter .= "<a id='actualActiveOffset' value='{$selecterNextValue}'>"
                . "<strong>{$i}</strong></a>";
            }else{
                $selecter .= "<a class='selectedActivePageOffset btn' value='{$selecterNextValue}'>{$i}</a>";
            }
        }
        $selecter .= "</p></div>";
    }else{
        $selecter = "<div id='selecter'><p>Nincs megjeleníthető elem!</p></div>";
    }    
        
    $screener = "<div id='screener' class='row'>";
    $screener .= "<div class='col-md-4'><p>Megjelenítés: </p>"
            . "<select id='requestActiveScreenLimit'>";
    for ($i = 0; $i< count($screenLimits); $i++){
        $screener .= "<option value='{$screenLimits[$i]}' ";
        if($screenLimits[$i] == $limit){
            $screener .= "selected";
        }
        $screener .= " >$screenLimits[$i]</option>";
        
    }
    $screener .= "</select>";
    $screener .= "<button id='requestActiveScreen' class='btn btn-primary'>Szűrés</button></div>";
        $screener .= "<div class='col-md-5'><p>Nézetváltás: </p><button id='requestShowHistoric'"
            . " class='btn btn-success'>Átvett kérések</button></div>";
    $screener .= "</div>";
        

       
    
    $table = "<table class='table table-striped table-sm table-hover'>";
    $table .= "<tr class='table-success'><th colspan='7'>Jelenlegi kérések listája</th></tr>";
    $table .= "<tr class='table-success'>"
        . "<th>Terméknév</th>"
        . "<th>Kiszerelés</th>"
        . "<th>Menny. egység</th>"
        . "<th>Beszállító</th>"
        . "<th>Darab</th>"
        . "<th>Kérés ideje</th>";
    if($rightToManageRequests == '2'){
        $table .= "<th></th>";
    }
    $table .= "</tr>";
    
    
    $getTheCancelledRequests = new getActiveRequestsOfUserPlace();
    $getTheCancelledRequests -> setConnectionDatas($conn, (int)$limit, (int)$offset);
    $cancelledRequestDatas = $getTheCancelledRequests ->executeQueryGetActiveRequests($userArea);
    
    if ($cancelledRequestDatas != false){ 
        while($strippingRow = $cancelledRequestDatas -> fetch_assoc() ){
            $table .= "<tr>";
            $table .= "<td class='activeRequestDetails btn' value='{$strippingRow['keres_id']}'>"
                . "{$strippingRow['termek_nev']}</td>";
            $table .= "<td>{$strippingRow['termek_kiszerel']}</td>";
            $table .= "<td>{$strippingRow['termek_egyseg']}</td>";
            $table .= "<td>{$strippingRow['beszallito_id']}</td>";
            $table .= "<td>{$strippingRow['keres_mennyiseg']}</td>";
            $table .= "<td>{$strippingRow['keres_datum']}</td>";
            
            if($rightToManageRequests == '2'){
                $table .= "<td class='startRequestModify btn' value='{$strippingRow['keres_id']}'>"
                . "<img src='./style/modify.png'></td>";
                $table .= "<td class='startRequestCancel btn' value='{$strippingRow['keres_id']}'>"
                . "<img src='./style/delet.png'></td>";
            }
            $table .= "</tr>";
        }
    }else{
        $table .= "<tr>Adatlekérdezési hiba!</tr>";
    }
    $table .= "</table>";
    
    echo $screener.$table.$selecter;
}