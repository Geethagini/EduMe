<?php

$servername = "localhost";

$serverusername =  "root";

$serverpassword = "";

$dbName = "gameone";




//Make Connection

$conn = new mysqli($servername, $serverusername, $serverpassword, $dbName);

//Check Connection

if(!$conn){

   die("Connection Failed. ". mysqli_connect_error());

}



$sql = "SELECT username, x, y, z FROM players";

$result = mysqli_query($conn ,$sql);





if(mysqli_num_rows($result) > 0){

   //show data for each row

   while($row = mysqli_fetch_assoc($result)){

       echo"0\t".$row['username']."\t".$row['x']. "\t".$row['y']. "\t".$row['z'];

   }

}

?> 