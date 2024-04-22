<?php

class Userbase
{

    private $db = null;
    public $error = false;
    public $success = false;

    public function __construct($host, $username, $password, $db)
    {
        try {
            $this->db = new mysqli($host, $username, $password, $db);
            $this->db->set_charset("utf8");
        } catch (Exception $exc) {
            $this->error = true;
            echo '<p>Az adatbázis nem elérhető!</p>';
            exit();
        }
    }


    public function login($name, $password)
    {
        $stmt = $this->db->prepare('SELECT * FROM users WHERE users.username LIKE ?;');
        $stmt->bind_param("s", $name);

        if ($stmt->execute()) {
            $result = $stmt->get_result();
            $row = $result->fetch_assoc();

            if ($row && password_verify($password, $row['password'])) {
                // Password is correct
                return $row;
            } else {
                // Incorrect password
                $_SESSION['username'] = '';
                $_SESSION['login'] = false;


                $this->error = true;
                return false; //-- 
            }

        }

        return false;
    }

    public function valid_password($password)
    {
                // Először ellenőrizzük, hogy a felhasználó létezik-e és helyes-e a jelenlegi jelszava
                $stmt = $this->db->prepare('SELECT * FROM users WHERE username = ?');
                $stmt->bind_param("s", $_SESSION['username']);
                $stmt->execute();
                $result = $stmt->get_result();
                $row = $result->fetch_assoc();
        
                return ($row && password_verify($password, $row['password']));
    }
    public function register($username, $password, $email)
    {
        $stmt = $this->db->prepare("INSERT INTO `users`( `userid` ,`username`, `password`, `email`) VALUES (NULL,?,?,?)");
        $password = password_hash($password, PASSWORD_DEFAULT);
        $stmt->bind_param("sss", $username, $password, $email);
        try {
            if ($stmt->execute()) {
                $_SESSION['username'] = $username;
                $_SESSION['login'] = true;
            } else {
                $_SESSION['login'] = false;
                echo '<p>Rögzítés sikertelen!</p>';
            }
        } catch (Exception $exc) {
            echo $exc->getTraceAsString();
        }
    }

    public function changePassword($newPassword)
    {
        $newHashedPassword = password_hash($newPassword, PASSWORD_DEFAULT);

            $updateStmt = $this->db->prepare('UPDATE users SET password = ? WHERE username = ?');
            $updateStmt->bind_param("ss", $newHashedPassword, $_SESSION['username']);

            if ($updateStmt->execute()) {
                // Jelszó módosítása sikeres
                $this->success = true;
                return true;
            } else {
                // Jelszó módosítása sikertelen
                $this->error = true;
                return false;
            }
        
    }
}
