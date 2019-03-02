<?php
class interpretRightsFromDB{
    
    private $transLatedRighValue;
    
    public function adjustUserRight($rightsFromDB){
        $result = '';
        $value = $rightsFromDB;
        while ($value > 0){
            if($value == 3){
                $result .= '0';
                $value = 0;
            }
            else if ($value == 2){
                $result .= '2';
                $value = 0;
            }
            else if ($value == 1){
                $result .= '1';
                $value = 0;
            }
            else if ($value%3 == 0){
                $result .= '0';
                $value = $value/3;
            }
            else if (($value-1)%3 == 0){
                $result .= '1';
                $value = ($value - 1)/3;
            }
            else if (($value-2)%3 == 0){
                $result .= '2';
                $value = ($value - 2)/3;
            }
        }
        $this -> transLatedRighValue = $result;
    }
    
    public function getTranslatedRightValue(){
        return $this -> transLatedRighValue;
    }
}