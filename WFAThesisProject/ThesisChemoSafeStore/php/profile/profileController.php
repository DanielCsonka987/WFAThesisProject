<?php

session_start();

if(isset($_SESSION['userId']) && isset($_POST['profileManage'])){
    $controlMode = $_POST['profileManage'];
    
    $userName = $_SESSION['userName'];
    $userId = $_SESSION['userId'];
    $userLastName= $_SESSION['userDetails'][0];
    $userFirstName= $_SESSION['userDetails'][1];
    $taj= $_SESSION['userDetails'][2];
    $positon = $_SESSION['userDetails'][3];
    $rightId = $_SESSION['userDetails'][4];
    $userArea = $_SESSION['userArea'];
    
    $oldPwdFail = false;
    $newPwdIsInUse = false;
    $saveDatasFail = false;
    
    $result = "<form>";

    if ($_POST['profileManage'] == 'detailsSave'){      //manage the pwd change -> normal if successed
        require_once ('../interfaceDB/controllerConnectDB.php');  //-> if fails, loads back the change view and error
        require_once ('./profileModeller.php');
        $userLastName = $_POST['lastname'];
        $userFirstName = $_POST['firstname'];
        $taj = $_POST['taj'];
        
        $change = new changeDetails();
        $change ->setThaConnectionDatas($conn, $userId);
        $change ->setThePersonalDatas($userFirstName, $userLastName, $taj);
        $saveDatasFail = $change->executePersDetailsChange();   //true->failure
        

        if(!$saveDatasFail){
            $_SESSION['userDetails'][0] = $userLastName;
            $_SESSION['userDetails'][1] = $userFirstName;
            $_SESSION['userDetails'][2] = $taj;
            $controlMode = 'show';   //makes to show tne normal view
        }else{
            $controlMode = 'detailsChange';
        }
    }else if ($controlMode == 'passwordSave'){   //manage the change -> normal if successed
        require_once ('../interfaceDB/controllerConnectDB.php');
        require_once ('./profileModeller.php');
        $oldPwd = $_POST['oldpassword'];
        $newPwd = $_POST['newpassword'];
        
        $getOldPwd = new findTheOldPwdForHashTest();
        $getOldPwd ->setTheConnectionDatas($conn, $userId);
        $oldPwdHashed = $getOldPwd->executeReadOutQuery();

        if($oldPwdHashed != false){
            if(password_verify($oldPwd, $oldPwdHashed)){
                $newhashedpwd = password_hash($newPwd, PASSWORD_BCRYPT);
                $pwdChange = new changePassword();
                $pwdChange -> setTheConnectionDatas($conn, $userId);
                $pwdChange ->setHasedPwdToSave($newhashedpwd);
                if($pwdChange -> executePwdChange()){
                    $controlMode = 'show';
                    $newPwdIsInUse = true;
                }else{  //sawing the new false
                    $controlMode = 'passwordChange';
                    $saveDatasFail = true;
                }
            }else{  //oldPwd verify false
                $controlMode = 'passwordChange';
                $oldPwdFail = true;
            }
        }else{  //can't get the old pwd
            $controlMode = 'passwordChange';
            $oldPwdFail = true;
        }
    }else if ($controlMode == 'detailsChange'){    //details change view
        
        $result .= "<div class='row'><div class='col-6'>";
            $result .= "<p>Vezetéknév: <input type='text' id='lastName' value='{$userLastName}'></p>";
            $result .= "<p>Keresztnév: <input type='text' id='firstName' value='{$userFirstName}'></p>";
            $result .= "<p>Tajszám: <input type='text' id='tajNumber' value='{$taj}'></p>";
            $result .= "<p id='profUserSaveBtn' class='menuitem'>Új adatok mentése</p>";
            $result .= "<p id='profCancelBtn' class='menuitem'>Mégse</p>";
        $result .= "</div><div class='col-6'>";
            $result .= "<p>Felhasználói neve: {$userName}</p>";
            $result .= "<p>Beosztása: {$positon}</p>";
            $result .= "<p>Területe: {$userArea}</p>";
            $result .= "<p>Felhasználói jogköre: {$rightId}</p>";
        $result .= "</div></div>";
        
    }else if ($controlMode == 'passwordChange'){ //password change view
        
        $result .= "<div class='row'><div class='col-6'>";
            $result .= "<p>Régi jelszó: <input type='text' id='oldPwd' value=''></p>";
            $result .= "<p>Új jelszó: <input type='text' id='newPwd' value''></p>";
            $result .= "<p>Új megerősítése: <input type='text' id='newConfPwd' value=''></p>";
            $result .= "<p id='profPwdSaveBtn' class='menuitem'>Új jelszó mentése</p>";
            $result .= "<p id='profCancelBtn' class='menuitem'>Mégse</p>";
        $result .= "</div><div class='col-6'>";
            $result .= "<p>Felhasználói neve: {$userName}</p>";
            $result .= "<p>Beosztása: {$positon}</p>";
            $result .= "<p>Területe: {$userArea}</p>";
            $result .= "<p>Felhasználói jogköre: {$rightId}</p>";
        $result .= "</div></div>";
        
    }
    if($controlMode == 'show'){    //normal view of profile
        
        $result .= "<div class='row'><div class='col-6'>";
            $result .= "<p>Vezetéknév: {$userLastName}</p>";
            $result .= "<p>Keresztnév: {$userFirstName}</p>";
            $result .= "<p>Tajszám: {$taj}</p>";
            $result .= "<p id='profUserBtn' class='menuitem'>Felhasználói adatok módosítása</p>";
            $result .= "<p id='profPwdBtn' class='menuitem'>Jelszómódosítás</p>";
        $result .= "</div><div class='col-6'>";
            $result .= "<p>Felhasználói neve: {$userName}</p>";
            $result .= "<p>Beosztása: {$positon}</p>";
            $result .= "<p>Területe: {$userArea}</p>";
            $result .= "<p>Felhasználói jogköre: {$rightId}</p>";
        $result .= "</div></div>";
    }
    if($oldPwdFail){
        $result .= "<span id='errorMessages'><p>A régi jelszó helytelen!</p></span>";
    }
    if($saveDatasFail){
        $result .= "<span id='errorMessages'><p>Az adatrögzítés sikertelen!</p></span>";
    }
    if($newPwdIsInUse){
        $result .= "<span><p>Az új jelszó elmentése siekres!</p></span>";
    }
    $result .= "</form>";
    echo $result;
}