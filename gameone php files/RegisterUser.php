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
$age = $_POST["age"];


// Create connection

// Check connection


$namecheckquery = "SELECT  username  FROM players WHERE username= '".$username."'; ";
$namecheck=mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

if(mysqli_num_rows($namecheck)>0)
{
  echo"3: Name already exists";
  exit();
}

$salt = "\$5\$rounds=5000\$"."steamedhams".$username."\$";
$hash=crypt($password,$salt);
$insertuserquery="INSERT INTO players (username,age,hash,salt) VALUES ('".$username."','".$age."','".$hash."','".$salt."');";
mysqli_query($con,$insertuserquery) or die("4:Insert player query failed");


$insertuserquery2="INSERT INTO login (player_id,username,hash,salt)
SELECT id,username,hash,salt FROM players WHERE players.username= '".$username."'; ";

mysqli_query($con,$insertuserquery2) or die("6:Insert login2 query failed");


$insertuserquery3="INSERT INTO score_board (player_id)
SELECT id FROM players WHERE players.username= '".$username."'; ";

mysqli_query($con,$insertuserquery3) or die("6:Insert login7 query failed");

echo("0");
   
?> 