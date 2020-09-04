<?php
$servername = "localhost";
$server_username =  "root";
$server_password = "";
$dbName = "gameone";

$con = new mysqli($servername, $server_username, $server_password, $dbName);
if ($con->connect_error) {
  die("Connection failed: " . $con->connect_error);
}


      $username = $_POST["name"];
      $password = $_POST["password"];


// Create connection

// Check connection


$namecheckquery = "SELECT  username,salt,hash,score,x,y,z  FROM players WHERE username= '".$username."'; ";
$namecheck=mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

if(mysqli_num_rows($namecheck)!=1)
{
  echo"5: Either no user with name, or more than one";
  exit();
}

$existinginfo=mysqli_fetch_assoc($namecheck);
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

$loginhash=crypt($password,$salt);
if($hash!=$loginhash)
{
    echo "6: Incorrect password";
    exit();
}

echo "0\t".$existinginfo["score"]."\t".$existinginfo["x"]."\t".$existinginfo["y"]."\t".$existinginfo["z"];
    
    
     



?> 