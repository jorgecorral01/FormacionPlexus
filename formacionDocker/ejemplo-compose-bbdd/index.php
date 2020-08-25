<?php

require_once __DIR__ . '/vendor/autoload.php';

$connectionParams = [
	'dbname' 	=> 'miBBDD',
	'user' 		=> getenv('MYSQL_USER'),
	'password' 	=> getenv('MYSQL_PASSWORD'),
	'host'		=> getenv('MYSQLHOST'),
	'driver'	=> 'pdo_mysql',
	];
	
$config = new \Doctrine\DBAL\Configuration();
$connection = \Doctine\DBAL\DrivenManager::getConnection($connectionParams, $config);

$users = $connection->fetchAll("SELECT id, name, lastname from users");

var_dumo($users);	