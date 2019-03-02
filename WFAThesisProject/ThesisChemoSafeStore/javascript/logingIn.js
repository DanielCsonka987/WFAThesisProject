$(document).ready(function(){
    //define the login process
    $('button[name="loginBtn"]').click(function(){
        let nameOfUser = document.getElementById('userN').value;
        let UNaccepted = decisionName(nameOfUser);
        let pwdOfUser = document.getElementById('userP').value;
        let PWDaccepted = decisionPwd(pwdOfUser);
        if (UNaccepted && PWDaccepted){
            $('#loginForm').submit();
        }else{
            if (!$('#errorMessages').length){
                $('#forLoggingIn').append('<span id=errorMessages></span>');
            }
            $('#errorMessages').html("<p>Hibás felhasználónév vagy jelszó!</p>");
        }
    });
});


//defines wheather the written username is possibly correct
function decisionName(name){
    var decision = false;
    if (name != null){
        var regeX = new RegExp('[0-9]{2}$');
        if (name.length >= 8){
            if (regeX.test(name)){
                decision = true;
            }
        }
    //console.log(decision + " " + name);
    }
    return decision;
}

//defines wheather the written password is possibly correct
function decisionPwd(pwd){
    var decision = false;
    if(pwd != null){
        var regeXSpec = new RegExp('[\$\+\<\ \>\=\§\|\~\!\"\#\%\&\'\(\)\*\,\-\.\/\:\;\?\@\[\]\_\{\}]{1,}');
        var regeXDigit = new RegExp('[0-9]{1,}');
        var regeXCapital = new RegExp('[A-Z]{1,}',);
        var regeXLower = new RegExp('[a-z]{1,}');
        if (pwd.length >= 8){
            if (regeXSpec.test(pwd) || pwd.indexOf('\\')){
                if (regeXLower.test(pwd) && regeXCapital.test(pwd) && 
                        regeXDigit.test(pwd)){
                    decision = true;
                }
            }
        }
    }
    //console.log(decision + " " + pwd);
    return decision;
}