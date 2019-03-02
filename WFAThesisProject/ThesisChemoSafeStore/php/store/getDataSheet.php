<?php

if ((isset($_SESSION['userId'])) && ($_POST['storeManage']) == 'sheet') {
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./storeModeller.php');
    $filename = $_POST['filename'];
    $backLimit = $_POST['backLimit'];
    $backOffset = $_POST['backOffset'];
    if ($_POST['backKeyword'] != "") {
        $backKeyWord = $_POST['backKeyword'];
    } else {
        $backKeyWord = "";
    }
    $backStepCode = $backLimit . "_" . $backOffset . "_" . $backKeyWord;

    echo "<button id='backStoreListsFromSheet' value='$backStepCode' class='btn btn-danger'>Vissza</button>"
    . " <iframe src='./SafetyDataSheets/{$filename}'"
    . " width='100%' style='height:100%'></iframe>";
}
    


