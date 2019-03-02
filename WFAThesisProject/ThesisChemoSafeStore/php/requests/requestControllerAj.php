<?php

session_start();
if( (isset($_SESSION['userId'])) && (isset($_POST['requestManage']))){
    $modeOfController = $_POST['requestManage'];
    
    if ($modeOfController == 'details'){
        require_once ('./detailsOfAllRequestPage.php');
        
    }else if ($modeOfController == 'modifyActiveFinish'){
        require_once ('requestModellerInterfare.php');
        require_once('../interfaceDB/controllerConnectDB.php');
        $requestId = $_POST['requestId'];
        $userId = $_SESSION['userId'];
        $amount = $_POST['amount'];
                
        $modifierOfActive = new modifyActiveRequest();
        $modifierOfActive->setConnectionDatas($conn);
        if($modifierOfActive->executeModifyActiveRequest($userId, $amount, $requestId)){
            echo "<p>A kérés módostása sikeres!</p>";
        }else{
            echo "<p id='errorMessages'>A módosítás sikertelen!</p>";
        }
        
    }else if ($modeOfController == 'deleteActiveFinish'){
        require_once ('requestModellerInterfare.php');
        require_once('../interfaceDB/controllerConnectDB.php');
        $requestId = $_POST['requestId'];
        $userId = $_SESSION['userId'];

        $deleterOfActive = new deletActiveRequest();
        $deleterOfActive ->setConnectionDatas($conn);
        if($deleterOfActive->executeDeletionActiveRequest($userId, $requestId)){
            echo "<p>A kérés törlése sikeres!</p>";
        }else{
            echo "<p id='errorMessages'>A törlés sikertelen!</p>";
        }
        
    }else if ($modeOfController == 'renewCancelledFinish'){
        require_once ('requestModellerInterfare.php');
        require_once('../interfaceDB/controllerConnectDB.php');
        $requestId = $_POST['requestId'];
        $userId = $_SESSION['userId'];
        
        $renewerOfCancelled = new renewCancelledRequest();
        $renewerOfCancelled->setConnectionDatas($conn);
        if ($renewerOfCancelled->executeRenewCancelledRequest($userId, $requestId)){
            echo "<p>A kérés visszaállítása sikeres!</p>";
        }else{
            echo "<p id='errorMessages'>A visszaállítás sikertelen!</p>";
        }
        
    }else if($modeOfController == 'actualRequests'){
        require_once ('./getActiveList.php');
    }else if ($modeOfController == 'historicRequests'){
        require_once ('./getHistoricList.php');
    }else if ($modeOfController == 'cancelledRequests'){
        require_once ('./getCancelledList.php');
    }

    
}
