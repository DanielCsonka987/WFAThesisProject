$(document).ready(function(){
    $('input[type=text]').focusin(function(){
        $(this).css('background-color', 'yellow');
    });
    $('input[type=text]').focusout(function(){
        $(this).css('background-color', 'white');
    });
    $('input[type=password]').focusin(function(){
        $(this).css('background-color', 'yellow');
    });
    $('input[type=password]').focusout(function(){
        $(this).css('background-color', 'white');
    });
    //loads in the specific manual - depends on the logged in status
    $(document).on("click","#userManual", function(){
        $.ajax({
            url: "./php/manual/manualControllerAj.php",
            method:"POST",
            dataType:"text",
            data:{},
            success: function(answer){
                $('#contentOfSite').html(answer);
            }
            
        });
    });
    //reloads the page if user wants
    $('#logo h1').click(function(){
        location.reload();
    });
        
});