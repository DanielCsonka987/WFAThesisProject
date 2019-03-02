<?php

if ((isset($_SESSION['userId'])) && ($_POST['storeManage']) == 'details') {
    require_once('../interfaceDB/controllerConnectDB.php');
    require_once('./storeModeller.php');

    $quantId = (int) $_POST['strippingId'];
    $rightToManageRequests = $_SESSION['userRights'][9];
    $backLimit = $_POST['backLimit'];
    $backOffset = $_POST['backOffset'];
    if ($_POST['backKeyword'] != "") {
        $backKeyWord = $_POST['backKeyword'];
    } else {
        $backKeyWord = "";
    }
    $backStepCode = $backLimit . "_" . $backOffset . "_" . $backKeyWord;

    $getDetails = new getTheDescriptionOfChosen;
    $getDetails->setConnectionDatas($conn);
    $resultRecord = $getDetails->executeQueryGetDetailsOfSpecific($quantId);

    $detailsResult = "<div>";
    $detailsResult .= "<h5>A kiválasztott termék részletes információi:</h5>";
    if ($resultRecord != false) {
        while ($strippingRow = $resultRecord->fetch_assoc()) {
            $detailsResult .= "<p>Terméknév: {$strippingRow['termek_nev']}</p>";
            $detailsResult .= "<p>Kiszerelése: {$strippingRow['termek_kiszerel']}</p>";
            $detailsResult .= "<p>Kiszerlés egysége: {$strippingRow['termek_egyseg']}</p>";
            $detailsResult .= "<p>Forrása: {$strippingRow['beszallito_id']}</p>";
            $detailsResult .= "<p>Termékkódja: {$strippingRow['termek_kod']}</p>";
            $detailsResult .= "<p>Veszélyessége: {$strippingRow['termek_veszely']}</p>";
            $detailsResult .= "<p>Termékről leírás: {$strippingRow['termek_leir']}</p>";
            $detailsResult .= "<button id='datasheetFromDetails' value='{$strippingRow['termek_biztons']}'"
                    . "class='btn btn-info'>Biztonsági adatlapja</button>";
            if ($rightToManageRequests == '2') {
                $detailsResult .= "<button id='storeStartRequestingFromDetailsPage' value='$quantId'"
                        . "class='btn btn-warning'>Kérésalkotás</button>";
            }
            $detailsResult .= "<input type='hidden' name='valueLimit' value='$backLimit'>";
            $detailsResult .= "<input type='hidden' name='valueOffset' value='$backOffset'>";
            $detailsResult .= "<input type='hidden' name='valueKeyWord' value='$backKeyWord'>";
        }
    } else {
        $detailsResult = "<p>Nincs megjeleníthető tartalom!</p>";
    }
    $detailsResult .= "<button id='backStoreListsFormDetails' value='$backStepCode'"
            . " class='btn btn-success'>Vissza</button></div>";
    echo $detailsResult;
}



