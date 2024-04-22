<?php

$filepath="./gamefile.exe";;
$filename="gamefile.exe";

downloadFile($filename,$filepath);


function downloadFile($filename,$filepath)
{

header("Content-type: application/exe"); // instad of pdf use others... for text 
    header("Content-disposition: attachment; filename=".$filename); 
header("Content-Length: " . filesize($filepath));
   	header("Pragma: no-cache"); 
    header("Expires: 0"); 
    readfile($filepath); 

return;
}
?>
