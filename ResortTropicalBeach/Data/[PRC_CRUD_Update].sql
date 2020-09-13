USE [DbResortTropical]
GO
/****** Object:  StoredProcedure [dbo].[PRC_CRUD_Update]    Script Date: 09/13/2020 17:26:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[PRC_CRUD_Update]
            
           @Id int
           ,@piso int
           ,@nHabitacion int
           ,@tipo nvarchar(100)
           ,@detalles nvarchar(1000)
           ,@disponible bit

As


UPDATE [DbResortTropical].[dbo].[habitacions]
   SET [piso] = @piso
      ,[nHabitacion] = @nHabitacion
      ,[tipo] = @tipo
      ,[detalles] = @detalles
      ,[disponible] = @disponible
 WHERE @Id = Id



