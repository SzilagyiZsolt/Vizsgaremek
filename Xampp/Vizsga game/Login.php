<?php

use LDAP\Result;

  $con= mysqli_connect('localhost','root','','gamedatabase');
  if(mysqli_connect_errno()){
    echo "1: Connection failed.";
    exit();
  }
  $username = $_POST["username"];
  $hash="$2y$10$7n/e.3gbD1N00dxEYdoDUOG1HMKDccFwoUt32cqtr5ALpLF.Sn9V.";
  $namecheckquery="SELECT username, password FROM users WHERE username = '".$username."';";
  $namecheck=mysqli_query($con,$namecheckquery) or die("2: Name check failed.");
  if(mysqli_num_rows($namecheck)!=1)
  {
    echo "5: Either no user with name or more than one";
    exit();
  }

  $stmt = $con->prepare('SELECT * FROM users WHERE username LIKE ?;');
  $stmt->bind_param("s", $username);
  if ($stmt->execute()) {
    $result = $stmt->get_result();
    $row = $result->fetch_assoc();
  }
  if ($row && password_verify($_POST['password'], $row['password'])) 
  {
    // Password is correct
    $_SESSION['username'] = $row['username'];
    echo "0";
  } 
  else 
  {
      // Incorrect password
      $_SESSION['username'] = '';
      echo "6: Incorrect password";
      exit();
  }
  $result->free_result();
?>