
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head><title>

</title>
    <script src="jqueryFileTree/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="jqueryFileTree/jqueryFileTree.js" type="text/javascript"></script>
    <link href="jqueryFileTree/jqueryFileTree.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#container_id').fileTree({
                root: '/Media/',
                script: 'jqueryFileTree/jqueryFileTree.aspx',
                expandSpeed: 500,
                collapseSpeed: 500,
                multiFolder: false
            }, function (file) {
                /*alert(file);*/
                parent.fileclick(file);
            });
        });
    </script>
</head>
<body style="margin:0px;background:#ffffff">
    <form name="form1" method="post" action="asset.aspx" id="form1">
<div>
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKLTIwNjAyODU4M2Rkv/TnfPdFOhVP25L3YUomNuLJ38Y=" />
</div>



    <div id="container_id" style="padding:15px"></div>
    
    </form>
<!-- Piwik --><script type="text/javascript">var pkBaseURL = (("https:" == document.location.protocol) ? " https://piwik.webcontrolcenter.com/ " : " http://piwik.webcontrolcenter.com/"); document.write(unescape("%3Cscript src='" + pkBaseURL + "piwik.js' type='text/javascript'%3E%3C/script%3E"));</script><script type="text/javascript">                  try { var piwikTracker = Piwik.getTracker(pkBaseURL + "piwik.php", 6161); piwikTracker.trackPageView(); piwikTracker.enableLinkTracking(); } catch (err) { }</script><noscript><p><img src="http://piwik.webcontrolcenter.com/piwik.php?idsite=6161" style="border:0" alt="" /></p></noscript><!-- End Piwik Tracking Code --></body>
</html>
