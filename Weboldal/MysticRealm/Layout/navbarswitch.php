<?php
    switch($navbardswitch){
        case 'lore':
            require_once './Page/lore.php';
            break;
        case 'hero':
            require_once './Page/hero.php';
            break;
        case 'monster':
            require_once './Page/monster.php';
            break;
        case 'logout':
            require_once './Page/logout.php';
            break;
        case 'contact':
            require_once './Page/contact.php';
            break;
        case 'home':
            require_once './Layout/home.php';
            break;
        case 'settings':
            require_once './Page/settings.php';
            break;
        case 'privacy':
            require_once './Layout/privacy.php';
            break;
        case 'download':
            require_once './Page/download.php';
            break;
        default:
        require_once './Layout/home.php';
    }