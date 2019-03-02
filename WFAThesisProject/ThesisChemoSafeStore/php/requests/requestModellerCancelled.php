<?php


class getCancelledRequestsOfUserPlace{
    private $conn;
    private $limit;
    private $offset;
    
    private $queryOfCancelledRequests = 
            "SELECT raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg,"
            . " raktminoseg.beszallito_id, keresek.keres_mennyiseg,"
            . " csoport.vez_nev, csoport.ker_nev, keresek.keres_datum, keresek.keres_id"
            . " FROM keresek,(SELECT user_id, vez_nev, ker_nev FROM felhasznadatok WHERE terulet =?) AS csoport,"
            . " raktminoseg, raktmennyiseg"
            . " WHERE keresek.user_id = csoport.user_id"
            . " AND keresek.keres_modosit = csoport.user_id"
            . " AND raktmennyiseg.termek_quant_id = keresek.termek_quant_id"
            . " AND raktminoseg.termek_min_id = raktmennyiseg.termek_min_id"
            . " AND keresek.keres_erveny = 0 AND keresek.keres_teljesit=0"
            . " LIMIT ?,?";  
    
    public function setConnectionDatas($connection, $screenAmount, $screenStart){
        $this->conn = $connection;
        $this->offset = $screenStart;
        $this->limit = $screenAmount;
    }
    
    public function executeQueryGetCancelledRequests($userArea){
        if ($userArea == ""){
            return false;
        }
        $stmt = $this->conn->prepare($this->queryOfCancelledRequests);
        $stmt -> bind_param("sii",$userArea, $this->offset, $this->limit);

        if($stmt->execute()){
            $cancelledRequestsTable = $stmt->get_result();
            
            if($cancelledRequestsTable -> num_rows > 0){
                $stmt -> close();
                return $cancelledRequestsTable;
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


class getCancelledRequestRecordNumber{
    private $conn;
    private $queryOfCancelledRequestRecordNumber
            = "SELECT COUNT(keres_id)"
            . " FROM keresek,(SELECT user_id, vez_nev, ker_nev FROM felhasznadatok WHERE terulet =?) AS csoport"
            . " WHERE keresek.user_id = csoport.user_id"
            . " AND keresek.keres_modosit = csoport.user_id"
            . " AND keresek.keres_erveny = 0 AND keresek.keres_teljesit=0";
    
    public function setConnectionDatas($connection){
        $this->conn = $connection;
    }
    
    public function executeQueryGetCancelledRequests($userArea){
        if ($userArea == ""){
            return false;
        }
        $stmt = $this->conn->prepare($this->queryOfCancelledRequestRecordNumber);
        $stmt -> bind_param("s",$userArea);
        $stmt -> store_result();
        if($stmt->execute()){
            $stmt -> bind_result($amountOfCancelledRows);
            $stmt -> fetch();
            if($amountOfCancelledRows != '0'){
                $stmt -> close();
                return $amountOfCancelledRows;
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




