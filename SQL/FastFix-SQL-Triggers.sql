--TRIGGERS 

use FixFastDb

create trigger  NewEmployeeOrUpdateUser 
on Usuarios
FOR insert,update 
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


CREATE TRIGGER MOVER_A_OTRA_TABLA_DE_TIPO 
ON USUARIOS 
AFTER INSERT, UPDATE 
	AS 
	BEGIN 
		DECLARE @IDUSUARIO INT; 
		DECLARE @IDCLIENTE INT; 
		DECLARE @IDeMPLEADO INT;
		
		SELECT @IDUSUARIO = I.ID_USUARIO FROM inserted I; 
		SELECT @IDCLIENTE = CL.id_cliente FROM clientes CL WHERE id_Usuario = @IDUSUARIO
		SELECT @IDEMPLEADO = EM.id_empleados FROM Empleados EM WHERE id_Usuario = @IDUSUARIO




		IF @IDCLIENTE IS NOT NULL 
			UPDATE clientes 
				SET ACTIVO_INACTIVO = '0'
				WHERE id_Usuario = @IDUSUARIO
		ELSE 
			PRINT 'USUARIO NO SE ENCUENTRA EN LA TABLA DE CLIENTES'

			
		IF @IDEMPLEADO IS NOT NULL 
			UPDATE Empleados 
				SET ACTIVO_INACTIVO = '0'
				WHERE id_Usuario = @IDUSUARIO
		ELSE 
			PRINT 'USUARIO NO SE ENCUENTRA EN LA TABLA DE EMPLEADOS'


	END; 