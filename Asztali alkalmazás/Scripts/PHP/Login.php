<?php

use LDAP\Result;
// Kapcsolódás az adatbázishoz
$con = mysqli_connect('localhost', 'root', '', 'gamedatabase');

// Kapcsolat ellenőrzése
if(mysqli_connect_errno()) {
    echo "1: Connection failed.";
    exit();
}

// Felhasználónév fogadása az űrlapról
$username = $_POST["username"];

// Előre beállított jelszó hash
$hash = "$2y$10$7n/e.3gbD1N00dxEYdoDUOG1HMKDccFwoUt32cqtr5ALpLF.Sn9V.";

// Felhasználónév ellenőrzése az adatbázisban
$namecheckquery = "SELECT username, password FROM users WHERE username = '".$username."';";
$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check failed.");

// Ellenőrizze, hogy csak egy felhasználó létezik-e az adott felhasználónévvel
if(mysqli_num_rows($namecheck) != 1) {
    echo "5: Either no user with name or more than one";
    exit();
}

// Elkészíti a felhasználónév alapján történő lekérdezést
$stmt = $con->prepare('SELECT * FROM users WHERE username LIKE ?;');
$stmt->bind_param("s", $username);

// Lekérdezés végrehajtása
if ($stmt->execute()) {
    $result = $stmt->get_result();
    $row = $result->fetch_assoc();
}

// Jelszó ellenőrzése és bejelentkezési adatok tárolása a munkamenetben
if ($row && password_verify($_POST['password'], $row['password'])) {
    // Jelszó helyes
    $_SESSION['username'] = $row['username'];
    echo "0"; // Sikeres bejelentkezés
} else {
    // Helytelen jelszó
    $_SESSION['username'] = '';
    echo "6: Incorrect password";
    exit();
}

// Eredménytartalom felszabadítása
$result->free_result();