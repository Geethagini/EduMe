<?php
$servername = "localhost";
$server_username =  "root";
$server_password = "";
$dbName = "gameone";

$con = new mysqli($servername, $server_username, $server_password, $dbName);
if ($con->connect_error) {
  die("Connection failed: " . $con->connect_error);
}



$username= $_POST["name"];
$newscore= $_POST["score"];



// Create connection

// Check connection

$namecheckquery ="SELECT id,username FROM players WHERE username='".$username."';";


$namecheck=mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

if(mysqli_num_rows($namecheck)!=1)
{
  echo"5: Either no user with name, or more than one";
  exit();
}


$updatequery="UPDATE score_board  JOIN players ON score_board.player_id = players.id SET score_board.score ='$newscore' WHERE players.username='".$username."';";
mysqli_query($con,$updatequery) or die("7:Save query failed");
echo "0";

?> 