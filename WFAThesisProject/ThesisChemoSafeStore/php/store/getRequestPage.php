<?php

if ((isset($_SESSION['userId'])) && ($_POST['storeManage']) == 'requestingStart') {
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./storeModeller.php');

    $quantId = $_POST['strippingId'];
    $backLimit = $_POST['backLimit'];
    $backOffset = $_POST['backOffset'];
    if ($_POST['backKeyword'] != "") {
        $backKeyWord = $_POST['backKeyword'];
    } else {
        $backKeyWord = "";
    }
    $backStepCode = $backLimit . "_" . $backOffset . "_" . $backKeyWord;

    $stripGetter = new getTheDescriptionOfChosen();
    $stripGetter->setConnectionDatas($conn);
    $strippingContent = $stripGetter->executeQueryGetDetailsOfSpecific($quantId);

    $requestPage = "<div>";
    if ($strippingContent != false) {
        while ($strippingRow = $strippingContent->fetch_assoc()) {
            $requestPage .= "<p>Terméknév: {$strippingRow['termek_nev']}</p>";
            $requestPage .= "<p>Kiszerelése: {$strippingRow['termek_kiszerel']}</p>";
            $requestPage .= "<p>Kiszerlés egysége: {$strippingRow['termek_egyseg']}</p>";
            $requestPage .= "<p>Forrása: {$strippingRow['beszallito_id']}</p>";
            $requestPage .= "<p>Termékkódja: {$strippingRow['termek_kod']}</p>";
            $requestPage .= "<p>Veszélyessége: {$strippingRow['termek_veszely']}</p>";
            $requestPage .= "<p>Termékről leírás: {$strippingRow['termek_leir']}</p>";
            $requestPage .= "<p>Kívánt mennyiség: <input type='text' name='amount'>"
                    . "<span id='#errorMessages'></span></p>";
            $requestPage .= "<button id='datasheetFromDetails' value='{$strippingRow['termek_biztons']}'"
                    . "class='btn btn-info'>Biztonsági adatlapja</button>";
            $requestPage .= "<button id='storeExecuteRequesting' value='$quantId'"
                    . "class='btn btn-warning'>Kérés végrehajtása</button>";
            $requestPage .= "<input type='hidden' name='valueLimit' value='$backLimit'>";
            $requestPage .= "<input type='hidden' name='valueOffset' value='$backOffset'>";
            $requestPage .= "<input type='hidden' name='valueKeyWord' value='$backKeyWord'>";
        }
    } else {
        $requestPage .= "<p>Nincs megjeleníthető tartalom!</p>";
    }

    $requestPage .= "<button id='backStoreListsFormDetails' value='$backStepCode'"
            . " class='btn btn-danger'>Vissza</button></div>";
    $requestPage .= "";
    echo $requestPage;
}