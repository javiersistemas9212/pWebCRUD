USE [DbResortTropical]
GO
/****** Object:  StoredProcedure [dbo].[PRC_CRUD_Delete]    Script Date: 09/13/2020 17:25:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[PRC_CRUD_Delete]
            
           @Id int
As

DELETE FROM [DbResortTropical].[dbo].[habitacions]
      WHERE Id = @Id
