$(document).ready(function(){
    //define the login process
    $('#logoutBtn').click(function(){
        var form = $(document.createElement('form'));
            $(form).attr("action", "./php/logingOut/logoutController.php");
            $(form).attr("method", "POST");
            $(form).attr("id", "logoutForm");
        var input = $("<input>").attr("type", "hidden").attr("name", "logout").val("bla");
            $(form).append(input);
        $('body').append(form);
        $('#logoutForm').submit();
    });
});