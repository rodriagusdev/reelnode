/*
Cosas que agregue: 
1) Tabla de calificaciones_peliculas y calificaciones_series modificadas para que un usuario solo pueda calificar una vez una pelicula. Chequear
si se desea hacer auditoria sobre esto, pero hacerlo a traves de un trigger, no en el procedimiento.
2) Implementacion de calificaciones a peliculas y series.
3) Renombrada imagen a IMAGENURL.

Cosas que necesitan verse:
1) Algunas operaciones tienen campos desactualizados o invalidos.
2) En varios casos, un procedimiento de creacion (por ej de una pelicula), inserta datos en una tabla de auditorias
y, a su vez, existe un trigger que detecta inserciones. Es decir, se hacen dos registros a auditorias. 
Eliminar las inserciones a auditorias desde los procedimientos y usar triggers para eso. (Por ahora, lineas de insercion en procedimientos estan comentadas)
Linea 524 hay comentarios de ejemplo de lo que se menciona

*/

create database ReelNode;
use ReelNode;

-- Tablas -----------------------------------------------
CREATE TABLE network (
    id_network INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL unique
);

INSERT INTO network (nombre) VALUES ('Netflix'), ('HBO'), ('Disney+'), ('Amazon Prime Video'), ('Hulu'), ('Apple TV+'), ('Paramount+'), ('Peacock'), ('Starz'), ('Showtime'), ('CBS All Access'), ('Warner Bros.'), ('Universal Pictures'), ('20th Century Studios'), ('Sony Pictures'), ('Lionsgate'), ('MGM'), ('A24'), ('BBC'), ('AMC'), ('FX'), ('CW'), ('NBC'), ('ABC'), ('Fox'), ('Sky'), ('ITV'), ('Channel 4'), ('Blumhouse Productions'), ('Legendary Entertainment'), ('New Line Cinema'), ('DreamWorks Animation'), ('Pixar Animation Studios'), ('Marvel Studios'), ('Lucasfilm'), ('DC Films'), ('Focus Features'), ('Annapurna Pictures'), ('STX Entertainment'), ('Neon'), ('Orion Pictures'), ('Miramax'), ('The Weinstein Company'), 
('Lionsgate Films'), ('TriStar Pictures'), ('Searchlight Pictures'), ('Sony Pictures Animation'), ('Blue Sky Studios'), ('Illumination Entertainment'), ('Skydance Media');

CREATE TABLE peliculas (
    id_pelicula INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL,
    fecha_estreno DATE NOT NULL,
    descripcion VARCHAR(255),
    director VARCHAR(255),
    imagenURL VARCHAR(255),
    duracion int,
    trailerURL varchar(255),
    id_network int,
    foreign key(id_network) references network(id_network)
);
select * from peliculas;
INSERT INTO peliculas (nombre, fecha_estreno, descripcion, director, duracion, imagenURL, trailerURL, id_network) VALUES
('Robot Salvaje', '2024-09-20', 'Una aventura animada sobre un robot que aprende a convivir con la naturaleza y proteger a los animales.', 'Chris Sanders', 102, 
"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT7Nq-MCAEoQRCE-1kfgtWcMPiiy4-YIz3bYzCq8lfMZvUiylT62cX56yU3fohZL3Ot00ywMg", "https://www.youtube.com/watch?v=UPgUIORqja4", 33),

('Duna: Parte Dos', '2024-03-01', 'La continuación épica de la historia de Paul Atreides mientras busca venganza contra los conspiradores que destruyeron su familia.', 'Denis Villeneuve', 166, 
"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcR1HYYqIoovqLVr7DQU9tevo_bMrzQqJ7LQiVnjyK1x5BUHqrjFB_JDtftcR1Sxo1cPE0fPmg", "https://www.youtube.com/watch?v=ni55SHApxhA", 12),

('Oppenheimer', '2023-07-21', 'La historia del físico J. Robert Oppenheimer y su papel en el desarrollo de la bomba atómica.', 'Christopher Nolan', 180, 
"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQ8FFJNBaIXvhEwqXXw40rYYDci8jPlYxWfy9082flliYoZ-SqqZjy0az-G5rIWuSJp2pn7xQ", "https://www.youtube.com/watch?v=uYPbbksJxIg", 15),

('Barbie', '2023-07-21', 'Barbie comienza a cuestionarse su mundo perfecto y emprende un viaje al mundo real.', 'Greta Gerwig', 114, 
"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcROuK_Bl8jrLUP7fo3hsDC4XC2AC1WR1CAXS3G1SVqDPZE0pgFTQKnr8P2_cKmRuXg03nPE", "https://www.youtube.com/watch?v=pBk4NYhWNMM", 33),

('Spider-Man: Across the Spider-Verse', '2023-06-02', 'Miles Morales viaja por el multiverso y se enfrenta a nuevas versiones de Spider-Man.', 'Joaquim Dos Santos', 140, 
"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRDDvJ0zhGxVySz3RjLa35ukjpctxW41KzD3VQ56VzSEX2lB5WHZ0le10IjuI8ZJ9cd5CeZpA", "https://www.youtube.com/watch?v=cqGjhVJWtEg", 46),

('Napoleón', '2023-11-22', 'La historia del ascenso y caída del legendario líder militar francés Napoleón Bonaparte.', 'Ridley Scott', 158, 
"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRyxzp1By7PTDvs2TlNoM9lzGdxuIm12VnG0EFLKQ8uNt4eYugH-Ctw5Zj_1wCewUcDNhd-", "https://www.youtube.com/watch?v=OAZWXUkrjPc", 15),

('Misión Imposible: Sentencia Mortal - Parte Uno', '2023-07-12', 'Ethan Hunt y su equipo enfrentan su misión más peligrosa para salvar el mundo.', 'Christopher McQuarrie', 163, 
"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcR34_otMSvSpe1Nn8Iip4kpkcaAHrUGaIITwQYC9iRIL4q34rHhTY2cTYrbRe303iD5fdsm", "https://www.youtube.com/watch?v=XoDmKCZBeeI", 14),

('Wonka', '2023-12-15', 'La historia del joven Willy Wonka y cómo conoció a los Oompa-Loompas.', 'Paul King', 116, 
"https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRrtRJVKVEsmsaq7eHik9Euw6hBfwEAwg_MmlBnp9013_31mmP6Ehp5rDyQ8-Ycr6ePyHVR", "https://www.youtube.com/watch?v=otNh9bTjXWg", 11),

('Los Asesinos de la Luna', '2023-10-20', 'Basada en hechos reales, narra los asesinatos de miembros de la Nación Osage en la década de 1920.', 'Martin Scorsese', 206, 
"https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcR34_otMSvSpe1Nn8Iip4kpkcaAHrUGaIITwQYC9iRIL4q34rHhTY2cTYrbRe303iD5fdsm", "https://www.youtube.com/watch?v=57yrWZt5z2g", 15),

('Elemental', '2023-06-16', 'En una ciudad donde los elementos conviven, una joven de fuego y un chico de agua descubren cuánto tienen en común.', 'Peter Sohn', 102, 
"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQfij08n5L5v7WYqFwRfe9aC71gZkl7EBjmkmwGOc1rFc0BCv3S6K-zvhG8BJiWBBlWwEod", "https://www.youtube.com/watch?v=hXzcyx9V0xw", 32);

CREATE TABLE serie (
    id_serie INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL,
    fecha_estreno DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    descripcion VARCHAR(255),
    director VARCHAR(255),
    imagenURL VARCHAR(255),
    cant_temporadas INT,
    trailerURL varchar(255),
    id_network INT,
    FOREIGN KEY (id_network) REFERENCES network(id_network)
);

INSERT INTO serie (
    nombre, fecha_estreno, fecha_fin, descripcion, director, imagenURL, cant_temporadas, trailerURL, id_network
) VALUES
('Breaking Bad', '2008-01-20', '2013-09-29', 'Un profesor de química se convierte en fabricante de metanfetamina.', 'Vince Gilligan', "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOcWkpWG_NRrU2M8-WB8EbEcJk7smhdrY1eO0ttKXm0bo2ooOEWxk3zBSbsFrSgSJh2OEKOQ", 5, "https://www.youtube.com/watch?v=HhesaQXLuRY", 1),
('Stranger Things', '2016-07-15', '2025-01-01', 'Un grupo de niños enfrenta fuerzas sobrenaturales en su pequeño pueblo.', 'The Duffer Brothers', "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSb8xupi_c_ornYk2Y4PaDKIx20Xy9PS1bshOu73qVKojzLmkpy-U2MC8R2jJZCFbU_mgTH", 5, "https://www.youtube.com/watch?v=b9EkMc79ZSU", 2),
('Game of Thrones', '2011-04-17', '2019-05-19', 'Nobles luchan por el Trono de Hierro en un mundo medieval fantástico.', 'David Benioff y D.B. Weiss', "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUgffoihYPEcEZH4D24OA-1Hnwz-SRN4DOmcABM6nro6l2D_yLYjNNFy_pOpOC9ABjXY2_", 8, "https://www.youtube.com/watch?v=KPLWWIOCOOQ", 3),
('The Office', '2005-03-24', '2013-05-16', 'Una mirada divertida a la vida diaria en una oficina.', 'Greg Daniels', "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQ00mxCZs-9YF6bPtPBe-dlgo6cnxI6klO2hHMtiQJpC_vHKQuNQKEB627kLUXoHXhFnwdBVw", 9, "https://www.youtube.com/watch?v=-C2z-nshFts", 4),
('The Mandalorian', '2019-11-12', '2023-04-19', 'Un cazarrecompensas viaja por la galaxia tras la caída del Imperio.', 'Jon Favreau', "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPz4zyHFlnCZr0RuXDKfJOhPB83w0jh_RJ1utNuTGMd1-apSkHVSGEsfZ17_D31rtkhQpZ", 3, "https://www.youtube.com/watch?v=aOC8E8z_ifw", 5),
('Dark', '2017-12-01', '2020-06-27', 'Un misterio temporal que conecta a cuatro familias en Alemania.', 'Baran bo Odar', "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcS6ApenbR-AZkjJySI-VBzjMJYPWFoqUgCxfkGyvXpCru89imX7jzAdmaDSgEVOY4MIDnR_", 3, "https://www.youtube.com/watch?v=ESEUoa-mz2c", 2),
('Sherlock', '2010-07-25', '2017-01-15', 'Versión moderna de las aventuras del detective Sherlock Holmes.', 'Steven Moffat', "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSKAffHEy-QCEkW_rqDKlHTcHELw7CBuxM3hi-vE7LFJM7yFZ4Msgeg75Kh1988BBF4Lrf21A", 4, "https://www.youtube.com/watch?v=y9ZouUyPKx8", 1),
('The Crown', '2016-11-04', '2023-12-14', 'Relato biográfico de la vida de la reina Isabel II.', 'Peter Morgan', "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzpy-NQOVd2iA7FUG2bx8z-qF23EUOtE2xA6Q4lBb4klcBJ2y7dz0WEKyiP6QEfYosy9EV", 6, "https://www.youtube.com/watch?v=JWtnJjn6ng0", 3),
('Peaky Blinders', '2013-09-12', '2022-04-03', 'Una familia de gánsteres en la Inglaterra de posguerra.', 'Steven Knight', "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSM1RfnNxjkJjv6su_9EVi-AqVTvMyaiWergB9Vh_utvs1n6ZYTWygADBA1Xzwx0kxDfH5S", 6, "https://www.youtube.com/watch?v=oVzVdvGIC7U", 4),
('Loki', '2021-06-09', '2023-10-05', 'El dios del engaño altera las líneas temporales del multiverso.', 'Kate Herron', "https://pics.filmaffinity.com/Loki_Serie_de_TV-120729175-large.jpg", 2, "https://www.youtube.com/watch?v=nW948Va-l10", 5);

CREATE TABLE genero (
    id_genero INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(255) NOT NULL
);
select * from genero;
INSERT INTO genero (nombre) VALUES
('Action'),
('Adventure'),
('Comedy'),
('Drama'),
('Horror'),
('Science Fiction'),
('Fantasy'),
('Thriller'),
('Romance'),
('Mystery'),
('Crime'),
('Animation'),
('Documentary'),
('Family'),
('Musical'),
('Western'),
('War'),
('Biography'),
('History'),
('Sport'),
('Superhero'),
('Fantasy Comedy'),
('Romantic Comedy'),
('Sci-Fi Horror'),
('Psychological Thriller');

CREATE TABLE genero_x_serie (
    id_gxs INT PRIMARY KEY AUTO_INCREMENT,
    id_genero INT,
    id_serie INT,
    FOREIGN KEY (id_genero) REFERENCES genero(id_genero) ON DELETE CASCADE, -- Asi no tengo que añadir logica adicional al borrar una serie
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie) ON DELETE CASCADE
);

CREATE TABLE genero_x_pelicula (
    id_gxp INT PRIMARY KEY AUTO_INCREMENT,
    id_genero INT,
    id_pelicula INT,
    FOREIGN KEY (id_genero) REFERENCES genero(id_genero) ON DELETE CASCADE, -- Asi no tengo que añadir logica adicional al borrar una serie
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula) ON DELETE CASCADE
);

CREATE TABLE rol (
    id_rol INT PRIMARY KEY AUTO_INCREMENT,
    tipo_rol VARCHAR(100) NOT NULL
);

insert into rol (tipo_rol)
values ("Admin"), ("Usuario");

CREATE TABLE usuario (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    nombre_usuario VARCHAR(255) unique not null,
    email_usuario varchar(255)  unique not null,
    password_usuario varchar (255) not null,
    avatar varchar(255),
    fecha_registro DATE NOT NULL,
    id_rol INT,
    FOREIGN KEY (id_rol) REFERENCES rol(id_rol)
);

select* from peliculas;

insert into usuario (nombre_usuario, email_usuario, password_usuario, avatar, fecha_registro, id_rol)
values("rodri", "rodri@gmail.com", "1", null, now(), 1),
("san", "san@gmail.com", "2", null, now(), 1),
("agus", "agus@gmail.com", "3", null, now(), 1);

CREATE TABLE visualizaciones_serie (
    id_visualizacion INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    id_serie INT,
    fecha_visualizacion date,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario) on delete cascade,
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie) on delete cascade
);

CREATE TABLE visualizaciones_pelicula (
    id_visualizacion INT PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT,
    id_pelicula INT,
    fecha_visualizacion date,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario) on delete cascade,
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula) on delete cascade
);

create table comentarios_serie (
	id_comentario int primary key auto_increment,
	id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario) on delete cascade,
    id_serie int,
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie) on delete cascade,
    fecha_comentario DATE NOT NULL,
    texto varchar(255)
);
create table comentarios_peli (
	id_comentario int primary key auto_increment,
	id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario) on delete cascade,
    id_pelicula int,
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula) on delete cascade,
    fecha_comentario DATE NOT NULL,
    texto varchar(255)
);
create table calificaciones_serie(
	id_calificaciones int primary key auto_increment,
    calificacion int,
    id_serie int,
    id_usuario INT NOT NULL,
    
    -- Evita duplicados: un usuario no puede calificar la misma serie más de una vez
    UNIQUE KEY uq_usuario_serie (id_usuario, id_serie),

    FOREIGN KEY (id_serie) REFERENCES serie(id_serie)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
        ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE calificaciones_peliculas (
    id_calificacion INT AUTO_INCREMENT PRIMARY KEY,
    calificacion TINYINT NOT NULL,
    id_pelicula INT NOT NULL,
    id_usuario INT NOT NULL,
    
    -- Evita duplicados: un usuario no puede calificar la misma película más de una vez
    UNIQUE KEY uq_usuario_pelicula (id_usuario, id_pelicula),

    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
        ON DELETE CASCADE ON UPDATE CASCADE
);

create table permisos(
	id_permiso int primary key auto_increment,
    tipo_permiso varchar(255),
    id_usuario int,
    foreign key (id_usuario) references usuario(id_usuario)
);

create table permisos_usuarios(
id_permiso_X_usuario int primary key auto_increment,
id_usuario int,
id_permiso int,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_permiso) references permisos(id_permiso)
);
create table rol_x_usuario(
id_rol_x_usuario int primary key auto_increment,
id_usuario int,
id_rol int,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_rol) references rol(id_rol)
);

-- Auditorias    ------------------------------------------------------------

create table auditoria_login(
	id_auditoria int primary key auto_increment,
    id_usuario int,
    fecha datetime not null,
    exitoso boolean,
    foreign key (id_usuario) references usuario(id_usuario)
);

CREATE TABLE auditoria_roles (
    id_auditoria int primary key auto_increment,
    id_usuario int,
    rol_anterior int,
    rol_nuevo int,
    fecha datetime not null,
    foreign key (id_usuario) references usuario(id_usuario)
);

CREATE TABLE auditoria_visualizaciones (
    id_auditoria int primary key auto_increment,
    id_usuario int,
    id_serie int null,
    id_pelicula int null,
    fecha datetime not null,
    foreign key (id_usuario) references usuario(id_usuario),
    foreign key (id_serie) references serie(id_serie),
    foreign key (id_pelicula) references peliculas(id_pelicula)
);

-- 2. Películas y Series (Admin): ABM, carga de imágenes, importación/exportación JSON.
create table auditoria_peliculas_serie(
	id_auditoria int auto_increment primary key,
    tabla_afectada varchar(255),
    accion varchar(255),
    id_registro int,
    fecha_hora datetime
);

create table auditoria_comentarios_usuario (
    id_auditoria int auto_increment primary key,
    tabla_afectada varchar(50),
    accion varchar(20),
    id_registro int,
    id_usuario int,
    fecha_hora datetime,
    FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
);

-- Indices --------------------------------------------------

create index idx_usuario_email on usuario(email_usuario); -- Índice para acelerar búsquedas por email
create index idx_usuario_rol on usuario(id_rol); -- Índice para buscar por rol

-- 4. Visualizaciones (Usuario común): registrar visualización y consultar historial.
-- índice para buscar visualizaciones por usuario
create index idx_visualizaciones_usuario_serie on visualizaciones_serie(id_usuario);
create index  idx_visualizaciones_usuario_pelicula on visualizaciones_pelicula(id_usuario);

-- índice para buscar visualizaciones por serie/película
create index idx_visualizaciones_serie on visualizaciones_serie(id_serie);
create index  idx_visualizaciones_pelicula on visualizaciones_pelicula(id_pelicula);

create index idx_peliculas_nombre on peliculas(nombre);
create index idx_series_nombre on serie(nombre);
create index idx_serie_network on serie(id_network);

create index idx_comentarios_usuario_peli on comentarios_peli(id_usuario);
create index idx_comentarios_usuario_serie on comentarios_serie(id_usuario);

-- Procedimientos --------------------------------------------------------------
-- Insertar un usuario
DELIMITER //
CREATE PROCEDURE sp_insertar_usuario(
    IN p_nombre VARCHAR(255),
    IN p_password VARCHAR(255),  
    IN p_id_rol INT,
    in p_email varchar(255)
)
BEGIN 
    INSERT INTO usuario(nombre_usuario, password_usuario, email_usuario, fecha_registro, id_rol)
    VALUES(p_nombre, p_password, p_email, CURDATE(), p_id_rol);
END //
DELIMITER ;

-- Handler para el login
DELIMITER //
CREATE PROCEDURE login_user_handler(
    IN p_nombre VARCHAR(255),
    IN p_password VARCHAR(255)
)
BEGIN
    DECLARE v_id INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN 
        SELECT "Ocurrio un error durante el login" AS mensaje;
    END;
    
    SELECT id_usuario
    INTO v_id
    FROM usuario
    WHERE nombre_usuario = p_nombre AND password_usuario = p_password;
    
    IF v_id IS NULL THEN
        SELECT "usuario o contraseña incorrectos" AS mensaje;
    ELSE 
        SELECT "login correcto" AS mensaje, v_id AS id_usuario;
    END IF;
END //
DELIMITER ;

-- 1. Login inicial con validación de credenciales y carga de rol.

DELIMITER //
create procedure login_user(
	in p_email varchar(255),
    in p_password varchar(255)
)
begin
	select u.id_usuario, u.nombre_usuario, r.tipo_rol
    from usuario u
    join rol r on u.id_rol = r.id_rol
    where u.email_usuario = p_email and u.password_usuario =md5(p_password); -- compara con hash
end //
DELIMITER ;

-- actualizar usuario
DELIMITER //
create procedure sp_actualizar_usuario(
	in p_id_usuario int,
    in p_nombre varchar(255),
    in p_email varchar(255)
)
begin 
	start transaction;
    update usuario
    set nombre_usuario = p_nombre,
        email_usuario = p_email
	where id_usuario = p_id_usuario;
    commit;
end //
DELIMITER ;

-- eliminar usuario
DELIMITER //
create procedure sp_eliminar_usuario(
	in p_id_usuario int
)
begin
	start transaction;
    delete from usuario
    where id_usuario = p_id_usuario;
	commit;
end //
DELIMITER ;

DELIMITER //
create procedure sp_cambiar_rol(
IN p_id_usuario INT,
    IN p_id_nuevo_rol INT
)
BEGIN
    DECLARE v_rol_anterior INT;

    START TRANSACTION;

    -- Obtener rol anterior
    SELECT id_rol INTO v_rol_anterior
    FROM usuario
    WHERE id_usuario = p_id_usuario;

    -- Actualizar rol
    UPDATE usuario
    SET id_rol = p_id_nuevo_rol
    WHERE id_usuario = p_id_usuario;

    INSERT INTO auditoria_roles(id_usuario, rol_anterior, rol_nuevo, fecha)
    VALUES (p_id_usuario, v_rol_anterior, p_id_nuevo_rol, NOW());

    COMMIT;
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_modificar_rol_usuario(
    IN p_nombre_usuario VARCHAR(255),
    IN p_id_rol INT
)
BEGIN
    UPDATE usuario
    SET id_rol = p_id_rol
    WHERE nombre_usuario = p_nombre_usuario;
END //

-- Procedimiento almacenado para registrar visualización
DELIMITER //
create procedure sp_registrar_visualizaciones(
 in p_id_usuario int,
 in p_id_serie int,
 in p_id_pelicula int
)
begin
	declare exit handler for sqlexception
    begin 
		rollback;
        select "error al registrar la visualizacion" as mensaje;
	end;
    
    start transaction;
    
    if p_id_serie is not null then
		insert into visualizaciones_serie(id_usuario, id_serie)
        values (p_id_usuario, p_id_serie);
	elseif p_id_pelicula is not null then
		insert into visualizaciones_pelicula(id_usuario, id_pelicula)
		values (p_id_usuario, p_id_pelicula);
   end if; 
    
    /*insert into auditoria_visualizaciones(id_usuario, id_serie, id_pelicula, fecha)
    values (p_id_usuario, p_id_serie, p_id_pelicula, NOW());
    MEJOR SI ESTO SE USA EN UN TRIGGER DE INSERCION EN LA TABLA DE VISUALIZACIONES
    */
    
    commit;
    select "Visualización registrada correctamente" as mensaje;
end //
DELIMITER ;

-- Procedimiento almacenado para consultar historial
/*
!!! Mejor esperar a que este bien terminado lo anterior antes de lidiar con el historial,
puede producir problemas hasta que no este implementado.

DELIMITER //
create procedure sp_consultar_historial(
	in p_id_usuario int
)
begin
	select "serie" as tipo, s.nombre as item, vs.id_visualizacion, vs.id_usuario, av.fecha
    from visualizaciones_serie vs
    join serie s on vs.id_serie = s.id_serie
    left join auditoria_visualizaciones av on av.id_usuario = vs.id_usuario and av.id_serie = vs.id_serie
    where vs.id_usuario = p_id_usuario
    
    union all
    
    select "pelicula" as tipo, p.nombre as item, vp.id_visualizacion, vp.id_usuario, av.fecha
    from visualizaciones_pelicula vp
    join peliculas p on vp.id_pelicula = p.id_pelicula
    left auditoria_visualizaciones av on av.id_usuario = vp.id_usuario and av.id_pelicula = vp.id_pelicula
    where vp.id_usuario = p_id_usuario
    
    order by fecha desc;
end;
DELIMITER ;
*/

/*
-- Función para contar visualizaciones de un usuario
DELIMITER //
create function fn_total_visualizaciones(p_id_usuario int) 
returns int
deterministic
begin
    declare total int default 0;
    declare total_peliculas int default 0;

    select COUNT(*) into total
    from visualizaciones_serie
    where id_usuario = p_id_usuario;

    select COUNT(*) into total_peliculas
    from visualizaciones_pelicula
    where id_usuario = p_id_usuario;

    set total = total + total_peliculas;

    return total;
end //
DELIMITER ;

*/
-- 6. Reportes: Admin → estadísticas generales, 
-- Usuario común → historial personal. Exportables a PDF.

/*DELIMITER //
create procedure sp_reporte_admin()
begin
	select count(*) as total_usuarios from usuario;
    
    -- peliculas mas vistas 
    select p.nombre, count(v.id_pelicula) as vistas
    from visualizaciones_pelicula v 
    join peliculas p on v.id_pelicula = p.id_pelicula
    group by p.nombre
    order by vistas desc
    limit 5;
    
    -- Series más vistas
    select s.nombre, count(v.id_serie) as vistas
    from visualizaciones_serie v
    join serie s on v.id_serie = s.id_serie
    group by s.nombre
    order by vistas desc
    limit 5;
end //
DELIMITER ;
-- 
DELIMITER //
create procedure sp_reporte_usuario()
begin
-- Historial de películas vistas
	select p.nombre, v.id_visualizaciones, v.id_usuario, v.id_pelicula
    from vizualizaciones_peliculas v
    join peliculas p on v.id_pelicula = p.id_pelicula 
    where v.id_usuario = p_id_usuario;
    
    -- Historial de series vistas
    select s.nombre, v.id_visualizaciones, v.id_usuario, v.id_serie
    from visualizaciones_serie v
    join serie s on v.id_serie = s.id_serie
    where v.id_usuario = p.id_usuario;
    
    -- total de visualizaciones 
    select fn_total_visualizaciones(p_id_usuario) as total_visualizaciones;
end //
DELIMITER ;
*/

DELIMITER //
CREATE TRIGGER trg_insert_pelicula
AFTER INSERT ON peliculas
FOR EACH ROW
BEGIN
    INSERT INTO auditoria_peliculas_serie(
        tabla_afectada, accion, id_registro, fecha_hora 
    )
    VALUES (
        'peliculas', 'INSERT', NEW.id_pelicula, NOW()
    );
END //
DELIMITER ;

-- Procedimientos almacenados 
-- Alta de película
DELIMITER //
CREATE PROCEDURE sp_insertar_pelicula(
    IN p_id_usuario INT,
    IN p_nombre VARCHAR(255),
    IN p_fecha DATE,
    IN p_descripcion VARCHAR(255),
    IN p_director VARCHAR(255),
    IN p_duracion int,
    IN p_imagenURL VARCHAR(255),
    IN p_trailerURL VARCHAR(255),
    in p_id_network int,
    OUT p_id_pelicula INT
)
BEGIN
    START TRANSACTION;

    INSERT INTO peliculas(nombre, fecha_estreno, descripcion, director, duracion, imagenURL, trailerURL, id_network)
    VALUES(p_nombre, p_fecha, p_descripcion, p_director, p_duracion, p_imagenURL, p_trailerURL, p_id_network);
    -- EJEMPLO DE INSERCION EN AUDITORIA QUE TAMBIEN OCURRE EN trg_insert_pelicula, el trigger arriba de este procedimiento. 
    -- Genera doble insercion. Deben borrarse todas las auditorias que se encuentren en procedimientos. Para inserciones en auditorias SOLO usar triggers.alter
    
    /*
    INSERT INTO auditoria_peliculas_serie(tabla_afectada, accion, id_registro, fecha_hora, detalle, id_usuario)
    VALUES ('peliculas', 'INSERT', LAST_INSERT_ID(), NOW(), p_nombre, p_id_usuario);
	*/
    
    -- Necesito obtener el ultimo ID para referirme a la pelicula y poder ingresar multiples generos
    SET p_id_pelicula = LAST_INSERT_ID();
    
    COMMIT;
END //
DELIMITER ;

-- Actualizar película

DELIMITER //
CREATE PROCEDURE sp_actualizar_pelicula(
    IN p_id INT,
    IN p_nombre VARCHAR(255),
    IN p_fecha_estreno DATE,
    IN p_descripcion VARCHAR(255),
    IN p_director VARCHAR(255),
    IN p_imagenURL VARCHAR(255),
    IN p_duracion int,
    IN p_trailerURL VARCHAR(255)
)
BEGIN
    START TRANSACTION;

    UPDATE peliculas
    SET nombre = p_nombre,
        fecha_estreno = p_fecha_estreno,
        descripcion = p_descripcion,
        director = p_director,
        imagenURL = p_imagenURL,
        duracion = p_duracion,
        trailerURL = p_trailerURL
    WHERE id_pelicula = p_id;

	/*
    INSERT INTO auditoria_peliculas_serie(tabla_afectada, accion, id_registro, fecha_hora, detalle, id_usuario)
    VALUES ('peliculas', 'UPDATE', p_id, NOW(), p_nombre, p_id_usuario);
	*/
    delete from genero_x_pelicula where id_pelicula = p_id;

    COMMIT;
END //
DELIMITER ;

-- Eliminar película con transacción
DELIMITER //
create procedure sp_eliminar_pelicula(
  IN p_id INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 'Error al eliminar la película' AS mensaje;
    END;

    START TRANSACTION;

    -- Eliminar dependencias
    DELETE FROM comentarios_peli WHERE id_pelicula = p_id;
    DELETE FROM visualizaciones_pelicula WHERE id_pelicula = p_id;
    DELETE FROM calificaciones_peliculas WHERE id_pelicula = p_id;

    -- Eliminar película
    DELETE FROM peliculas WHERE id_pelicula = p_id;
 
	/*
    INSERT INTO auditoria_peliculas_serie(tabla_afectada, accion, id_registro, fecha_hora, detalle)
    VALUES ('peliculas', 'DELETE', p_id, NOW(), 'Eliminada en cascada');
    */
    
    COMMIT;
    SELECT 'Película eliminada correctamente' AS mensaje;
end //
DELIMITER ;

-- 5. Comentarios (Usuario común): ingresar comentarios de texto, verlos, Admin puede eliminarlos.

-- Procedimiento almacenado
DELIMITER //
create procedure sp_usuario_insertar_comentario_pelicula(
    in p_id_usuario int,
    in p_id_pelicula int,
    in p_texto varchar(255)
)
begin
    insert into comentarios_peli(id_usuario, id_pelicula, fecha_comentario, texto)
    values(p_id_usuario, p_id_pelicula, NOW(), p_texto);

	/*
    insert into auditoria_comentarios_usuario(tabla_afectada, accion, id_registro, id_usuario, fecha_hora, detalle)
    values('comentarios_peli', 'INSERT', last_insert_id(), p_id_usuario, now(), p_texto);
    */
    
end //
DELIMITER ;

DELIMITER //
create procedure sp_usuario_insertar_comentario_serie(
    in p_id_usuario int,
    in p_id_serie int,
    in p_texto varchar(255)
)
begin
    insert into comentarios_serie(id_usuario, id_serie, fecha_comentario, texto)
    values(p_id_usuario, p_id_serie, now(), p_texto);

	/*
    insert into auditoria_comentarios_usuario(tabla_afectada, accion, id_registro, id_usuario, fecha_hora, detalle)
    values('comentarios_serie', 'INSERT', last_insert_id(), p_id_usuario, now(), p_texto);
    */
end //
DELIMITER ;

DELIMITER //
create procedure sp_usuario_consultar_comentarios(in p_id_usuario int)
begin
    select 'PELICULAS' as tipo, c.texto, c.fecha_comentario, c.id_comentario
    from comentarios_peli c
    where c.id_usuario = p_id_usuario
    union all
    select 'SERIES' as tipo, c.texto, c.fecha_comentario, c.id_comentario
    from comentarios_serie c
    where c.id_usuario = p_id_usuario
    order by fecha_comentario desc;
end //
DELIMITER ;
select * from usuario;
DELIMITER //
CREATE PROCEDURE sp_listar_usuarios() -- procedimiento para traer todos los usuarios con su rol
BEGIN
    SELECT 
		u.id_usuario,
        u.nombre_usuario, 
        u.password_usuario, 
        u.email_usuario,
        u.fecha_registro,
        u.avatar,
        r.tipo_rol AS nombre_rol
    FROM usuario u
    INNER JOIN rol r ON r.id_rol = u.id_rol;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_listar_peliculas()
BEGIN
    SELECT 
        p.id_pelicula,
        p.nombre,
        p.fecha_estreno,
        p.director,
        p.descripcion,
        p.imagenURL,
        p.duracion,
        p.trailerURL,
        p.id_network,
        GROUP_CONCAT(gxp.id_genero) AS generos
    FROM peliculas p
    LEFT JOIN genero_x_pelicula gxp ON gxp.id_pelicula = p.id_pelicula
    GROUP BY p.id_pelicula;
END //
DELIMITER ;

select * from peliculas

DELIMITER //
CREATE PROCEDURE sp_eliminar_pelicula_sin_trasaccion(IN p_id INT)
BEGIN
    DELETE FROM peliculas
    WHERE id_pelicula = p_id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_actualizar_password(
    IN p_nombre_usuario VARCHAR(255),
    IN p_email VARCHAR(255),
    IN p_nueva_password VARCHAR(255)
)
BEGIN
    UPDATE usuario
    SET password_usuario = p_nueva_password
    WHERE nombre_usuario = p_nombre_usuario
      AND email_usuario = p_email;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_insertar_serie(
    IN p_nombre VARCHAR(255),
    IN p_fecha_estreno DATE,
    IN p_fecha_fin DATE,
    IN p_descripcion TEXT,
    IN p_director VARCHAR(255),
    IN p_imagenURL VARCHAR(255),
    IN p_cant_temporadas INT,
    IN p_id_network INT,
    IN p_trailerURL VARCHAR(255),
    OUT p_id_serie int
)
BEGIN
    START TRANSACTION;

    INSERT INTO serie(nombre, fecha_estreno, fecha_fin, descripcion, director, imagenURL, cant_temporadas, id_network, trailerURL)
    VALUES(p_nombre, p_fecha_estreno, p_fecha_fin, p_descripcion, p_director, p_imagenURL, p_cant_temporadas, p_id_network, p_trailerURL);

	/*
    INSERT INTO auditoria_peliculas_serie(tabla_afectada, accion, id_registro, fecha_hora, detalle, id_usuario)
    VALUES ('serie', 'INSERT', LAST_INSERT_ID(), NOW(), p_nombre, p_id_usuario);
	*/
    
    -- Necesito obtener el ultimo ID para referirme a la serie y poder ingresar multiples generos a la table pivote
    SET p_id_serie = LAST_INSERT_ID();
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_actualizar_serie(
    IN p_id_serie INT,
    IN p_nombre VARCHAR(255),
    IN p_fecha_estreno DATE,
    IN p_fecha_fin DATE,
    IN p_descripcion VARCHAR(255),
    IN p_director VARCHAR(255),
    IN p_imagenURL VARCHAR(255),
    IN p_cant_temporadas INT,
    IN p_id_network INT,
    IN p_trailerURL VARCHAR(255)
)
BEGIN
    START TRANSACTION;

    UPDATE serie
    SET nombre = COALESCE(p_nombre, nombre),
        fecha_estreno = COALESCE(p_fecha_estreno, fecha_estreno),
        fecha_fin = COALESCE(p_fecha_fin, fecha_fin),
        descripcion = COALESCE(p_descripcion, descripcion),
        director = COALESCE(p_director, director),
        imagenURL = COALESCE(p_imagenURL, imagenURL),
        cant_temporadas = COALESCE(p_cant_temporadas, cant_temporadas),
        id_network = COALESCE(p_id_network, id_network),
        trailerURL = COALESCE(p_trailerURL, trailerURL)
    WHERE id_serie = p_id_serie;

	/*
    INSERT INTO auditoria_peliculas_serie(tabla_afectada, accion, id_registro, fecha_hora, detalle, id_usuario)
    VALUES ('serie', 'UPDATE', p_id_serie, NOW(), COALESCE(p_nombre, 'Sin nombre'), p_id_usuario);
	*/
    
    delete from genero_x_serie where id_serie = p_id_serie;
    
    COMMIT;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_listar_series()
BEGIN
    SELECT 
        s.id_serie,
        s.nombre,
        s.fecha_estreno,
        s.fecha_fin,
        s.descripcion,
        s.director,
        s.imagenURL,
        s.cant_temporadas,
        s.id_network,
        s.trailerURL ,
        GROUP_CONCAT(gxs.id_genero) AS generos
    FROM serie s
    LEFT JOIN genero_x_serie gxs on gxs.id_serie = s.id_serie
    group by s.id_serie;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_eliminar_serie(
    IN p_id_usuario INT,
    IN p_id_serie INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT 'Error al eliminar la serie' AS mensaje;
    END;

    START TRANSACTION;

    DELETE FROM comentarios_serie WHERE id_serie = p_id_serie;
    DELETE FROM visualizaciones_serie WHERE id_serie = p_id_serie;
    DELETE FROM calificaciones_serie WHERE id_serie = p_id_serie;
    DELETE FROM genero_x_serie WHERE id_serie = p_id_serie;
    DELETE FROM serie WHERE id_serie = p_id_serie;
	
    /*
    INSERT INTO auditoria_peliculas_serie(tabla_afectada, accion, id_registro, fecha_hora, detalle, id_usuario)
    VALUES ('serie', 'DELETE', p_id_serie, NOW(), 'Eliminada en cascada', p_id_usuario);
	*/
    
    COMMIT;
    SELECT 'Serie eliminada correctamente' AS mensaje;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_listar_network()
BEGIN
    SELECT 
        *
    FROM network;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_listar_generos()
BEGIN
    SELECT 
        *
    FROM genero;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_calificar_pelicula(p_id_pelicula int, p_calificacion tinyint, p_id_usuario int)
BEGIN
	-- De esta forma, el usuario solo puede calificar una vez la pelicula. Si ya la califico, con ON DUPLICATE KEY UPDATE actualiza su calificacion.
	insert into calificaciones_peliculas(id_pelicula, calificacion, id_usuario)
	values(p_id_pelicula, p_calificacion, p_id_usuario)
    ON DUPLICATE KEY UPDATE calificacion = p_calificacion;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_calificar_serie(p_id_serie int, p_calificacion tinyint, p_id_usuario int)
BEGIN
	insert into calificaciones_serie(id_serie, calificacion, p_id_usuario)
	values(p_id_serie, p_calificacion, p_id_usuario)
    ON DUPLICATE KEY UPDATE calificacion = p_calificacion;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_comentar_pelicula(in p_id_usuario int, in p_id_pelicula int, in p_texto varchar(255))
begin
	insert into comentarios_peli(id_usuario, id_pelicula, fecha_comentario, texto)
    values(p_id_usuario, p_id_pelicula, CURDATE(), p_texto);
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_comentar_serie(in p_id_usuario int, in p_id_serie int, in p_texto varchar(255))
begin
	insert into comentarios_serie(id_usuario, id_serie, fecha_comentario, texto)
    values(p_id_usuario, p_id_serie, CURDATE(), p_texto);
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_insertar_genero_por_peli(in p_id_pelicula int, in p_id_genero int)
begin
	INSERT INTO genero_x_pelicula (id_pelicula, id_genero) 
    VALUES (p_id_pelicula, p_id_genero);
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_insertar_genero_por_serie(in p_id_serie int, in p_id_genero int)
begin
	INSERT INTO genero_x_serie (id_serie, id_genero) 
    VALUES (p_id_serie, p_id_genero);
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_obtener_calificaciones_x_usuario(in p_id_usuario int)
begin
	select 
		p.nombre,
        p.imagenURL,
        p.id_pelicula,
		c.calificacion,
        u.id_usuario
	from
		calificaciones_peliculas c
	inner join
		peliculas p on p.id_pelicula = c.id_pelicula
	inner join
		usuario u on u.id_usuario = c.id_usuario;
end //
DELIMITER ;

/*create or replace view vw_historial_total as -- historial de cada usuario tambien para reportes avnzados
select 
    u.id_usuario,
    u.nombre_usuario,
    historial.contenido,
    historial.tipo,
    COUNT(*) as veces_visto,
    MAX(historial.fecha_visualizacion) as ultima_vez
from (
    select 
        v.id_usuario,
        p.nombre as contenido,
        'Pelicula' as tipo,
        v.fecha_visualizacion
    from visualizaciones_pelicula v
    inner join peliculas p on v.id_pelicula = p.id_pelicula

   union all

    select 
        v.id_usuario,
        s.nombre as contenido,
        'Serie' as tipo
    from visualizaciones_serie v
    inner join serie s on v.id_serie = s.id_serie
) as historial
inner join usuario u on historial.id_usuario = u.id_usuario
group by 
    u.id_usuario, 
    u.nombre_usuario, 
    historial.contenido, 
    historial.tipo
order by ultima_vez desc;
*/

DELIMITER //
CREATE PROCEDURE sp_obtener_calificaciones_x_usuario_serie(in p_id_usuario int)
begin
	select 
		s.nombre,
        s.imagenURL,
        s.id_serie,
		c.calificacion,
        u.id_usuario
	from
		calificaciones_serie c
	inner join
		serie s on s.id_serie = c.id_serie
	inner join
		usuario u on u.id_usuario = c.id_usuario;
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_actualizar_avatar_usuario(in p_id_usuario int, in p_url varchar(255))
begin
	update usuario
    set avatar = p_url
	where id_usuario = p_id_usuario;
end //
DELIMITER ;

SET SQL_SAFE_UPDATES = 0;
select * from genero_x_pelicula;
select * from calificaciones_peliculas;
select * from calificaciones_serie;
select * from comentarios_peli;
select * from peliculas;
select * from serie;
select * from usuario;
select * from network;

delete from serie;
delete from pelicula;