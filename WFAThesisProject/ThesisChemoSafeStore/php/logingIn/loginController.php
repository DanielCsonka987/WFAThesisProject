<?php

if (isset($_POST["username"])) {
    require_once ('../interfaceDB/controllerConnectDB.php');
    require_once ('./loginModeller.php');
    require_once ('./passwordTester.php');
    require_once ('./rightsTranslator.php');

    $username = $_POST["username"];
    $writPwd = $_POST["password"];

    $identifyFirst = new doesLoggingInFirst;
    $identifyFirst->setTheConnection($conn, $username);

    if ($identifyFirst->findTheUser()) {
        $userId = $identifyFirst->getTheUserId();
        $hashedPwd = $identifyFirst->getTheHashPwd();

        $verifyPwd = new passwordRevise();
        $verifyPwd->setPasswordDatas($writPwd, $hashedPwd);
        if ($verifyPwd->verifyPassword()) {

            $identifySec = new doesTheLoggingInSecond;
            $identifySec->setTheConnection($conn, $userId);
            if ($identifySec->findTheDatasOfUser()) {

                $userDetails = $identifySec->getTheUserDetails();
                $userarea = $identifySec->getUserArea();
                $userRightsIn10 = $identifySec->getTheRightsFromDB();

                $translate = new interpretRightsFromDB();
                $translate->adjustUserRight($userRightsIn10);
                $userRights = $translate->getTranslatedRightValue();

                session_start();
                $_SESSION['userId'] = $userId;
                $_SESSION['userName'] = $username;
                $_SESSION['userArea'] = $userarea;
                $_SESSION['userDetails'] = $userDetails;
                $_SESSION['userRights'] = $userRights;

                header("Location: $relativePathToBaseLevel/index.php");
            } else {
                //error, no details from DB
                header("Location: $relativePathToBaseLevel/index.php?loginError=DBerror");
            }
        } else {
            //not good pwd is written, mistaken password
            header("Location: $relativePathToBaseLevel/index.php?loginError=wrongUnPw");
        }
    } else {
        //no match in DB, username problem
        header("Location: $relativePathToBaseLevel/index.php?loginError=wrongUnPw");
    }
} else {
    //no right to use this part
    header("Location: $relativePathToBaseLevel/index.php?loginError=notEnterDirect");
}


    