CREATE PROCEDURE [dbo].[spSaveToServer]
	@Updates nvarchar(max)
    ,@UpdateType varchar(255)
    ,@UpdatedOnServer datetime OUTPUT
AS

   Set @UpdatedOnServer = SYSDATETIME() --CONVERT(DateTime2,CONVERT(varchar(23), SYSDATETIME(), 121),121)  -- yyyy-mm-dd hh:mm:ss.mmm


    IF OBJECT_ID('tempdb..#Updates') IS NOT NULL
        DROP TABLE #Updates

    CREATE TABLE #Updates (
        Id uniqueidentifier
        ,Created datetime2
        )

    INSERT #Updates 
    SELECT * FROM OPENJSON(@Updates)
    WITH (
    Id uniqueidentifier
    ,Created datetime2
    )

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

    Update p
    Set p.UpdatedOnServer = @UpdatedOnServer
    FROM dbo.PartUpdate p
    INNER JOIN #Updates o
    ON p.Id = o.Id
    AND p.Created = o.Created;

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
    
    Update p
    Set p.UpdatedOnServer = @UpdatedOnServer
    FROM dbo.PersonUpdate p
    INNER JOIN #Updates o
    ON p.Id = o.Id
    AND p.Created = o.Created;
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

    Update p
    Set p.UpdatedOnServer = @UpdatedOnServer
    FROM dbo.ScriptItemUpdate p
    INNER JOIN #Updates o
    ON p.Id = o.Id
    AND p.Created = o.Created;
END

RETURN