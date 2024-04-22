<?php
if (filter_input(
  INPUT_POST,
  'belepesiAdatok',
  FILTER_VALIDATE_BOOLEAN,
  FILTER_NULL_ON_FAILURE
)) {
  //-- A kapott adatok feldolgozása required  
  $error = false;
  $errormessage = "";
  $username = htmlspecialchars(filter_input(INPUT_POST, 'username'));
  $password = htmlspecialchars(filter_input(INPUT_POST, 'InputPassword'));
  if ($username == null) {
    $error = true;
    $errormessage .= '<p>Nem megfelelő felhasználónév!</p>';
  } else if ($password == null) {
    $error = true;
    $errormessage .= '<p>Nem megfelelő Jelszó</p>';
  }
  if ($error) {
    echo $errormessage;
  } else if ($db->login($username, $password)) {
    $_SESSION['userid'] = $userid;
    $_SESSION['username'] = $username;
    $_SESSION['login'] = true;
    header("Location:index.php");
        
  } 
}
?>


<!--Login Start-->
<section class="h-100 gradient-form bg-login-img">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-lg-5 rounded">
        <div class="card border border-0 rounded-5 card-background-glasseffect text-white">  
              <div class="card-body p-md-5 mx-md-4">

                <div class="text-center">
                  <img src="./Img/logo.png" alt="logo">
                  <h4 class="mt-1 mb-5 pb-1">Mystic Realm</h4>
                </div>

                <form action="#" method="post">
                  <?php
                if($db->error)
                  echo' <div class="alert alert-danger" role="alert">
                  Invaild username/password, try again!
                </div>'
                ?>
                  <div class="form-outline mb-4">
                    <input type="text" id="username" name="username" aria-describedby="emailHelp" class="form-control" required />
                    <label class="form-label" for="username">Username</label>
                  </div>

                  <div class="form-outline mb-4">
                    <input type="password" id="InputPassword" name="InputPassword" class="form-control" required />
                    <label class="form-label" for="InputPassword">Password</label>
                  </div>

                  <div class="text-center pt-1 mb-5 pb-1">
                    <button class="btn btn-primary w-50" type="submit" name="belepesiAdatok" value="true">Login</button>
                  </div>

                  <div class="d-flex align-items-center justify-content-center pb-4">
                    <p class="mb-0 me-2">Don't have an account?</p>
                    <a href="index.php?loginswitch=register" class="btn btn-primary">Create new</a>
                  </div>
                  <div class="d-flex align-items-center justify-content-center">
                    <a target="_blank" href="https://www.facebook.com/"><i class="fa-brands fa-square-facebook fa-bounce icon-font"></i></a>
                    <a target="_blank" href="https://www.instagram.com/"><i class="fa-brands fa-instagram fa-bounce icon-font p-2"></i></a>
                    <a target="_blank" href="https://twitter.com/?lang=hu"><i class="fa-brands fa-x-twitter fa-bounce icon-font"></i></a>
                  </div>

                </form>

              </div>
        </div>
      </div>
    </div>
  </div>
</section>
<!--Login End-->