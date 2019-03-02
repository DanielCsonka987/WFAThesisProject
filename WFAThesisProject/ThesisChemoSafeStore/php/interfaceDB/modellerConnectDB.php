<?php


class getDBConnectionInfos{
    private $connectionInfos;

    function getTheInfos($relativePathToBaseLevel){
        $content = simplexml_load_file($relativePathToBaseLevel."/php/interfaceDB/connectionConfig.xml");
        if($content != null){
            $this->connectionInfos[0] = (string)$content->host;
            $this->connectionInfos[1] = (string)$content->user;
            $this->connectionInfos[2] = (string)$content->password;
            $this->connectionInfos[3] = (string)$content->DBname;
            $this->connectionInfos[4] = (int)$content->port;
        }else{
            die("A kapcsolódási adatok betöltése sikertelen!");
        }
        return $this->connectionInfos;
    }
}
