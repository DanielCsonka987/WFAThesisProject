<?php
session_start();
if (isset($_SESSION['userId'])){
    echo file_get_contents('./manualUser.html');
}else{
    session_destroy();
    echo file_get_contents('./manualBasic.html');
}

