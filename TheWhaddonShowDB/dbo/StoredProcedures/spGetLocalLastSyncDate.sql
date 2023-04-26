CREATE PROCEDURE [dbo].[spGetLocalLastSyncDate]
@ObjectType varchar(255)
,@LastSyncDate DateTime2 OUTPUT
AS
SELECT @LastSyncDate = LastSyncDate FROM LocalSyncInfo WHERE ObjectType = @ObjectType;

RETURN;