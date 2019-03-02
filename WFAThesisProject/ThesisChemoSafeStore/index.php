<?php

require_once ('./php/viewIndexPage.php');

?>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Rakrtárkezelés</title>
        <link rel="stylesheet" type="text/css" href="style/bootstrap_4.0css/bootstrap.min.css">
        <link rel="stylesheet" type="text/css" href="style/styleSheet.css">

        <script src="javascript/jquery-3.3.1.min.js"></script>
        
        <script src="javascript/generals.js"></script>
        <script src="javascript/logingIn.js"></script>
        <script src="javascript/logingOut.js"></script>
        <script src="javascript/ajaxProfile.js"></script>
        <script src="javascript/ajaxStore.js"></script>
        <script src="javascript/ajaxRequests.js"></script>

    <body>
        <div class="container-fluid">
            <div id="header" class="row">
                <div id="logo" class="col-sm-6 float-right ">
                    <h1 >ChemoSafeStore</h1>
                </div>
                <div id="profileArea" class="col-sm-6">
                    <div>
                        <?php echo $profileArea ?>
                    </div>

                </div>
            </div>
            
            <div id="article" class="row">
                <div id="menu" class="col-sm-2">
                    <?php  echo $menuItems ?>
                </div>
                <div id="contentOfSite" class="col-sm-10">
                    <?php echo $contentOfPage;
                          echo $sideMessage ?>
                </div>
            </div>
        </div>

    </body>
</html>
