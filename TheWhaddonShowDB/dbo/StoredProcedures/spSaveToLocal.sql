CREATE PROCEDURE [dbo].[spSaveToLocal]
	@Updates nvarchar(max)
    ,@UpdateType varchar(255)
AS

IF @UpdateType = 'PartUpdate'
BEGIN
    INSERT dbo.PartUpdate (Id,ConflictId,Created,CreatedBy,UpdatedOnServer,IsActive,[Name],PersonId,Tags)

    SELECT * FROM OPENJSON(@Updates)
    WITH (
    Id uniqueidentifier
    ,ConflictId uniqueidentifier
    ,Created datetime2
    ,CreatedBy varchar(255)
    ,UpdatedOnServer datetime2
    ,IsActive bit
    ,[Name] varchar(255)
    ,PersonId uniqueidentifier
    ,Tags nvarchar(max) AS JSON
    );
END

IF @UpdateType = 'PersonUpdate'
BEGIN
    INSERT dbo.PersonUpdate (Id,ConflictId,Created,CreatedBy,UpdatedOnServer,IsActive,FirstName,LastName,Email,PictureRef,IsActor,IsSinger,IsWriter,isBand,IsTechnical,Tags)

    SELECT * FROM OPENJSON(@Updates)
    WITH (
    Id uniqueidentifier
    ,ConflictId uniqueidentifier
    ,Created datetime2
    ,CreatedBy varchar(255)
    ,UpdatedOnServer datetime2
    ,IsActive bit
    ,FirstName varchar(255)
    ,LastName varchar(255)
    ,Email varchar(255)
    ,PictureRef varchar(255)
    ,IsActor bit
    ,IsSinger bit
    ,IsWriter bit
    ,IsBand bit
    ,IsTechnical bit
    ,Tags nvarchar(max) AS JSON
    );
END

IF @UpdateType = 'ScriptItemUpdate'
BEGIN
    INSERT dbo.ScriptItemUpdate (Id,ConflictId,Created,CreatedBy,UpdatedOnServer,IsActive,ParentId,OrderNo,[Type],[Text],Parts,Tags)

    SELECT * FROM OPENJSON(@Updates)
    WITH (
    Id uniqueidentifier
    ,ConflictId uniqueidentifier
    ,Created datetime2
    ,CreatedBy varchar(255)
    ,UpdatedOnServer datetime2
    ,IsActive bit
    ,ParentId uniqueidentifier
    ,OrderNo int
    ,[Type] varchar(255)
    ,[Text] nvarchar(max)
    ,Parts nvarchar(max) AS JSON
    ,Tags nvarchar(max) AS JSON
    );
END
RETURN 