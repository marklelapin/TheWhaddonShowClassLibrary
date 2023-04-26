CREATE PROCEDURE [dbo].[spSaveUpdatedOnServerToLocal]
	@UpdatedOnServer datetime2,
	@Objects nvarchar(max),
    @ObjectType varchar(255)
AS
	 CREATE TABLE #Objects (
                Id uniqueidentifier
                ,Created datetime2
               )

    INSERT #Objects (Id,Created)
    SELECT * FROM OPENJSON(@Objects)
        WITH (
        Id uniqueidentifier
        ,Created datetime2
        );

    
    IF @ObjectType = 'PartUpdate'
    BEGIN
        Update t

        Set t.UpdatedOnServer = @UpdatedOnServer

        FROM dbo.PartUpdate t
        INNER JOIN #Objects o
        ON o.Id = t.Id
        AND o.Created = t.Created;
    END

    IF @ObjectType = 'PersonUpdate'
    BEGIN
        Update t

        Set t.UpdatedOnServer = @UpdatedOnServer

        FROM dbo.PersonUpdate t
        INNER JOIN #Objects o
        ON o.Id = t.Id
        AND o.Created = t.Created;
    END
    IF @ObjectType = 'ScriptItemUpdate'
    BEGIN
        Update t

        Set t.UpdatedOnServer = @UpdatedOnServer

        FROM dbo.ScriptItemUpdate t
        INNER JOIN #Objects o
        ON o.Id = t.Id
        AND o.Created = t.Created;
    END


