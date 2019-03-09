<?php

class deletActiveRequest{
    private $conn;
    
    private $queryOfDeletActiveRequest = 
            "UPDATE keresek SET keres_erveny=0, keres_modosit=?"
            . " WHERE keres_id=? AND keres_erveny=1 AND keres_teljesit=0";
    
    public function setConnectionDatas($connection){
        $this->conn = $connection;
    }
    
    public function executeDeletionActiveRequest($userId, $requestId){
        if($userId == null || $requestId == null){
            return false;
        }
        $stmt = $this->conn -> prepare($this->queryOfDeletActiveRequest);   
        $stmt -> bind_param("ii", $userId, $requestId);
        if($stmt -> execute()){
            $stmt -> close();
            return true;
        }else{
            $stmt -> close();
            return false;
        }
    }
}

class modifyActiveRequest{
    private $conn;
    private $queryToModifyActiveRequest = 
            "UPDATE keresek SET keres_mennyiseg=?, keres_modosit=?"
            . " WHERE keres_id=? AND keres_erveny=1 AND keres_teljesit=0";
    
    public function setConnectionDatas($connection){
        $this->conn = $connection;
    }
    
    public function executeModifyActiveRequest($userId, $amount, $requestId){
        if ($userId == "" || $amount == null || $requestId == null){
            return false;
        }
        $stmt = $this->conn -> prepare($this->queryToModifyActiveRequest);   
        $stmt -> bind_param("iii", $amount, $userId, $requestId);
        if($stmt -> execute()){
            $stmt -> close();
            return true;
        }else{
            $stmt -> close();
            return false;
        }
    }
}


class renewCancelledRequest{
    private $conn;
    private $queryOfRenewCancelledRequest = 
            "UPDATE keresek SET keres_erveny=1, keres_modosit=?"
            . " WHERE keres_id=? AND keres_teljesit=0 AND keres_erveny = 0";
    
    public function setConnectionDatas($connection){
        $this->conn = $connection;
    }
    
    public function executeRenewCancelledRequest($userId,$requestId){
        if($userId == null || $requestId == null){
            return null;
        }
        $stmt = $this->conn -> prepare($this->queryOfRenewCancelledRequest);   
        $stmt -> bind_param("ii", $userId, $requestId);
        if($stmt -> execute()){
            $stmt -> close();
            return true;
        }else{
            $stmt -> close();
            return false;
        }   
    }
}