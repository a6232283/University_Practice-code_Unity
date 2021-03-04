<?php

//登入sql
$servername="localhost";
$username="root";
$passwd="";
$dbnam="topic";

$datetime = date ("Y-m-d H:i:s" ,
 mktime(date('H')+7,
  date('i'),
   date('s'),
    date('m'),
     date('d'),
      date('Y'))) ;


$id2=$_POST["id2"];
$id_name2=$_POST["id_name"];


$conn=new mysqli($servername,$username,$passwd,$dbnam);

//判斷是否登入成功
if($conn->connect_error){
    die("連接失敗".$conn->connect_error);
}
echo "連接成功"."<br>";

//查詢資料庫
$sql="SELECT id,time_1,id_name 
FROM game1 
Where id='" . $id2 . "','" . $datetime . "' , id_name='" . $id_name2 . "'" ;

$result=$conn->query($sql);

if($result -> num_rows < 0){
    echo "error";
}else {
    echo "創建紀錄";
    $sql="INSERT INTO game1(id,time_1,id_name)
    VALUES('" . $id2 . "' , 
    '" . $datetime . "' ,
    '" . $id_name2 . "')";

    if($conn->query($sql)===TRUE){
        echo "新增資料成功";
    }else{
        echo "Error: ".$sql . "<br>" .$conn->error;
    }

}

$conn->close();

?>