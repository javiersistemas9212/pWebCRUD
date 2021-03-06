USE [DbResortTropical]
GO
/****** Object:  StoredProcedure [dbo].[PRC_CRUD_Insert]    Script Date: 09/13/2020 17:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[PRC_CRUD_Insert]
            @piso int
           ,@nHabitacion int
           ,@tipo nvarchar(100)
           ,@detalles nvarchar(1000)
           ,@disponible bit

As

INSERT INTO [DbResortTropical].[dbo].[habitacions]
           ([piso]
           ,[nHabitacion]
           ,[tipo]
           ,[detalles]
           ,[disponible])
     VALUES
           (@piso
           ,@nHabitacion
           ,@tipo
           ,@detalles
           ,@disponible)
