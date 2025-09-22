create database ReelNode;
use ReelNode;
SET SQL_SAFE_UPDATES = 0;
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

select * from usuario;

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
    id_serie int,
    FOREIGN KEY (id_pelicula) REFERENCES pelicula(id_pelicula),
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
create procedure sp_insertar_usuario(
	in p_nombre varchar(255),
    in p_password varchar(255),  
    IN p_id_rol INT
)
begin 
	insert into usuario(nombre,usuario_password, fecha_registro,id_rol)
    values(p_nombre, p_password, curdate(), p_id_rol);
END //
DELIMITER ;

-- un handler para el login
DELIMITER //
create procedure login_user(
	in p_nombre varchar(255),
    in p_password varchar(255)
)
begin
	declare v_id int;
    -- Handler para cualquier error SQL
    declare exit handler for sqlexception
    
    begin 
		select "Ocurrio un error durante el login" as mensaje;
	end;
    
    select id_usuario
    into v_id
    from usuario
    where nombre = p_nombre and usuario_password = p_password;
    
    if v_id is null then
		select "usuario o contraseña incorrectos" as mensaje;
	else 
		select "login correctos" as mensaje, v_id as id_usuario;
	end if;
END //
DELIMITER ;

-- Usuario comun 
DELIMITER //
create procedure sc_comentar_vizualizar(
in p_id_usuario int,
in p_id_objeto int,
in p_cometario varchar(255),
in p_tipo_objeto varchar(255) -- pelicula o serie
)
begin
	declare exit handler for sqlexception
    begin 
		rollback;
        select "no se pudo registrar la accion del usuario";
        end;
        
        -- Solo un usuario común puede ejecutar esto
	start transaction;
    
    if not exists (
		select 1
        from rol_x_usuario ru
        join rol r on ru.id_rol = r.id_rol
        where ru.id_usuario = p_id_usuario and r.nombre = "usuario comun"
        
    )then
    signal sqlstate "45000"
	set message_text = "no tienes permiso para realizar esta accion";
    end if;
    
     -- Registrar según el tipo de objeto (pelicula, serie)
     if p_tipo_objeto = "pelicula" then
     insert into visualizaciones_pelicula(id_usuario, id_pelicula)
     values(p_id_usuario, p_id_objeto);
     
     insert into comentarios_peliculas(id_usuaios, id_pelicula, fecha_cometario, texto)
     values(p_id_usuario, p_id_objeto, curdate(), p_cometario);
     
     elseif p_tipo_objeto = "serie" then
		insert into visualizaciones_serie(id_usuario, id_serie,fecha_comentario, texto) 
        values(p_id_serie, p_id_objeto, curdate(), p_comentario);
        
	else 
		signal sqlstate "45000" 
        set message_text = 'Tipo de objeto inválido, debe ser "pelicula" o "serie"';
        end if;
        
        commit;
        select concat("accion registrada correctamente en ", p_tipo_objeto)  as mensaje;
END //
DELIMITER ;

-- usuario adminitrador (rol y permisos)
DELIMITER //
create procedure sa_signar_rol_permisos(
	in p_id_admin int,
    in p_id_usuario int,
    in p_id_rol int,
    in p_id_permisos int
)
begin
	declare exit handler for sqlexception 
    begin
		rollback;
        select "no puede asignar rol y permisos" as mensaje;
	end;
    
    start transaction;
    -- Solo un administrador puede ejecutar esto
    
    if not exists(
    select 1 from rol_x_usuario ru 
    join rol r on ru.id_rol = r.id_rol
    where ru.id_rol = p_id_admin and r.tipo_rol = "Administrador"
    )then
		signal sqlstate "45000" set message_text = "No tienes permisos de administrador";
        end if;
        
	-- Asignar rol al usuario
	insert into rol_x_usuario(id_usuario, id_rol) 
    values(p_id_usuario, p_id_rol);
      
	commit;
	
    select "rol y permisos asignados correctamente"  as mensaje;
END //
DELIMITER ;

--  procedimiento para administrar peliculas o series (solo administrador)
DELIMITER //
create procedure ad_modificar_contenido(
	in p_id_admin int,
    in p_tipo_objeto varchar(20),  -- 'pelicula' o 'serie'
    in p_accion varchar(20),       -- 'agregar' o 'eliminar'
    in p_id_objeto int,            -- usado para eliminar
    in p_nombre varchar(255),      -- usado para agregar
    in p_fecha date,               -- fecha de estreno
    in p_descripcion varchar(255),
    in p_director varchar(255),
    in p_duracion varchar(50),     -- solo películas
    in p_cant_temporadas int,      -- solo series
    in p_id_network int          -- solo series
)
begin
	declare exit handler for sqlexception
    begin
		rollback;
        select "no se pudo completar la operacion" as mensaje;
	end;
    
    start transaction;
    
    if not exists (
    select 1 
    from rol_x_usuario ru
    join rol r on ru.id_rol = r.id_rol
    where ru.id_usuario = p_id_admin and r.tipo_rol = "Administrador"
    )then
		signal sqlstate "45000" set message_text = "No tienes permisos de administrador";
	end if;
    
    -- Acciones según tipo y operación
    if p_tipo_objeto = "pelicula" then
    if p_accion = "agregar" then
		insert into peliculas (nombre, fecha_estreno, descripcion, director, duracion)
        values (p_nombre, p_fecha, p_descripcion, p_director, p_duracion);
        
        elseif p_accion = "eliminar" then
			delete from peliculas where id_peliculas = p_id_objeto;
        else 
			signal sqlstate "45000" set message_text = "accion invalida";
		end if;
        
        elseif p_tipo_objeto = "serie"then
			if p_accion = "agregar" then
				insert into serie(nomvre, fecha_estreno, descripcion, director, cant_temporadas, id_network) 
                values (p_nombre, p_fecha, p_descripcion, p_director, p_cant_temporadas, p_id_network);
            elseif p_accion = "eliminar" then
				delete from serie where id_serie = p_id_objeto;
			else
				signal sqlstate "45000" set message_text = "accion invalida";
			end if;
		else
			signal sqlstate "45000" set message_text = "tipo de objeto invalido";
		end if;
        
        commit;
        select concat('Operación ', p_accion, ' realizada correctamente en ', p_tipo_objeto) AS mensaje;
END //
DELIMITER ;