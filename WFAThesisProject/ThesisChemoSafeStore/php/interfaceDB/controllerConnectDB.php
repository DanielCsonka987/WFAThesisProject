<?php
$relativePathToBaseLevel = "http://{$_SERVER['HTTP_HOST']}/ThesisChemoSafeStore";

require_once ('modellerConnectDB.php');
$dataReader = new getDBConnectionInfos();
$datas = $dataReader->getTheInfos($relativePathToBaseLevel);

$conn = new mysqli($datas[0],$datas[1],$datas[2], $datas[3], $datas[4]);
if ($conn -> errno){
    die("Kapcsolódási hiba történt");
}
$conn ->set_charset("utf8");
if ($conn -> errno){
    die("Karakterkódolás beállítása sikertelen");
}


