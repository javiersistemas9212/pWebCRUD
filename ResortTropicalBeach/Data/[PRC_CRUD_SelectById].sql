USE [DbResortTropical]
GO
/****** Object:  StoredProcedure [dbo].[PRC_CRUD_SelectById]    Script Date: 09/13/2020 17:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[PRC_CRUD_SelectById]
@id int

As


Select * 
From habitacions
where Id = @id