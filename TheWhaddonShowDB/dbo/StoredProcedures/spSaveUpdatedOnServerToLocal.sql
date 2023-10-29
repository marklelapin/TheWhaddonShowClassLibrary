CREATE PROCEDURE [dbo].[spSaveUpdatedOnServerToLocal]
	@UpdatedOnServer datetime2,
	@Updates nvarchar(max),
    @UpdateType varchar(255)
AS
	 CREATE TABLE #Updates (
                Id uniqueidentifier
                ,Created datetime2
               )

    INSERT #Updates (Id,Created)
    SELECT * FROM OPENJSON(@Updates)
        WITH (
        Id uniqueidentifier
        ,Created datetime2
        );

    
    IF @UpdateType = 'PartUpdate'
    BEGIN
        Update t

        Set t.UpdatedOnServer = @UpdatedOnServer

        FROM dbo.PartUpdate t
        INNER JOIN #Updates o
        ON o.Id = t.Id
        AND o.Created = t.Created;
    END

    IF @UpdateType = 'PersonUpdate'
    BEGIN
        Update t

        Set t.UpdatedOnServer = @UpdatedOnServer

        FROM dbo.PersonUpdate t
        INNER JOIN #Updates o
        ON o.Id = t.Id
        AND o.Created = t.Created;
    END
    IF @UpdateType = 'ScriptItemUpdate'
    BEGIN
        Update t

        Set t.UpdatedOnServer = @UpdatedOnServer

        FROM dbo.ScriptItemUpdate t
        INNER JOIN #Updates o
        ON o.Id = t.Id
        AND o.Created = t.Created;
    END


