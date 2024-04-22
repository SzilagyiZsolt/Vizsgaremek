<?php
unset($_SESSION);
session_destroy();
//header("location: index.php; Content-Type: text/html; charset=utf-8");  
echo "<script>window.location.href='index.php';</script>";