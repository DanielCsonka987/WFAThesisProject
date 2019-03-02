$(document).ready(function(){
    //when user click the funtion start button
    $(document).on("click","#storeManage",function(){
        storeListStartFixLimit();
    });
    //when user clicks the numbers of pages
    $(document).on("click",".selectedStorePageOffset", function(){
        let offset = $(this).attr("value");
        let limit = $("#storeScreenLimit option:selected").val();
        let keyWord = $("input[name='screenword']").val();
       
        storeListIntermediarry(limit, offset, keyWord);
    });
    //when usr clicks the screening button - no need for offset value
    $(document).on("click", "#storeScreen", function(){
        let limit = $("#storeScreenLimit option:selected").val();
        let keyWord = $("input[name='screenword']").val();
        
        storeListStart(limit, keyWord);
        
    });
    
    
    //when user wants to see the specific datasheet from lists
    $(document).on("click","#datasheetFromList",function(){
        let dataSheetName = $(this).attr("value");
        let backLimit = $("#storeScreenLimit option:selected").val();
        let backOffset = $("#actualOffset").attr("value");
        let backKeyWord = $("input[name='screenword']").val();

        storeDataSheetShow(dataSheetName, backLimit, backOffset, backKeyWord);
    });
    //when user wants to step back from datasheet to the listpage
    //works when user get here directly from ilst
    $(document).on("click","#backStoreListsFromSheet", function(){
        let backValues = $(this).val();
        let parts = backValues.split("_");
        let oldLimit = parts[0];
        let oldOffset = parts[1];
        let oldKeyWord = parts[2];
        
        storeListIntermediarry(oldLimit, oldOffset, oldKeyWord);
    });
    
    
    //show details surface
    $(document).on("click", ".detailsSurface", function () {
        let strippingId = $(this).attr("value");
        let backLimit = $("#storeScreenLimit option:selected").val();
        let backOffset = $("#actualOffset").attr("value");
        let backKeyWord = $("input[name='screenword']").val();
        
        storeDetailsSurface(strippingId, backLimit, backOffset, backKeyWord);
    });
    //when user wants to see the specific datasheet from details surface
    $(document).on("click", "#datasheetFromDetails", function(){
        let dataSheetName = $(this).attr("value");
        let backLimit = $("input[name='valueLimit']").val();
        let backOffset = $("input[name='valueOffset']").val();
        let backKeyword = $("input[name='valueKeyWord']").val();
        
        storeDataSheetShow(dataSheetName, backLimit, backOffset, backKeyword);
    });
    //when user wants to step back from datasheet to the listpage
    //works when user get here directly from ilst
    $(document).on("click","#backStoreListsFormDetails", function(){
        let backValues = $(this).val();
        let parts = backValues.split("_");
        let backLimit = parts[0];
        let backOffset = parts[1];
        let backKeyWord = parts[2];
        
        storeListIntermediarry(backLimit, backOffset, backKeyWord);
    });
    
    
    //start to requedst the chosen stripping from listpage
    $(document).on("click","#storeStartRequestingFromListPage", function(){
        let strippingId = $(this).attr("value");
        let backLimit = $("#storeScreenLimit option:selected").val();
        let backOffset = $("#actualOffset").attr("value");
        let backKeyWord = $("input[name='screenword']").val();
        
        startRequestingTheProductStripping(strippingId, backLimit, backOffset, backKeyWord);
    });
    $(document).on("click","#storeStartRequestingFromDetailsPage", function(){
        let strippingId = $(this).attr("value");
        let backLimit = $("input[name='valueLimit']").val();
        let backOffset = $("input[name='valueOffset']").val();
        let backKeyword = $("input[name='valueKeyWord']").val();

        startRequestingTheProductStripping(strippingId, backLimit, backOffset, backKeyword);
    });
    
    //finish the request and back to the listpage
    $(document).on("click","#storeExecuteRequesting",function(){
        let strippingId = $(this).attr("value"); 
        let amount = $("input[name='amount']").val();
        if (isFinite(amount)) {
            let backLimit = $("input[name='valueLimit']").val();
            let backOffset = $("input[name='valueOffset']").val();
            let backKeyword = $("input[name='valueKeyWord']").val();

            finishRequestingTheProductStripping(strippingId, amount, backLimit, backOffset, backKeyword);
        }else{
            $("#errorMessages").html("<p>Kérem számértéket írjon ide!</p>");
        }
    });
});


function storeListStartFixLimit(){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            storeManage: 'normal',
            limit: 25,
            offset: 0,
            keyword: ''
        },
        success: function (answer) {
            $("#contentOfSite").html(answer);
        }
    });  
}

function storeListStart(limitValue, keyWordValue){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            storeManage: 'normal',
            limit: limitValue,
            offset: 0,
            keyword: keyWordValue
        },
        success: function (answer) {
            $("#contentOfSite").html(answer);
        }
    });
}

function storeListIntermediarry(limitValue, offsetValue, keyWordValue){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            storeManage: 'normal',
            keyword: keyWordValue,
            limit: limitValue,
            offset: offsetValue
        },
        success: function (answer) {
            $("#contentOfSite").html(answer);
        }
    });
}

function storeDataSheetShow(dataSheetName, backLimitValue, backOffsetValue, backKeyWordValue){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            storeManage: 'sheet',
            filename: dataSheetName,
            backLimit: backLimitValue,
            backOffset: backOffsetValue,
            backKeyword: backKeyWordValue
        },
        success: function (answer) {
            $("#contentOfSite").html(answer);
        }
    });
}

function storeDetailsSurface(strippingId, backLimit, backOffset, backKeyWord){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            storeManage: 'details',
            strippingId: strippingId,
            backLimit: backLimit,
            backOffset: backOffset,
            backKeyword: backKeyWord
        },
        success: function (answer){
            $("#contentOfSite").html(answer);
        }
    });
}

function startRequestingTheProductStripping(strippingId, backLimit, backOffset, backKeyWord){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {  
            storeManage: 'requestingStart',
            strippingId: strippingId,
            backLimit: backLimit,
            backOffset: backOffset,
            backKeyword: backKeyWord
        },
        success: function(answer){
            $("#contentOfSite").html(answer);
        }
    });
}

function finishRequestingTheProductStripping(strippingId, amount, backLimit, backOffset, backKeyWord){
    $.ajax({
        url: "./php/store/storeControllerAj.php",
        type: "POST",
        dataType: "text",
        data: {
            storeManage: 'requestingFinish',
            strippingId: strippingId,
            amount: amount,
            limit: backLimit,
            offset: backOffset,
            keyword: backKeyWord
        },
        success: function(answer){
            $("#contentOfSite").html(answer);
        }
    });
}