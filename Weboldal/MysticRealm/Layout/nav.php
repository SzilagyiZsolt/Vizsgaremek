<nav class="navbar navbar-expand-lg bg-body-tertiary nav-bg-color" data-bs-theme="dark">
    <div class="container-fluid">
        <img src="./img/logo.png" alt="Logo" width="30" height="24" class="d-inline-block mb-1 ">
        <a class="navbar-brand mb-2" href="#">Mystic Realm</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse " id="navbarSupportedContent">
            <ul class="navbar-nav m-2">
                <?php
                echo '<li class="nav-item">
                    <a class=" nav-link' . ($navbardswitch == 'home' ? ' active' : '') . '"aria-current="page" href="index.php?nav=home">Home</a>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Explore
                        </a>
                        <ul class="dropdown-menu">
                            <li>
                                <a class="dropdown-item' . ($navbardswitch == 'lore' ? ' active' : '') . '"aria-current="page" href="index.php?nav=lore">Lore</a>
                            </li>
                            <li>
                                <a class="dropdown-item' . ($navbardswitch == 'hero' ? ' active' : '') . '"aria-current="page" href="index.php?nav=hero">Hero</a>
                            </li>
                            <li>
                                <a class="dropdown-item' . ($navbardswitch == 'monster' ? ' active' : '') . '"aria-current="page" href="index.php?nav=monster">Monster</a>
                            </li>
                            
                        </ul>
                    </li>
                    <li class="nav-item">
                        <a class=" nav-link' . ($navbardswitch == 'contact' ? ' active' : '') . '"aria-current="page" href="index.php?nav=contact">Contact Us</a>
                    </li>';
                ?>
            </ul>
        </div>
        <ul class="navbar-nav ml-auto">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Üdvözöljük <?php echo $_SESSION['username']; ?>! <img src="./Img/32x32icon.png" class="rounded-circle">
                </a>
                <ul class="dropdown-menu dropdown-menu-end">
                    <li>
                        <a class="dropdown-item<?php echo ($navbardswitch == 'logout' ? ' active' : ''); ?>" aria-current="page" href="index.php?nav=logout">Logout</a>
                        <a class="dropdown-item<?php echo ($navbardswitch == 'settings' ? ' active' : ''); ?>" aria-current="page" href="index.php?nav=settings">Settings</a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</nav>
