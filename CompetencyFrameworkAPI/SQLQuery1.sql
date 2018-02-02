USE [Job_Competency_JB_MA]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[ReturnTopics]

SELECT	@return_value as 'Return Value'

GO
