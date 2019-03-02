<?php

if ((isset($_SESSION['userId'])) && ($_POST['requestManage'] == 'details')){
    
    require_once ('./requestModellerDetails.php');
    require_once ('../interfaceDB/controllerConnectDB.php');
    $userArea = $_SESSION['userArea'];
    $requestId = $_POST['requestId'];
    
    $taskToDo = $_POST['task'];
    $backLimit = $_POST['backLimit'];
    $backOffset = $_POST['backOffset'];
    $backListType = $_POST['backTo'];
    $backStepCode = $backLimit."_".$backOffset."_".$backListType;
    
    $pageContent = "<div>";        

    $getSelectedRecordContent = new getTheDetailsOfOneRequest();
    $getSelectedRecordContent ->setConnectionDatas($conn);
    $recordContent = $getSelectedRecordContent ->executeQueryGetTheDetails($requestId, $userArea);

    if ($recordContent != false) {
        $rowContent = $recordContent -> fetch_assoc();
        if($taskToDo == 'activeDetails'){
            $pageContent .= "<h5>Aktív kérés részletei:</h5>";
        }else if($taskToDo == 'cancelledDetails'){
            $pageContent .= "<h5>Lemondott kérés részletei:</h5>";
        }else if($taskToDo == 'activeMoify'){
            $pageContent .= "<h5>Aktív kérés módosítása:</h5>";
        }else if ($taskToDo == 'activeCancel'){
            $pageContent .= "<h5>Aktív kérés lemondása:</h5>";
        }else if ($taskToDo == 'cancelledRenew'){
            $pageContent .= "<h5>Lemondott kérés visszaállítása:</h5>";
        }else if ($taskToDo == ''){
            $pageContent .= "<h5>Teljesített kérés részletei:</h5>";
        }

        $pageContent .= "<p>Terméknév: {$rowContent['termek_nev']}</p>";
        $pageContent .= "<p>Kiszerelése: {$rowContent['termek_kiszerel']}</p>";
        $pageContent .= "<p>Kiszerlés egysége: {$rowContent['termek_egyseg']}</p>";
        $pageContent .= "<p>Forrása: {$rowContent['beszallito_id']}</p>";
        $pageContent .= "<p>Termékkódja: {$rowContent['termek_kod']}</p>";
        $pageContent .= "<p>Veszélyessége: {$rowContent['termek_veszely']}</p>";
        $pageContent .= "<p>Termékről leírás: {$rowContent['termek_leir']}</p>";
        $pageContent .= "<p>Kérés dátuma: {$rowContent['keres_datum']}</p>";
        $pageContent .= "<p>Kérés teljesítése: {$rowContent['keres_teljesit']}</p>";
        $pageContent .= "<p>Kérést leadta: {$rowContent['reqVez']}"." "."{$rowContent['reqKer']}</p>";
        //$pageContent .= "<p>Kérést módosította: {$rowContent['modifVeznev']}". " " . "{$rowContent['modifKernev']}</p>";
        $pageContent .= "<p></p>";      //it is for the record state
        $pageContent .= "<p id='placeOfWarning'>Kívánt mennyiség: ";
        
        if ($taskToDo == 'activeDetails') {
            $pageContent .= "<span id='mennyiseg'>{$rowContent['keres_mennyiseg']}</span></p>";
            $pageContent .= "<button id='startRequestModify' value='' class='btn btn-primary'>Módosít</button>";
            $pageContent .= "<button id='startRequestCancel' value='' class='btn btn-danger'>Töröl</button>";
            $pageContent .= "<span id='placeForButton'></span>";
            
        } else if ($taskToDo == 'cancelledDetails') {
            $pageContent .= "<span id='mennyiseg'>{$rowContent['keres_mennyiseg']}</span></p>";
            $pageContent .= "<button id='startRenewCancelled' class='btn btn-warning'>Visszaállítás</button>";
            $pageContent .= "<span id='placeForButton'></span>";
            
        } else if ($taskToDo == 'activeMoify') {    //in case of direct reach from the list
            $pageContent .= "<input type='text' name='finalAmount' value='{$rowContent['keres_mennyiseg']}'><span id='#errorMessages'></span></p>";
            $pageContent .= "<button id='letsFinishTheModify' class='btn btn-warning'>Módosítás végrehajtása</button>";
            
        } else if ($taskToDo == 'activeCancel') {   //in case of direct reach from the list
            $pageContent .= "{$rowContent['keres_mennyiseg']}</p>";
            $pageContent .= "<h6 id='errorMessages'>Biztos hogy visszavonja a kérést?</h6>";
            $pageContent .= "<button id='letsFinishTheCancel' class='btn btn-danger'>Visszavonás végrehajtása</button>";
            
        } else if ($taskToDo == 'cancelledRenew') {
            $pageContent .= "{$rowContent['keres_mennyiseg']}</p>";
            $pageContent .= "<button id='letsFinishTheRenew' class='btn btn-danger'>Visszaállítás végrehajtása</button>";
        } else {
            $pageContent .= "{$rowContent['keres_mennyiseg']}</p>";        //case of historic view it is the only
        }
        $pageContent .= "<input type='hidden' name='requestId' value='{$rowContent['keres_id']}'>";
        $pageContent .= "<input type='hidden' name='forBackLimit' value='$backLimit'>";
        $pageContent .= "<input type='hidden' name='forBackOffset' value='$backOffset'>";
        //$pageContent .= "<input type='hidden' name='forManageType' value='$backListType'>";
    }else{
        $pageContent .= "<p>Nincs megjeleníthető tartalom</p>";
    }
    $pageContent .= "<button id='backToList' class='btn btn-success' value='$backStepCode'>Vissza</button>";   //case of historic view it is the only
    $pageContent .= "</div>";
    echo $pageContent;
}

