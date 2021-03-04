<?php

header('refresh: 5;url="http://localhost:8080/text.php"');


//登入sql
$servername="localhost";
$username="root";
$passwd="";
$dbnam="topic";
$conn=new mysqli($servername,$username,$passwd,$dbnam);

//判斷是否登入成功
if($conn->connect_error){
    die("連接失敗".$conn->connect_error);
}
echo "連接成功"."<br>";

$sql="SELECT id,time_1,id_name FROM game1";
$result=$conn->query($sql);

if($result -> num_rows > 0){
    while($row = $result -> fetch_assoc()){
        echo "時間:" .$row["time_1"],
        "&nbsp;&nbsp;,&nbsp;&nbsp;設備: ".$row["id_name"],
        "&nbsp;&nbsp;,&nbsp;&nbsp;遊戲紀錄: ".$row["id"] ."<br>";
    }
}
$conn->close();



?>