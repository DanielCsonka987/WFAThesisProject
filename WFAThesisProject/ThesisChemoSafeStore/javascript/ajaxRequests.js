$(document).ready(function(){
    
    //ACTIVE FUNCTIONS - LIST MANAGE
    //start the view of the active requerst
    $(document).on("click","#requestShowNormal", function(){
        getTheRequestList('actualRequests',25,0);

    });
    //user wants to change the limit at active requests
    $(document).on("click","#requestActiveScreen", function(){
        let limit = $("#requestActiveScreenLimit option:selected").val();
        getTheRequestList('actualRequests', limit, 0);

    });
    //turn page at active request
    $(document).on("click",".selectedActivePageOffset", function(){
        let offset = $(this).attr("value");
        let limit = $("#requestActiveScreenLimit option:selected").val();
        getTheRequestList('actualRequests',limit, offset);
    });
    
    //ACTIVE FUNCTIONS - VIEW DETAILS
    //details of the active request
    $(document).on("click",".activeRequestDetails", function(){
        let requestId = $(this).attr("value");
        let backLimit = $("#requestActiveScreenLimit option:selected").val();
        let backOffset = $('#actualActiveOffset').val();
        detailsOrStartChangeRequestContent('details', requestId, 'activeDetails','toActiveList', backLimit, backOffset);
    });
    
    //ACTIVE FUNCTIONS - CANCELING
    //start cancel the active request from list
    $(document).on("click",".startRequestCancel",function(){
        let requestId = $(this).attr("value");
        let backLimit = $("#requestActiveScreenLimit option:selected").val();
        let backOffset = $("#actualActiveOffset").attr("value");
        detailsOrStartChangeRequestContent('details', requestId, 'activeCancel', 'toActiveList', backLimit, backOffset);
    });
    //start cancel the active request from the details-page
    $(document).on("click","#startRequestCancel",function(){
        $("h5").html("Aktív kérés lemondása:");
        $("#startRequestModify").remove();
        $("#startRequestCancel").remove();
        $("#placeForButton").append("<button id='letsFinishTheCancel' class='btn btn-danger'>"+
                "Visszavonás végrehajtása</button>");
        $("#placeOfWarning").after("<h6 id='errorMessages'>Biztos hogy visszavonja a kérést?</h6>");
    });
    //finich cancel the active request
    $(document).on("click","#letsFinishTheCancel", function(){
        let requestId = $("input[name='requestId']").val();
        let backLimit = $("input[name='forBackLimit']").val();
        let backOffset = $("input[name='forBackOffset']").val();
        //let backListPos = $("input[name='forManageType']").val();
        finishDeleteOrRenewTheRequest(requestId, 'deleteActiveFinish', backLimit, backOffset);
    });
    
    //ACTIVE FUNCTIONS - MODIFY
    //start modify the active request from list
    $(document).on("click",".startRequestModify", function(){
        let requestId = $(this).attr("value");
        let backLimit = $("#requestActiveScreenLimit option:selected").val();
        let backOffset = $("#actualActiveOffset").attr("value");
        detailsOrStartChangeRequestContent('details', requestId, 'activeMoify', 'toActiveList', backLimit, backOffset);
    });
    //start modify the active request from the details-page
    $(document).on("click","#startRequestModify", function(){
        $("h5").html("Aktív kérés módosítása:");
        $("#startRequestModify").remove();
        $("#startRequestCancel").remove();
        let originAmount = $("#mennyiseg").text();
        $("#mennyiseg").html("<input type='text' name='finalAmount' value='" + originAmount +"'>"
                + "<span id='#errorMessages'></span>");
        $("#placeForButton").append("<button id='letsFinishTheModify' class='btn btn-warning'>" 
                +"Módosítás végrehajtása</button>");
    });
    //finish modify the active request
    $(document).on("click","#letsFinishTheModify", function(){
        let finalAmount = $("input[name='finalAmount']").val();
        if(isFinite(finalAmount)){
            let requestId = $("input[name='requestId']").val();
            let backLimit = $("input[name='forBackLimit']").val();
            let backOffset = $("input[name='forBackOffset']").val();

            finishChangingTheActiveRequestContent(requestId, finalAmount, 'modifyActiveFinish', backLimit, backOffset)
            
        }else{
            $("#errorMessages").html("Kérem, ide egész számértéket írjon!");    //problematic!!!
        }
    });
    //END OF ACTIVE FUNCTIONS
    
    
    
    //HISTORIC FUNCTIONS - LIST MANAGE
    //loads up the starter request histroy page
    $(document).on("click", "#requestShowHistoric", function(){
        getTheRequestList('historicRequests', 25, 0);
    });
    //changes the screening limit and uploads the histroy pagelist
    $(document).on("click","#requestHistoricScreen",function(){
        let limit = $("#requestHistoricScreenLimit option:selected").val();
        getTheRequestList('historicRequests', limit, 0);
    });
    //turn page on the historic request histroy pagelist
    $(document).on("click",".selectedHistoricPageOffset",function(){
        let limit = $("#requestHistoricScreenLimit option:selected").val();
        let offset = $(this).attr("value");
        getTheRequestList('historicRequests',limit, offset);
    });
    
    //HISTORIC FUNCTIONS - DETAILS
    //details of the historic request
    $(document).on("click",".historicRequestDetails", function(){
        let requestId = $(this).attr("value");
        let backLimit = $("#requestHistoricScreenLimit option:selected").val();
        let backOffset = $("#actualHistoricOffset").attr("value");
        detailsOrStartChangeRequestContent('details', requestId, '','toHistoryList', backLimit, backOffset);
    });
    //END OF HISTORIC FUNCTIONS
  
  
  
    //CANCELLED FUNCTIONS- LIST MANAGE
    //loads up the starter request cancelled page
    $(document).on("click", "#requestShowCancelled", function(){
        getTheRequestList('cancelledRequests', 25, 0);
    });
    //changes the screening limit and uploads the cancelled pagelist
    $(document).on("click","#requestCancelledScreen",function(){
        let limit = $("#requestCancelledScreenLimit option:selected").val();
        getTheRequestList('cancelledRequests', limit, 0);
    });
    //turn page on the request cancelled pagelist
    $(document).on("click",".selectedCancelledPageOffset",function(){
        let limit = $("#requestCancelledScreenLimit option:selected").val();
        let offset = $(this).attr("value");
        getTheRequestList('cancelledRequests',limit, offset);
    });
    
    //CANCELLED FUNCTIONS - DETAILS
    //details of the cancelled request
    $(document).on("click",".cancelledRequestDetails",function(){
        let requestId = $(this).attr("value");
        let backLimit = $("#requestCancelledScreenLimit option:selected").val();
        let backOffset = $("#actualCancelledOffset").attr("value");
        console.log(backOffset);
        detailsOrStartChangeRequestContent('details', requestId, 'cancelledDetails', 'toCancelledList', backLimit, backOffset);
    });
    //renew the cancelled request - from list
    $(document).on("click",".startRenewCancelled",function(){
        let requestId = $(this).attr("value");
        let backLimit = $("#requestCancelledScreenLimit option:selected").val();
        let backOffset = $("#actualCancelledOffset").attr("value");
        detailsOrStartChangeRequestContent('details', requestId, 'cancelledRenew', 'toCancelledList', backLimit, backOffset);

    });
    
    //CANCELLED FUNCTIONS - RENEW
    //renew the cancelled request - from details
    $(document).on("click","#startRenewCancelled",function(){
        $("h5").text("Lemondott kérés visszaállítása:");
        $("#startRenewCancelled").remove();
        $("#placeForButton").append("<button id='letsFinishTheRenew' class='btn btn-danger'>Visszaállítás végrehajtása</button>");
    });
    //finish the renewing process
    $(document).on("click","#letsFinishTheRenew",function(){
        let requestId = $("input[name='requestId']").val();
        let backLimit = $("input[name='forBackLimit']").val();
        let backOffset = $("input[name='forBackOffset']").attr("value");
        finishDeleteOrRenewTheRequest(requestId, 'renewCancelledFinish', backLimit, backOffset);
    });
    //END OF CANCELLED FUNCTIONS
    
    
    
    //UNIVARSAL STEP BACK FROM DETAIL PAGE
    //back from a detail-manage page to somewhere - universal
    $(document).on("click","#backToList",function(){
        let backDetails = $("#backToList").val();
        let parts = backDetails.split("_");
        if(parts[2] == 'toActiveList'){
            getTheRequestList('actualRequests',parts[0], parts[1]);
        }else if (parts[2] == 'toCancelledList'){
            getTheRequestList('cancelledRequests',parts[0], parts[1]);
        }else if (parts[2] == 'toHistoryList'){
            getTheRequestList('historicRequests',parts[0], parts[1]);
        }
    });
});



//DIRECT MANAGE OF VIEW ON PAGE CONTENT - LIST
function getTheRequestList(type, limitOf, offsetOf) {
    $.ajax({
        url: "./php/requests/requestControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            requestManage: type,
            limit: limitOf,
            offset: offsetOf
        },
        success: function (answer) {
            $("#contentOfSite").html(answer);
        }
    });
}
//DIRECT MANAGE OF DETAILS PAGE CONTENT - ALL CASES
function detailsOrStartChangeRequestContent(mainMessage, neededRequestId, taskToDo, surfaceOrigin, limit, offset){
    $.ajax({
       url: "./php/requests/requestControllerAj.php",
       type: "POST",
       dataType: "text",
       data:{
           requestManage: mainMessage,
           requestId: neededRequestId,
           task: taskToDo,
           backTo: surfaceOrigin,
           backLimit: limit,
           backOffset: offset
       },
       success: function (answer){
           $("#contentOfSite").html(answer);
       }
    });
}
//FINISHES THE RENEW AND DELETE PROCESSES
function finishDeleteOrRenewTheRequest(requestId, mainMessage, limit, offset){
    $.ajax({
       url: "./php/requests/requestControllerAj.php",
       type: "POST",
       dataType: "text",
       data: {
           requestManage: mainMessage,
           requestId: requestId,
           limit: limit,
           offset: offset
       },
       success: function(answer){
           $("#contentOfSite").html(answer);
       }
    });
}
//FINISHES PROCESSES AT MODIFING THE ACTIVE
function finishChangingTheActiveRequestContent(requestId, amount, mainMessage, limit, offset){
    $.ajax({
        url: "./php/requests/requestControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
           requestManage: mainMessage,
           requestId: requestId,
           amount: amount,
           limit: limit,
           offset: offset
        },
        success: function (answer) {
            $("#contentOfSite").html(answer);
        }
    });
}