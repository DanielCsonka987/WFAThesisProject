<?php

class getHistoricRequestsOfUserPlace{
    private $conn;
    private $limit;
    private $offset;
        
    private $queryOfHistoricRequests = 
            "SELECT raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg,"
            . " raktminoseg.beszallito_id, keresek.keres_mennyiseg,"
            . " keresek.keres_datum, keresek.keres_teljesit, keresek.keres_id"
            . " FROM keresek,(SELECT user_id, vez_nev, ker_nev FROM felhasznadatok WHERE terulet =?) AS csoport,"
            . " raktminoseg, raktmennyiseg"
            . " WHERE keresek.user_id = csoport.user_id"
            . " AND raktmennyiseg.termek_quant_id = keresek.termek_quant_id"
            . " AND raktminoseg.termek_min_id = raktmennyiseg.termek_min_id"
            . " AND keresek.keres_erveny = 2 AND keresek.keres_teljesit<>0"
            . " LIMIT ?,?";  
    
    public function setConnectionDatas($connection, $screenAmount, $screenStart){
        $this->conn = $connection;
        $this->offset = $screenStart;
        $this->limit = $screenAmount;
    }
    
    public function executeQueryGetHistoricRequests($userArea){
        if ($userArea == ""){
            return false;
        }
        $stmt = $this->conn->prepare($this->queryOfHistoricRequests);
        $stmt -> bind_param("sii",$userArea, $this->offset, $this->limit);

        if($stmt->execute()){
            $historicRequestsTable = $stmt->get_result();
            
            if($historicRequestsTable -> num_rows > 0){
                $stmt -> close();
                return $historicRequestsTable;
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

class getHistoricFullNumber{
    private $conn;
        
    private $queryOfHistoricRequests = 
            "SELECT COUNT(keresek.keres_id)"
            . " FROM keresek,(SELECT user_id, vez_nev, ker_nev FROM felhasznadatok WHERE terulet =?) AS csoport"
            . " WHERE keresek.user_id = csoport.user_id"
            . " AND keresek.keres_erveny = 2 AND keresek.keres_teljesit<>0";  
    
    public function setConnectionDatas($connection){
        $this->conn = $connection;
    }
    
    public function executeQueryGetTheNumberOfHistoricRequests($userArea){
        if ($userArea == ""){
            return false;
        }
        $stmt = $this->conn->prepare($this->queryOfHistoricRequests);
        $stmt -> bind_param("s",$userArea);
        $stmt -> store_result();
        if($stmt->execute()){
            $stmt -> bind_result($historicRequestRecAmount);
            $stmt -> fetch();
            if( $historicRequestRecAmount != '0'){
                $stmt -> close();
                return $historicRequestRecAmount;
            }else{
                $stmt->close();
                return false;
            }
        }else{
            $stmt -> close();
            return false;
        }
    }
    
    
}