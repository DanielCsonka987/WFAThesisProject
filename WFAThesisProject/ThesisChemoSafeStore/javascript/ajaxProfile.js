$(document).ready(function(){
    //loading in the surface
    $(document).on("click","#profileBtn",function(){
        $.ajax({
            url: "php/profile/profileController.php",
            type: "POST",
            dataType: "text",
            data:{
                profileManage: "show"
            },
            success:function(answer){
                $("#contentOfSite").html(answer);
            }
        });
    });
    //start to change the personal details
    $(document).on("click","#profUserBtn",function(){
        $.ajax({
            url: "php/profile/profileController.php",
            type: "POST",
            dataType: "text",
            data:{
                profileManage: "detailsChange"
            },
            success:function(answer){
                $("#contentOfSite").html(answer);
            }
        });
    });
    //finish to change the personal details
    $(document).on("click","#profUserSaveBtn",function(){
        let lastName = $("#lastName").val();
        let firstName = $("#firstName").val();
        if ((lastName.charAt(0).toUpperCase()) === (lastName.charAt(0)) &&
                (firstName.charAt(0).toUpperCase()) === (firstName.charAt(0)) ){
            let tajNumber = $("#tajNumber").val();
            let temp = true;
            for(var i = 0; i<10; i++){
                if(i != 3 && i != 7){
                    if(isNaN(parseInt(tajNumber.charAt(i)))){
                        temp = false;
                        break;
                    }
                }
            }
            if((tajNumber.charAt(3) == '-') && (tajNumber.charAt(7)== '-')
                   && temp && (tajNumber.length === 11)){
                $.ajax({
                    url: "php/profile/profileController.php",
                    type: "POST",
                    dataType: "text",
                    data:{
                        profileManage: "detailsSave",
                        lastname: lastName,
                        firstname: firstName,
                        taj: tajNumber
                    },
                    success:function(answer){
                        $("#contentOfSite").html(answer);
                    }
                });
            }else{
                errormessage("A taj-számnak 9 karakterbő kell állnia, kötőjelekkel"
                    + " elválasztva, pl. 123-456-789");
            }
        }else{
            errormessage("A családi és keresztneveknek nagybetűvel kell kezdődniük");
        }

    });
    //start to change the password
    $(document).on("click","#profPwdBtn", function(){
        $.ajax({
            url: "php/profile/profileController.php",
            type: "POST",
            dataType: "text",
            data:{
                profileManage: "passwordChange"
            },
            success:function(answer){
                $("#contentOfSite").html(answer);
            }
        });
    });
    //finis to change the password
    $(document).on("click","#profPwdSaveBtn",function(){
        let oldPwd = $("#oldPwd").val();
        let newPwd = $("#newPwd").val();
        let newConfPwd = $("#newConfPwd").val();
        if(decisionPwd(oldPwd)){
            if (decisionPwd(newPwd)){
                if(newPwd == newConfPwd){
                    $.ajax({
                        url: "php/profile/profileController.php",
                        type: "POST",
                        dataType: "text",
                        data:{
                            profileManage: "passwordSave",
                            oldpassword: oldPwd,
                            newpassword: newPwd
                        },
                        success:function(answer){
                            $("#contentOfSite").html(answer);
                        }
                    });
                }else{
                    errormessage("A jelszómegerősítés nem megfelelő");
                }
            }else{
                errormessage("Az új jelszó nem elég összetett");
            }
        }else{
            errormessage("A régi nem lehet valós, nem elég összetett");
        }

    });
    //cancel the actual change-process
    $(document).on("click","#profCancelBtn",function(){
        $.ajax({
            url: "php/profile/profileController.php",
            type: "POST",
            dataType: "text",
            data:{
                profileManage: "show"
            },
            success:function(answer){
                $("#contentOfSite").html(answer);
            }
        });
    });
});

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

function errormessage(message){
    if(!$("#errorMessages").lenght){
        $("#contentOfSite").append("<span id='errorMessages'></span>");
    }
    $("#errorMessages").html("<p>"+message+"</p>");
}