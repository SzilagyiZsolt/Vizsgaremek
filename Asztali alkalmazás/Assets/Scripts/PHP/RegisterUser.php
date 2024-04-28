<?php

// Kapcsolódás az adatbázishoz
$con = mysqli_connect('localhost', 'root', '', 'gamedb');

// Kapcsolat ellenőrzése
if(mysqli_connect_errno()) {
    echo "Connection failed.";
    exit();
}

// Felhasználónév és jelszó fogadása az űrlapról
$username = $_POST["username"];
$password = $_POST["password"];

// Ellenőrzi, hogy a felhasználónév már létezik-e az adatbázisban
$namecheckquery = "SELECT username FROM users WHERE username = '".$username."';";
$namecheck = mysqli_query($con, $namecheckquery) or die("Name check failed.");

// Ha már létezik felhasználó ilyen névvel, akkor kilép
if(mysqli_num_rows($namecheck) > 0) {
    echo "3: Name already exists";
    exit();
}

// Salt létrehozása a jelszó hash-hez
$salt = "\$5\$rounds=5000\$"."steamedhams".$username."\$";

// Jelszó hash-elése
$hash = crypt($password, $salt);

// Új felhasználó beszúrása az adatbázisba
$insertuserquery = "INSERT INTO users (username, hash, salt) VALUES ('".$username."','".$hash."','".$salt."');";
mysqli_query($con, $insertuserquery) or die("Insert player query failed");

// Sikeres művelet esetén kiírja a "0"-t
echo("0");
