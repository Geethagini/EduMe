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
$x= $_POST["x"];
$y= $_POST["y"];
$z= $_POST["z"];


// Create connection

// Check connection

$namecheckquery = "SELECT  players.username FROM score_board INNER JOIN players ON score_board.player_id=players.id WHERE players.username= '".$username."'; ";
$namecheck=mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

if(mysqli_num_rows($namecheck)!=1)
{
  echo"5: Either no user with name, or more than one";
  exit();
}
$updatequery="UPDATE score_board  JOIN players ON score_board.player_id = players.id SET score_board.x ='$x', score_board.y ='$y',score_board.z ='$z' WHERE players.username='".$username."';";

mysqli_query($con,$updatequery) or die("7:Save query failed");
echo "0";

?> 