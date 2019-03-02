<?php

class passwordRevise{
    
    private $writtenPassword;
    private $hashedPassword;
    
    public function setPasswordDatas($norm, $hashed){
        $this -> writtenPassword = $norm;
        $this -> hashedPassword = $hashed;
    }
    
    public function verifyPassword(){
        if ($this -> writtenPassword == "" || $this -> hashedPassword == ""){
            return false;
        }
        if(password_verify($this -> writtenPassword, $this -> hashedPassword)){
            return true;
        }else{
            return false;
        }
    }
}

