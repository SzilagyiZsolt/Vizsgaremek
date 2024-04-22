<?php
if ($login_register==="register") {
    require_once './Page/registration.php';
} else {
    require_once './Page/login.php';
}
