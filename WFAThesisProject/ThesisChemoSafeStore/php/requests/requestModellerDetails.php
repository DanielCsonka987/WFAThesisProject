<?php


//universal - good for every type of request
class getTheDetailsOfOneRequest{
    private $conn;
    private $querryOfGetTheDetails =
            "SELECT raktminoseg.termek_nev, raktmennyiseg.termek_kiszerel, raktminoseg.termek_egyseg,
                raktminoseg.beszallito_id, raktmennyiseg.termek_kod, raktminoseg.termek_veszely,
                raktminoseg.termek_leir, keresek.keres_datum, keresek.keres_teljesit, keresek.keres_mennyiseg,
                keresek.keres_erveny, keresek.keres_id, csoport.vez_nev AS reqVez, csoport.ker_nev AS reqKer
            FROM keresek, raktminoseg, raktmennyiseg, 
                (SELECT user_id, vez_nev, ker_nev FROM felhasznadatok WHERE terulet = ?) AS csoport
            WHERE keresek.user_id = csoport.user_id
                AND keresek.termek_quant_id = raktmennyiseg.termek_quant_id 
                AND raktminoseg.termek_min_id = raktmennyiseg.termek_min_id 
                AND keresek.keres_id = ?";

    
    public function setConnectionDatas($connection){
        $this->conn = $connection;
    }
    
    public function executeQueryGetTheDetails($requestId, $area){
        if ($requestId == null || $area == ""){
            return false;
        }
        $stmt = $this->conn -> prepare($this->querryOfGetTheDetails);   
        $stmt -> bind_param("si", $area, $requestId);
        if($stmt -> execute()){
            $recordContnet = $stmt -> get_result();
            if($recordContnet -> num_rows == 1){
                $stmt -> close();
                return $recordContnet;
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

