create database ReelNode;
use ReelNode;

CREATE TABLE peliculas (
    id_pelicula INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL,
    fecha_estreno DATE NOT NULL,
    descripcion VARCHAR(255),
    director VARCHAR(255),
    imagen MEDIUMBLOB,
    duracion VARCHAR(50)
);

CREATE TABLE network (
    id_network INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL
);

CREATE TABLE serie (
    id_serie INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL,
    fecha_estreno DATE NOT NULL,
    fecha_fin DATE,
    descripcion VARCHAR(255),
    director VARCHAR(255),
    imagen MEDIUMBLOB,
    cant_temporadas INT,
    id_network INT,
    FOREIGN KEY (id_network) REFERENCES network(id_network)
);

CREATE TABLE genero (
    id_genero INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL
);

CREATE TABLE genero_x_serie (
    id_gxs INT PRIMARY KEY AUTO_INCREMENT,
    id_genero INT,
    id_serie INT,
    FOREIGN KEY (id_genero) REFERENCES genero(id_genero),
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie)
);

CREATE TABLE genero_x_pelicula (
    id_gxp INT PRIMARY KEY AUTO_INCREMENT,
    id_genero INT,
    id_pelicula INT,
    FOREIGN KEY (id_genero) REFERENCES genero(id_genero),
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula)
);

CREATE TABLE rol (
    id_rol INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL
);

insert into rol(nombre)
values("Admin"), ("Usuario");
select * from rol;
CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    nombre_usuario VARCHAR(255) NOT NULL,
    password_usuario VARCHAR(255) not null,
    email_usuario varchar(255) not null,
    avatar MEDIUMBLOB,
    fecha_registro DATE NOT NULL,
    id_rol INT,
    FOREIGN KEY (id_rol) REFERENCES rol(id_rol)
);
insert into usuarios (nombre_usuario, password_usuario, email_usuario, id_rol)
values("admin", "123", "admin@gmail.com", 1),
("agustina", "123", "sanferdez@gmail.com", 1),
("santiago", "123", "agusbarbaresi@gmail.com", 1);

select u.nombre_usuario, u.password_usuario, u.email_usuario, r.nombre as nombre_rol
from usuarios u
inner join rol r on r.id_rol = u.id_rol;

CREATE TABLE visualizaciones_serie (
    id_visualizacion INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    id_serie INT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie)
);

CREATE TABLE visualizaciones_pelicula (
    id_visualizacion INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    id_pelicula INT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula)
);

create table comentarios_serie (
	id_comentario int primary key auto_increment,
	id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
    id_serie int,
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie),
    fecha_comentario DATE NOT NULL,
    texto varchar(255)
);
create table comentarios_peli (
	id_comentario int primary key auto_increment,
	id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario),
    id_serie int,
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie),
    fecha_comentario DATE NOT NULL,
    texto varchar(255)
);
create table calificaciones_serie(
	id_calificaciones int primary key auto_increment,
    calificacion int
);
create table calificaciones_peliculas(
	id_calificaciones int primary key auto_increment,
    calificacion int
);