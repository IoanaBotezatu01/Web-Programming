<?php
$dbServerName = "localhost";
$dbUsername = "root";
$dbPassword = "ioana";
$dbName = "lab6-web";
$connection = mysqli_connect($dbServerName, $dbUsername, $dbPassword, $dbName);
if ($connection === false) {
    die("ERROR: Could not connect." . mysqli_connect_error());
}