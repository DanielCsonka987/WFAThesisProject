<?php

class doesLoggingInFirst{
    
    private $queryForFindUser = "SELECT user_id, jelszo FROM felhaszn"
            . " WHERE user_name=? AND hozzafer_ervenyes <> 0";
    private $conn;
    private $userid;
    private $username;
    private $hasgpwd;
    
    public function setTheConnection($connection, $userNameForTest){
        $this -> conn = $connection;
        $this -> username = $userNameForTest;
    }
    
    public function findTheUser(){
        $stmt = $this -> conn -> prepare($this -> queryForFindUser);
        $stmt -> bind_param("s", $this -> username);
        $stmt -> execute();
        $stmt -> store_result();
        
        if($stmt -> num_rows == 1){
            $stmt -> bind_result($user_id, $jelszo);
            $stmt -> fetch();
            $this -> userid = $user_id;
            $this -> hashpwd = $jelszo;
            $stmt -> close();
            return true;
        }else{
            $stmt -> close();
            return false;
        }
    }
    
    public function getTheUserId(){
        return $this -> userid;
    }
    
    public function getTheHashPwd(){
        return $this -> hashpwd;
    }
}

class doesTheLoggingInSecond{
    
   private $queryForGetDetails =
        "SELECT felhasznadatok.vez_nev, felhasznadatok.ker_nev, felhasznadatok.taj_szam,"
        . " felhasznadatok.beosztas, felhasznadatok.terulet, felhasznadatok.jog_id, jogosultsag.jog"
        . " FROM felhasznadatok, jogosultsag"
        . " WHERE felhasznadatok.jog_id = jogosultsag.jog_id AND user_id=?";
   private $userId;
   private $conn;
   private $userDetails;
   private $area;
   private $jogosultsagok;
   
   public function setTheConnection($connection,$userIdForDataCollerction){
       $this -> conn = $connection;
       $this -> userId = $userIdForDataCollerction;
   }
   
   public function findTheDatasOfUser(){
        $stmt = $this -> conn -> prepare($this -> queryForGetDetails);
        $stmt -> bind_param("i", $this -> userId);
        $stmt -> execute();
        $stmt -> store_result();
        
        if($stmt -> num_rows == 1){
            $stmt -> bind_result($vez_nev, $ker_nev, $taj_szam,
                    $beosztas, $terulet, $jog_id, $jog);
            $stmt -> fetch();
            $this -> userDetails = [$vez_nev, $ker_nev, $taj_szam, $beosztas, $jog_id];
            $this -> area = $terulet;
            $this -> jogosultsagok = $jog;
            $stmt -> close();
            return true;
        }else{
            $stmt -> close();
            return false;
        }
   }
   
   public function getTheUserDetails(){
       return $this -> userDetails;
   }
   
   public function getUserArea(){
       return $this -> area;
   }
   
   public function getTheRightsFromDB(){
       return $this -> jogosultsagok;
   }
}