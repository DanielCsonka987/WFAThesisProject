<?php
$profileArea = "";
$menuItems = "";
$contentOfPage = "";
$sideMessage = "";

$menuItems .= file_get_contents("./php/manual/manualMenuBar.html");

session_start();
if(isset($_SESSION['userId'])){
    //logged in the user
    
    $profileArea = file_get_contents("./php/profile/profileBarArea.html");
    $menuItems .= file_get_contents("./php/store/storeMenuBar.html");
    $contentOfPage .= "<img src='./style/lab-overview.jpg' class='img-fluid m-t-3'>";
    if($_SESSION['userRights'][9] != '0'){
        $menuItems .= file_get_contents("./php/requests/requestMenuBar.html");
    }
    if($_SESSION['userRights'][8] != '0'){
        $menuItems .= file_get_contents("./php/accidents/accidentMenuBar.html");
    }
    if($_SESSION['userRights'][7] != '0'){
        $menuItems .= file_get_contents("./php/users/usersMenuBar.html");
    }
    
    
}else{
    //needed the logging in form - case of logout or failed logging in
    session_destroy();
    $contentOfPage = file_get_contents("./php/logingIn/loginForm.html");
    if (isset($_GET['loginError'])){
        if($_GET["loginError"] == "DBerror"){
            $sideMessage = '<span id="errorMessages"><p>Hibás felhasználónév vagy jelszó!</p></span>';
        }else if($_GET["loginError"] == "wrongUnPw"){
            $sideMessage = '<span id="errorMessages"><p>Hibás felhasználónév vagy jelszó!</p></span>';
        }else if($_GET["loginError"] == "notEnterDirect"){
            $sideMessage = '<span id="errorMessages"><p>Hibás felhasználónév vagy jelszó!</p></span>';
        }
    }
    if (isset($_GET['logOut'])){
        $sideMessage = '<span id=logoutMessage><p>Kilépés megtörtént</p></span>';
    }
}