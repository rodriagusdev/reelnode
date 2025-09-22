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
    tipo_rol VARCHAR(100) NOT NULL
);

insert into rol (tipo_rol)
values ("Admin"), ("Usuario");

CREATE TABLE usuario (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    nombre_usuario VARCHAR(255) NOT NULL,
    email_usuario varchar(255) not null,
    password_usuario varchar (255) not null,
    avatar MEDIUMBLOB,
    fecha_registro DATE NOT NULL,
    id_rol INT,
    FOREIGN KEY (id_rol) REFERENCES rol(id_rol)
);
ALTER TABLE usuario
ADD CONSTRAINT nombre_usuario UNIQUE (nombre_usuario);

select* from usuario;

insert into usuario (nombre_usuario, email_usuario, password_usuario, avatar, fecha_registro, id_rol)
values("rodri", "rodri@gmail.com", "1", null, now(), 1),
("san", "san@gmail.com", "2", null, now(), 1),
("agus", "agus@gmail.com", "3", null, now(), 1);

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
    id_pelicula int,
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula),
    fecha_comentario DATE NOT NULL,
    texto varchar(255)
);
create table calificaciones_serie(
	id_calificaciones int primary key auto_increment,
    calificacion int,
    id_serie int,
    FOREIGN KEY (id_serie) REFERENCES serie(id_serie)
);
create table calificaciones_peliculas(
	id_calificaciones int primary key auto_increment,
    calificacion int,
     id_pelicula int,
    FOREIGN KEY (id_pelicula) REFERENCES peliculas(id_pelicula)
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

-- Insertar un usuario
DELIMITER //
CREATE PROCEDURE sp_insertar_usuario(
    IN p_nombre VARCHAR(255),
    IN p_password VARCHAR(255),  
    IN p_id_rol INT
)
BEGIN 
    INSERT INTO usuario(nombre_usuario, password_usuario, fecha_registro, id_rol)
    VALUES(p_nombre, p_password, CURDATE(), p_id_rol);
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

/* -- Usuario común: comentar y visualizar
DELIMITER //
CREATE PROCEDURE sc_comentar_vizualizar(
    IN p_id_usuario INT,
    IN p_id_objeto INT,
    IN p_comentario VARCHAR(255),
    IN p_tipo_objeto VARCHAR(255) -- pelicula o serie
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN 
        ROLLBACK;
        SELECT "no se pudo registrar la accion del usuario" AS mensaje;
    END;
        
    START TRANSACTION;
    
    -- Solo un usuario común puede ejecutar esto
    IF NOT EXISTS (
        SELECT 1
        FROM rol_x_usuario ru
        JOIN rol r ON ru.id_rol = r.id_rol
        WHERE ru.id_usuario = p_id_usuario AND r.tipo_rol = "Usuario"
    ) THEN
        SIGNAL SQLSTATE "45000"
        SET MESSAGE_TEXT = "no tienes permiso para realizar esta accion";
    END IF;
    
    -- Registrar según el tipo de objeto
    IF p_tipo_objeto = "pelicula" THEN
        INSERT INTO visualizaciones_pelicula(id_usuario, id_pelicula)
        VALUES(p_id_usuario, p_id_objeto);
     
        INSERT INTO comentarios_peli(id_usuario, id_pelicula, fecha_comentario, texto)
        VALUES(p_id_usuario, p_id_objeto, CURDATE(), p_comentario);
     
    ELSEIF p_tipo_objeto = "serie" THEN
        INSERT INTO visualizaciones_serie(id_usuario, id_serie)
        VALUES(p_id_usuario, p_id_objeto);

        INSERT INTO comentarios_serie(id_usuario, id_serie, fecha_comentario, texto)
        VALUES(p_id_usuario, p_id_objeto, CURDATE(), p_comentario);
        
    ELSE 
        SIGNAL SQLSTATE "45000" 
        SET MESSAGE_TEXT = 'Tipo de objeto inválido, debe ser "pelicula" o "serie"';
    END IF;
        
    COMMIT;
    SELECT CONCAT("Accion registrada correctamente en ", p_tipo_objeto) AS mensaje;
END //
DELIMITER ;


-- Usuario administrador: asignar rol y permisos
DELIMITER //
CREATE PROCEDURE sa_signar_rol_permisos(
    IN p_id_admin INT,
    IN p_id_usuario INT,
    IN p_id_rol INT,
    IN p_id_permisos INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
        ROLLBACK;
        SELECT "no puede asignar rol y permisos" AS mensaje;
    END;
    
    START TRANSACTION;
    
    -- Solo un administrador puede ejecutar esto
    IF NOT EXISTS(
        SELECT 1 
        FROM rol_x_usuario ru 
        JOIN rol r ON ru.id_rol = r.id_rol
        WHERE ru.id_usuario = p_id_admin AND r.tipo_rol = "Admin"
    ) THEN
        SIGNAL SQLSTATE "45000" SET MESSAGE_TEXT = "No tienes permisos de administrador";
    END IF;
        
-- Asignar rol al usuario
    INSERT INTO rol_x_usuario(id_usuario, id_rol) 
    VALUES(p_id_usuario, p_id_rol);

-- Asignar permiso al usuario
    INSERT INTO permisos_usuarios(id_usuario, id_permiso)
    VALUES(p_id_usuario, p_id_permisos);
      
    COMMIT;
    SELECT "rol y permisos asignados correctamente" AS mensaje;
END //
DELIMITER ;


-- Procedimiento para administrar peliculas o series (solo administrador)
DELIMITER //
CREATE PROCEDURE ad_modificar_contenido(
    IN p_id_admin INT,
    IN p_tipo_objeto VARCHAR(20),  -- 'pelicula' o 'serie'
    IN p_accion VARCHAR(20),       -- 'agregar' o 'eliminar'
    IN p_id_objeto INT,            -- usado para eliminar
    IN p_nombre VARCHAR(255),      -- usado para agregar
    IN p_fecha DATE,               -- fecha de estreno
    IN p_descripcion VARCHAR(255),
    IN p_director VARCHAR(255),
    IN p_duracion VARCHAR(50),     -- solo películas
    IN p_cant_temporadas INT,      -- solo series
    IN p_id_network INT            -- solo series
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SELECT "no se pudo completar la operacion" AS mensaje;
    END;
    
    START TRANSACTION;
    
    IF NOT EXISTS (
        SELECT 1 
        FROM rol_x_usuario ru
        JOIN rol r ON ru.id_rol = r.id_rol
        WHERE ru.id_usuario = p_id_admin AND r.tipo_rol = "Admin"
    ) THEN
        SIGNAL SQLSTATE "45000" SET MESSAGE_TEXT = "No tienes permisos de administrador";
    END IF;
    
    -- Acciones según tipo y operación
    IF p_tipo_objeto = "pelicula" THEN
        IF p_accion = "agregar" THEN
            INSERT INTO peliculas (nombre, fecha_estreno, descripcion, director, duracion)
            VALUES (p_nombre, p_fecha, p_descripcion, p_director, p_duracion);
        
        ELSEIF p_accion = "eliminar" THEN
            DELETE FROM peliculas WHERE id_pelicula = p_id_objeto;
        ELSE 
            SIGNAL SQLSTATE "45000" SET MESSAGE_TEXT = "accion invalida";
        END IF;
        
    ELSEIF p_tipo_objeto = "serie" THEN
        IF p_accion = "agregar" THEN
            INSERT INTO serie(nombre, fecha_estreno, descripcion, director, cant_temporadas, id_network) 
            VALUES (p_nombre, p_fecha, p_descripcion, p_director, p_cant_temporadas, p_id_network);
        ELSEIF p_accion = "eliminar" THEN
            DELETE FROM serie WHERE id_serie = p_id_objeto;
        ELSE
            SIGNAL SQLSTATE "45000" SET MESSAGE_TEXT = "accion invalida";
        END IF;
    ELSE
        SIGNAL SQLSTATE "45000" SET MESSAGE_TEXT = "tipo de objeto invalido";
    END IF;
        
    COMMIT;
    SELECT CONCAT('Operación ', p_accion, ' realizada correctamente en ', p_tipo_objeto) AS mensaje;
END //
DELIMITER ;*/

-- 1. Login inicial con validación de credenciales y carga de rol.
-- sin uso
create table auditoria_login(
	id_auditoria int primary key auto_increment,
    id_usuario int,
    fecha datetime not null,
    exitoso boolean,
    foreign key (id_usuario) references usuario(id_usuario)
);

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

-- 3. Usuarios (Admin): CRUD y cambio de roles.
create index idx_usuario_email on usuario(email_usuario); -- Índice para acelerar búsquedas por email
create index idx_usuario_rol on usuario(id_rol); -- Índice para buscar por rol

-- Procedimientos almacenados con crud
DELIMITER //
create procedure sp_insertar_usuario_crud(
	in p_nombre varchar(255),
    in p_email varchar(255),
    in p_password varchar(255),
    in p_id_rol int
)
begin
	start transaction;
    insert into usuario(nombre_usuario, email_usuario,password_usuario, fecha_registro, id_rol) 
    values(p_nombre, p_email, md5(p_password), now(),p_id_rol); -- (md5) Es un algoritmo de hash. Convierte cualquier texto en un código único de 32 caracteres hexadecimales. Ese código es irreversible, es decir, no se puede “desencriptar” para volver al texto original. Utiliza en contraseñas
    commit;
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

-- para cambiar los roles mas seguro
CREATE TABLE auditoria_roles (
    id_auditoria int primary key auto_increment,
    id_usuario int,
    rol_anterior int,
    rol_nuevo int,
    fecha datetime not null,
    id_admin int, -- quien hizo el cambio
    foreign key (id_usuario) references usuario(id_usuario),
    foreign key (id_admin) references usuario(id_usuario)
);

DELIMITER //
create procedure sp_cambiar_rol(
	in p_id_usuario int,
    in p_id_nuevo_rol int,
    in p_id_admin int
)
begin
	declare v_rol_anterior int;
	
    start transaction;
    
    -- obtener rol anterior
    
    select id_rol into v_rol_anterior
    from usuario
    where id_usuario = p_id_usuario;
    
    -- actualizar rol
    update usuario
    set id_rol = p_id_nuevo_rol
    where id_usuario = p_id_usuario;
    
    -- registrar auditoria
    insert into auditoria_roles(id_usuario, rol_anterior, rol_nuevo, fecha, id_admin)
    values (p_id_usuario, v_rol_anterior, p_id_nuevo_rol, NOW(), p_id_admin);
    
    commit;
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
DELIMITER ;
-- 4. Visualizaciones (Usuario común): registrar visualización y consultar historial.
-- índice para buscar visualizaciones por usuario
create index idx_visualizaciones_usuario_serie on visualizaciones_serie(id_usuario);
create index  idx_visualizaciones_usuario_pelicula on visualizaciones_pelicula(id_usuario);

-- índice para buscar visualizaciones por serie/película
create index idx_visualizaciones_serie on visualizaciones_serie(id_serie);
create index  idx_visualizaciones_pelicula on visualizaciones_pelicula(id_pelicula);

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
    
    insert into auditoria_visualizaciones(id_usuario, id_serie, id_pelicula, fecha)
    values (p_id_usuario, p_id_serie, p_id_pelicula, NOW());
    
    commit;
    select "Visualización registrada correctamente" as mensaje;
end //
DELIMITER ;

-- Procedimiento almacenado para consultar historial
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
-- 6. Reportes: Admin → estadísticas generales, 
-- Usuario común → historial personal. Exportables a PDF.

DELIMITER //
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

-- 2. Películas y Series (Admin): ABM, carga de imágenes, importación/exportación JSON.
create table auditoria_peliculas_serie(
	id_auditoria int auto_increment primary key,
    tabla_afectada varchar(255),
    accion varchar(255),
    id_registro int,
    id_usuario_admin int,
    fecha_hora datetime,
    detalle varchar(255)
);

ALTER TABLE auditoria_peliculas_serie
ADD CONSTRAINT fk_auditoriap_usuario
FOREIGN KEY (id_usuario_admin) REFERENCES usuario(id_usuario);

create index idx_peliculas_nombre on peliculas(nombre);
create index idx_series_nombre on serie(nombre);
create index idx_serie_network on serie(id_network);

DELIMITER //
create trigger trg_insert_pelicula
after insert on peliculas
for each row
begin
    insert into auditoria_peliculas_series(tabla_afectada, accion, id_registro, id_usuario_admin, fecha_hora, detalle)
    values ('peliculas', 'INSERT', new.id_pelicula, null, NOW(), new.nombre);
end //

create trigger trg_update_pelicula
after update on peliculas
for each row
begin
    insert into auditoria_peliculas_series(tabla_afectada, accion, id_registro, id_usuario_admin, fecha_hora, detalle)
    values ('peliculas', 'UPDATE', new.id_pelicula, null, now(), concat('De: ', old.nombre, ' A: ', new.nombre));
end //
-- Triggers de auditoría
create trigger trg_delete_pelicula
after delete on peliculas
for each row
begin
    insert into auditoria_peliculas_series(tabla_afectada, accion, id_registro, id_usuario_admin, fecha_hora, detalle)
    values ('peliculas', 'DELETE', old.id_pelicula, null, now(), old.nombre);
end //

DELIMITER ;

-- Procedimientos almacenados 
-- Alta de película
DELIMITER //
create procedure sp_insertar_pelicula(
    in p_nombre varchar(255),
    in p_fecha date,
    in p_descripcion varchar(255),
    in p_director varchar(255),
    in p_duracion varchar(50),
    in p_id_admin int
)
begin
    insert into peliculas(nombre, fecha_estreno, descripcion, director, duracion)
    values(p_nombre, p_fecha, p_descripcion, p_director, p_duracion);

    insert intoauditoria_peliculas_series(tabla_afectada, accion, id_registro, id_usuario_admin, fecha_hora, detalle)
    values ('peliculas', 'INSERT', LAST_INSERT_ID(), p_id_admin, NOW(), p_nombre);
end //
DELIMITER ;

-- Actualizar película
DELIMITER //
create procedure sp_actualizar_pelicula(
    in p_id int,
    in p_nombre varchar(255),
    in p_descripcion varchar(255),
    in p_director varchar(255),
    in p_duracion varchar(50),
    in p_id_admin int
)
begin
    update peliculas
    set nombre = p_nombre,
        descripcion = p_descripcion,
        director = p_director,
        duracion = p_duracion
    where id_pelicula = p_id;

    insert into auditoria_peliculas_series(tabla_afectada, accion, id_registro, id_usuario_admin, fecha_hora, detalle)
    values ('peliculas', 'UPDATE', p_id, p_id_admin, NOW(), p_nombre);
end //
DELIMITER ;

-- Eliminar película con transacción
DELIMITER //
create procedure sp_eliminar_pelicula(
    in p_id int,
    in p_id_admin int
)
BEGIN
    declare exit handler for sqlexception
    begin
        rollback;
        select 'Error al eliminar la película' as mensaje;
    end;

    start transaction;

    -- Eliminar dependencias
   delete from comentarios_peli where id_pelicula = p_id;
    delete from visualizaciones_pelicula where id_pelicula = p_id;
    delete from calificaciones_peliculas where id_pelicula = p_id;

    -- Eliminar película
    delete from peliculas where id_pelicula = p_id;

    -- Registrar auditoría
    insert into auditoria_peliculas_series(tabla_afectada, accion, id_registro, id_usuario_admin, fecha_hora, detalle)
    values ('peliculas', 'DELETE', p_id, p_id_admin, NOW(), 'Eliminada en cascada');

    commit;
    select 'Película eliminada correctamente' as mensaje;
end //
DELIMITER ;

-- exportación a JSON
DELIMITER //
create procedure sp_exportar_peliculas_json()
begin
    select JSON_ARRAYAGG(
               JSON_OBJECT(
                   'id_pelicula', id_pelicula,
                   'nombre', nombre,
                   'fecha_estreno', fecha_estreno,
                   'descripcion', descripcion,
                   'director', director,
                   'duracion', duracion
               )
           ) as peliculas_json
    from peliculas;
end //
DELIMITER ;

-- 5. Comentarios (Usuario común): ingresar comentarios de texto, verlos, Admin puede eliminarlos.

create table auditoria_comentarios_usuario (
    id_auditoria int auto_increment primary key,
    tabla_afectada varchar(50),
    accion varchar(20),
    id_registro int,
    id_usuario int,
    fecha_hora datetime,
    detalle varchar(255)
);
ALTER TABLE auditoria_comentarios_usuario
ADD CONSTRAINT fk_auditoriac_usuario
FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario);

-- para comentarios de peli:
ALTER TABLE auditoria_comentarios_usuario
ADD CONSTRAINT fk_auditoriac_comentario_peli
FOREIGN KEY (id_registro) REFERENCES comentarios_peli(id_comentario);

-- para comentarios de serie (si id_registro corresponde a comentarios_serie):
ALTER TABLE auditoria_comentarios_usuario
ADD CONSTRAINT fk_auditoriac_comentario_serie
FOREIGN KEY (id_registro) REFERENCES comentarios_serie(id_comentario);

create index idx_comentarios_usuario_peli on comentarios_peli(id_usuario);
create index idx_comentarios_usuario_serie on comentarios_serie(id_usuario);

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

    insert into auditoria_comentarios_usuario(tabla_afectada, accion, id_registro, id_usuario, fecha_hora, detalle)
    values('comentarios_peli', 'INSERT', last_insert_id(), p_id_usuario, now(), p_texto);
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

    insert into auditoria_comentarios_usuario(tabla_afectada, accion, id_registro, id_usuario, fecha_hora, detalle)
    values('comentarios_serie', 'INSERT', last_insert_id(), p_id_usuario, now(), p_texto);
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
        u.nombre_usuario, 
        u.password_usuario, 
        u.email_usuario,
        r.tipo_rol AS nombre_rol
    FROM usuario u
    INNER JOIN rol r ON r.id_rol = u.id_rol;
END //
DELIMITER ;
