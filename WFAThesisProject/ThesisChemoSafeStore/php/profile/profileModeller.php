<?php

class changeDetails{
    private $conn;
    private $userId;
    
    private $tajNumber;
    private $lastName;
    private $firstName;
    
    private $queryOfChangePersDetails = "UPDATE felhasznadatok SET vez_nev=?, ker_nev=?, taj_szam=?"
            . " WHERE user_id=?";
    //set the connection and the primary key of DB table
    public function setThaConnectionDatas($connection, $theUserId){
        $this -> conn = $connection;
        $this -> userId = $theUserId;
    }
    //set the changed values
    public function setThePersonalDatas($firstname, $lastname, $tajnumber){
        $this -> tajNumber = $tajnumber;
        $this -> lastName = $lastname;
        $this -> firstName = $firstname;
    }
    //execute the prepared query
    public function executePersDetailsChange(){
     
        $stmt = $this -> conn -> prepare($this -> queryOfChangePersDetails);
        $stmt -> bind_param("sssi", $this->lastName, $this->firstName, $this->tajNumber, $this->userId );

        if($stmt -> execute()){
            $stmt -> close();
            return false;   //no failure
        }else{
            $stmt -> close();
            return true;    //fail happened
        }
    }
}

class changePassword{
    private $conn;
    private $userId;
    private $newHashedPwd;
    
    private $queryOfChangePwd = "UPDATE felhaszn SET jelszo=? WHERE user_id=?";
    //set the connection and primary key of table
    public function setTheConnectionDatas($connection, $userid){
        $this->conn = $connection;
        $this->userId = $userid;
    }
    //set the new password
    public function setHasedPwdToSave($newhashedpwd){
        $this->newHashedPwd = $newhashedpwd;
    }
    //executing the password change
    public function executePwdChange(){
        $stmt = $this -> conn -> prepare($this->queryOfChangePwd);
        $stmt -> bind_param("ss", $this->newHashedPwd, $this->userId);
 
        if($stmt -> execute()){
            $stmt -> close();
            return true;   //no failure
        }else{
            $stmt -> close();
            return false;    //fail happened
        }
    }
}

class findTheOldPwdForHashTest{
    private $conn;
    private $userId;
    private $oldHashedPwd;
    
    private $queryOfChangePwd = "SELECT jelszo FROM felhaszn WHERE user_id=?";
    //set the connection and primary key of table
    public function setTheConnectionDatas($connection, $userid){
        $this-> conn = $connection;
        $this-> userId = $userid;
    }
    //execute TheReadingOut
    public function executeReadOutQuery(){
        $stmt = $this -> conn-> prepare($this -> queryOfChangePwd);
        $stmt -> bind_param("i", $this -> userId);

        if($stmt -> execute()){
            $stmt -> store_result();
            if($stmt -> num_rows == 1){
                $stmt -> bind_result($jelszo);
                $stmt -> fetch();
                
                $this -> oldHashedPwd = $jelszo;
                $stmt -> close();
                return $this -> oldHashedPwd;
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