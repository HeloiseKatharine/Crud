CREATE DATABASE cadastro_cliente;

USE cadastro_cliente;

CREATE TABLE clientes(

codigo INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT, 
nome VARCHAR(30) NOT NULL,
endereco VARCHAR(30) NOT NULL,
telefone VARCHAR(20) NOT NULL,
email VARCHAR(30) NOT NULL

);

CREATE TABLE usuarios(

nome VARCHAR(30) NOT NULL PRIMARY KEY,
senha VARCHAR(30) NOT NULL

);


INSERT INTO clientes (codigo, nome, endereco, telefone, email) VALUES 
(1, 'Maria Clara', 'Brasilia', 31575434, 'mariaclara@gmail.com'),
(2, 'João Pereira', 'Brasilia', 213154152314, 'joaopereira@gmail.com'),
(3, 'Rafaella Silva', 'São Paulo ', 455454545, 'rafaellasilva@gmail.com'),
(4, 'Gabriel Silva', 'Rio de janeiro', 453435435, 'gabrielsilva@gmail.com'),
(5, 'José', 'Belo Horizonte', 5454544545, 'jose@gmail.com'),
(6, 'Amanda', 'Rio de janeiro', 354359564645, 'amanda@gmail.com'),
(7, 'Igor', 'Florianopolis', 45435454545, 'igor@gmail.com');

INSERT INTO usuarios (nome, senha) VALUES
('Heloise', 'senha'), 
('Antonia', '0102'), 
('João', '123'), 
('Maria', 'senha1'); 




