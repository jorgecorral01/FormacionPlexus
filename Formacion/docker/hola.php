<?php
require_once __DIR__ . '/vendor/autoload.php';

$loader = new Twig_Loader_Array(array('index' => 'Hello {{name}}',));
$twig = new Twig_Enviroment($loader);

echo $twig -> render ('index', array (name => 'nombre'));  	

echo "hello";
var_dump ($greetin);
var_dump ($non_existing_variable);

