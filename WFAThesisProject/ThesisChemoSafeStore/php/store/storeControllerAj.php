<?php

session_start();
if(isset($_SESSION['userId']) && isset($_POST['storeManage'])){
    
    $modeController = $_POST['storeManage'];

    if($modeController == 'normal'){
        require_once ('getFullList.php');
    }else if ($modeController == 'sheet'){
        require_once ('getDataSheet.php');
    }else if ($modeController == 'details'){
        require_once ('getDetailsPage.php');
    }else if ($modeController == 'requestingStart'){
        require_once ('getRequestPage.php');
    }else if ($modeController == 'requestingFinish'){
        require_once('../interfaceDB/controllerConnectDB.php');
        require_once('./storeModeller.php');

        $userId = (int)$_SESSION['userId'];
        $strippId = (int)$_POST['strippingId'];
        $amount = (int)$_POST['amount'];
        
        $addNewRequest = new createNewRequestRecord();
        $addNewRequest->setConnectionDatas($conn);
        if ($addNewRequest->setRequestRecord($userId, $strippId, $amount)) {
            echo "<div><p>A kérés bejegyzése sikeres!</p></div>";
        } else {
            echo "<div><p>Sajnos a kérés bejegyzése sikertelen!</p></div>";
        }
    }
}
