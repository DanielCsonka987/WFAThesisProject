<?php

class getTheRecordnumber{
    private $conn;
    private $keyWord;
    private $queryToDefineTheRecordAmount = "SELECT COUNT(termek_quant_id) FROM raktmennyiseg, raktminoseg"
            . " WHERE raktmennyiseg.termek_min_id = raktminoseg.termek_min_id"
            . " AND raktminoseg.termek_nev LIKE ?";
    
    public function setConnectDetails($connection){
        $this->conn = $connection;
    }
    
    public function executeQueryRecordAmountWhithScreen($keyWordOfProductName){
        if ($keyWordOfProductName == ''){
            $this -> keyWord = "%";
        }else{
            $this -> keyWord = "%".$keyWordOfProductName."%";
        }
        $stmt = $this->conn -> prepare($this->queryToDefineTheRecordAmount);
        $stmt -> bind_param("s",$this -> keyWord);
        if($stmt -> execute()){
            $stmt -> store_result();
            if ($stmt -> num_rows == 1){
               $stmt -> bind_result($number);
               $stmt -> fetch();
               $stmt->close();
               return $number;
            }else{
                $stmt->close();
                return false;
            }
        }else{
            $stmt->close();
            return false;
        }
    }
}

class getTheStrippingTable{
    private $conn;
    private $screenLimit;
    private $screenOffset;
    private $screenKeyWord;
    private $queryOfGetStrippingWithKeyWord =
      "SELECT raktmennyiseg.termek_quant_id, raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel,"
            . " raktminoseg.termek_egyseg, raktminoseg.beszallito_id, raktminoseg.termek_biztons"
            . " FROM raktminoseg, raktmennyiseg"
            . " WHERE raktminoseg.termek_min_id = raktmennyiseg.termek_min_id AND raktminoseg.termek_nev LIKE ?"
            . " LIMIT ?,?";
    
    //adjust the connection for the datacollect
    public function setConnectDetails($connection, $screenAmount, $screenStart){
        $this->conn = $connection;
        $this->screenLimit = $screenAmount;
        $this->screenOffset = $screenStart;
    }
    
    public function executeQueryGetScreenedProducts($keyword){    //paramterers are reversed in this syntax!
        if ($keyword == ''){
            $this -> screenKeyWord = "%";
        }else{
            $this -> screenKeyWord = "%".$keyword."%";
        }
        $stmt = $this -> conn -> prepare($this->queryOfGetStrippingWithKeyWord);
        $stmt -> bind_param("sii",$this -> screenKeyWord, $this->screenOffset, $this->screenLimit);
        if($stmt -> execute()){
            $resultTable = $stmt -> get_result();
            if($resultTable -> num_rows > 0){
                $stmt -> close();
                return $resultTable;
            }else{
                $stmt -> close();
                return false;
            }
        }else{
            $stmt -> close();
            return false;
        }
    }
}

//get its danger number, description
class getTheDescriptionOfChosen{
    private $conn;
    private $quantId;
    
    private $queryOfGetDetails = 
            "SELECT raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg,"
            . " raktminoseg.beszallito_id, raktmennyiseg.termek_kod, raktminoseg.termek_veszely,"
            . " raktminoseg.termek_leir, raktminoseg.termek_biztons"
            . " FROM raktmennyiseg, raktminoseg"
            . " WHERE raktmennyiseg.termek_min_id = raktminoseg.termek_min_id"
            . " AND raktmennyiseg.termek_quant_id=?";
    
    public function setConnectionDatas($connect){
        $this -> conn = $connect;
    }
    
    public function executeQueryGetDetailsOfSpecific($quantIdNumber){
        if ($quantIdNumber == null){
            return false;
        }else{
            $stmt = $this->conn->prepare($this->queryOfGetDetails);
            $stmt -> bind_param("i",$quantIdNumber);
            if($stmt -> execute()){
                $record = $stmt->get_result();
                if($record -> num_rows == 1){
                    $stmt -> close();
                    return $record;
                }else{
                    $stmt->close();
                    return false;
                }
            }else{
                $stmt->close();
                return false;
            }
        }
    }
}

class createNewRequestRecord{
    private $conn;
    
    private $queryOfRequestRegistration = 
            "INSERT INTO keresek (termek_quant_id, keres_datum, keres_mennyiseg, user_id,"
            . " keres_teljesit, keres_modosit, keres_erveny)"
            . " VALUES (?,CURDATE(), ? ,?, 0, 0, 1)";
    
    function setConnectionDatas($connection){
        $this -> conn = $connection;
    }
    
    function setRequestRecord($userId, $strippingId, $amount){
        if ($userId == null || $strippingId == null || $amount == null){
            return false;
        }
        $stmt = $this->conn ->prepare($this->queryOfRequestRegistration);
        $stmt -> bind_param("iii",$strippingId, $amount, $userId);
        if($stmt -> execute()){
            $stmt -> close();
            return true;
        }else{
            $stmt -> close();
            return false;
        }
    }
}