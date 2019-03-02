<?php

if(isset($_POST['logout'])){
    session_start();
    session_destroy();
    
    require_once ('../interfaceDB/controllerConnectDB.php');
    $conn->close();
    
    header("Location: http://{$_SERVER['HTTP_HOST']}/ThesisChemoSafeStore/index.php?logOut=true");
}
