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


$namecheckquery = "SELECT  login.username,login.salt,login.hash FROM login INNER JOIN players ON login.player_id=players.id WHERE players.username= '".$username."'; ";;
$namecheck=mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

if(mysqli_num_rows($namecheck)!=1)
{
  echo"5: Either no user with name, or more than one";
  exit();
}

$existinginfo1=mysqli_fetch_assoc($namecheck);
$salt = $existinginfo1["salt"];
$hash = $existinginfo1["hash"];

$loginhash=crypt($password,$salt);
if($hash!=$loginhash)
{
    echo "6: Incorrect password";
    exit();
}
$namecheckquery2 = "SELECT score_board.score, score_board.x, score_board.y,score_board.z,score_board.level_id,score_board.the_level,players.health   FROM score_board INNER JOIN players ON score_board.player_id=players.id WHERE players.username= '".$username."'; ";;

$namecheck2=mysqli_query($con, $namecheckquery2) or die("2: Name check query failed");
$existinginfo=mysqli_fetch_assoc($namecheck2);
echo "0\t".$existinginfo["score"]."\t".$existinginfo["x"]."\t".$existinginfo["y"]."\t".$existinginfo["z"]."\t".$existinginfo["level_id"]."\t".$existinginfo["the_level"]."\t".$existinginfo["health"];
    
    
     



?> 