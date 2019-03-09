<?php

class getActiveRequestsOfUserPlace{
    private $conn;
    private $limi;
    private $offset;
    
    private $queryOfActiveRequests = 
            "SELECT raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg,"
            . " raktminoseg.beszallito_id, keresek.keres_mennyiseg,"
            . " keresek.keres_datum, keresek.keres_id"
            . " FROM keresek,(SELECT user_id, vez_nev, ker_nev FROM felhasznadatok WHERE terulet =?) AS csoport,"
            . " raktminoseg, raktmennyiseg"
            . " WHERE keresek.user_id = csoport.user_id"
            . " AND raktmennyiseg.termek_quant_id = keresek.termek_quant_id"
            . " AND raktminoseg.termek_min_id = raktmennyiseg.termek_min_id"
            . " AND keresek.keres_erveny = 1 AND keresek.keres_teljesit=0"
            . " LIMIT ?,?";  
    
    public function setConnectionDatas($connection, $screenAmount, $screenStart){
        $this->conn = $connection;
        $this->limit = $screenAmount;
        $this->offset = $screenStart;
    }
    
    public function executeQueryGetActiveRequests($userArea){
        if ($userArea == ""){
            return false;
        }
        $stmt = $this->conn->prepare($this->queryOfActiveRequests);
        $stmt -> bind_param("sii",$userArea, $this->offset, $this->limit);
        if($stmt->execute()){
            $activeRequestsTable = $stmt->get_result();
            if($activeRequestsTable -> num_rows > 0){
                $stmt -> close();
                
                return $activeRequestsTable;
            } else {
                $stmt -> close();
                return false;
            }
        }else{
            $stmt -> close();
            return false;
        }
    }
}

class getActiveRequestFullNumber{
    private $conn;
    private $queryToDefineFullRecordNumber = 
            "SELECT COUNT(keres_id) FROM keresek,(SELECT user_id, vez_nev, ker_nev"
            . " FROM felhasznadatok WHERE terulet =?) AS csoport"
            . " WHERE keresek.user_id = csoport.user_id"
            . " AND keresek.keres_erveny = 1 AND keresek.keres_teljesit=0";
    
    public function setConnectionDatas($connection){
        $this -> conn = $connection;
    }
    
    public function executeActiveRercordCounting($area){
        if ($area == ""){
            return false;
        }
        $stmt = $this->conn ->prepare($this->queryToDefineFullRecordNumber);
        $stmt -> bind_param("s",$area);
        $stmt -> store_result();
        if($stmt->execute()){
            $stmt->bind_result($amount);
            $stmt->fetch();
                $stmt -> close();
                return $amount;
        }else{
            $stmt -> close();
            return false;
        }
    }
}





