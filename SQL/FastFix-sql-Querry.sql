create database FixFastDb

use FixFastDb

select * from Usuarios

CREATE TABLE Usuarios (
  id_usuario INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  name_ VARCHAR(20) NOT NULL,
  last_name1 VARCHAR(30) DEFAULT 'xx-xx',
  last_name2 VARCHAR(30) DEFAULT 'cc-cc',
  sexo CHAR(1) DEFAULT 'N', -- N para no especificado
  email VARCHAR(255) UNIQUE NOT NULL CHECK (email LIKE '%@%'),
  password VARCHAR(MAX) NOT NULL
)

alter table Usuarios
	add Tipo_User char default '1';

	select * from Usuarios

select * from Empleados;
select * from puestos;


create trigger  NewEmployeeOrUpdateUser 
on Usuarios
after insert,update 
	as 
	begin 
		DECLARE @UsuarioID INT; 
		Declare @Tipo char;

		select @UsuarioID = i.id_usuario from inserted i; 
		select @Tipo = i.Tipo_User from inserted i;


		if @Tipo = '1'
		begin
			INSERT INTO [dbo].[Empleados]
			([id_Usuario]
			,[id_puesto])
		VALUES(@UsuarioID,6)
		end

		if @Tipo = '2'
		begin
			INSERT INTO [dbo].[clientes]
           ([id_Usuario]
           ,[rango])
     VALUES
           (@UsuarioID,'1')
		end
		
	end;
	



create table clientes (
	id_cliente int identity primary key not null,  
	id_Usuario int references Usuarios(id_usuario),
	rango CHAR(1) default 'B'
)

create table puestos(
	id_Puestos INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	name_Puesto varchar(30) not null, 
	descripcion varchar(max) default 'dd-dd',
	pago_por_hora float not null,
)


INSERT INTO puestos (name_Puesto, descripcion, pago_por_hora)
VALUES
    ('Técnico Reparador', 'Diagnóstica y repara equipos electrónicos, como computadoras, impresoras y redes.', 100),
    ('Programador', 'Desarrolla software y aplicaciones utilizando lenguajes de programación.', 150),
    ('Diseñador Gráfico', 'Crea diseños visuales para productos, marcas y campañas publicitarias.', 120),
    ('Analista de Sistemas', 'Analiza los sistemas de información de una organización para mejorar su eficiencia.', 180),
    ('Asistente Administrativo', 'Brinda apoyo administrativo a una oficina o departamento.', 110);

INSERT INTO puestos (name_Puesto, descripcion, pago_por_hora)
VALUES('Trabajador Generico', 'Es Un simple trabajdor Generico', 100)

create table Empleados (
	id_empleados int identity primary key not null,
	id_Usuario int references Usuarios(id_usuario),
	id_puesto int references puestos(id_Puestos)
)

create table categorias (
	id_categoria INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	name_categoria varchar(20),
	descripcion_categoria varchar(max) default 'dd-dd'
)

create table Productos(
	id_productos INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	id_categria int references categorias(id_categoria),
	name_producto varchar(40) not null, 
	descripcion varchar(max) not null,
	marca_del_producto varchar(30),
	precio_unidad float not null,
	cantidad_en_stock int not null,
)

alter table Productos 
	add precio_De_Abastesimiento float default 0.0;


create table estados_de_las_Piezas(
	id_estado INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	name_estado varchar(20) not null, 
	desripcion_estado varchar(max) default 'dd-dd',
)

create table Almacen_De_Reparaciones(
	id_pieza_a_reparar INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	id_cliente int references clientes(id_cliente),
	id_empleado_a_cargo int references Empleados(id_empleados),
	id_estado_de_la_pieza int references estados_de_las_Piezas(id_estado) default 0,
	descripcion_de_la_averia varchar(max) default 'dd-dd',
	monto_acordado float default 0.0,
	fecha_de_la_alamacenamiento datetime
)

create table citas (
	id_cita INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	id_cliente int references clientes(id_cliente),
	id_empleado int references empleados(id_empleados),
	descripcion_de_la_averia varchar(max) default 'dd-dd',
	monto_acordado float default 0.0,
	fecha_de_la_cita datetime default getdate()
)




select * from Usuarios