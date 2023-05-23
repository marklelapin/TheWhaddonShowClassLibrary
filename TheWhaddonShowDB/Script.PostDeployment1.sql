/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


if not exists(select * from dbo.PartUpdate)
BEGIN
    INSERT dbo.PartUpdate ([Id], [ConflictId], [Created], [CreatedBy], [UpdatedOnServer], [IsActive], [Name], [PersonId], [Tags])
   values ('68417C12-80C3-48BC-8EBE-3F3F2A91B8E5'
            ,null
            ,'2023-04-19 08:03:58.8431658'
            ,'Mark Carter'
            ,'2023-04-19 08:05:48.5671658'
            ,1
            ,'Mr Test'
            ,'545A9495-DB58-44EC-BA47-FD0B7E478D4A'
            ,'["Test","Male"]'
            )
        , ('17822466-DD66-4F2D-B4A9-F7EAAD6EB08B'
            ,null
            ,'2023-04-19 09:05:58.8453258'
            ,'Mark Carter'
            ,'2023-04-19 10:04:48.6789658'
            ,1
            ,'Ms Test'
            ,null
            ,'["Test","Female","Singing"]'
            )
        , (
            '17822466-DD66-4F2D-B4A9-F7EAAD6EB08B'
            ,null
            ,'2023-04-21 12:58:23.5628451'
            ,'Guy Birch'
            ,'2023-04-21 13:01:48.9805643'
            ,1
            ,'Ms Test'
            ,'2B3FA075-D0B5-49AB-B897-DAB1428CA500'
            ,'["Test","Female","Singing"]'
            )
        , ('F380FD46-6E6E-450D-AD3E-23EEC0B6A75E'
            ,null
            ,'2023-04-19 09:08:58.3745924'
            ,'Mark Carter'
            ,'2023-04-19 10:04:49.4562984'
            ,1
            ,'Uncle Test'
            ,null
            ,'["Test","Male","Singing"]'
            )
        , ('F380FD46-6E6E-450D-AD3E-23EEC0B6A75E'
            ,null
            ,'2023-04-21 09:08:58.3745924'
            ,'Guy Birch'
            ,'2023-04-21 10:04:49.4562984'
            ,0
            ,'Uncle Test'
            ,null
            ,'["Test","Male","Singing"]'
            )
END;

if not exists(select * from dbo.PersonUpdate)
BEGIN

    INSERT dbo.PersonUpdate ([Id], [ConflictId], [Created], [CreatedBy], [UpdatedOnServer], [IsActive], [FirstName], [LastName], [Email], [PictureRef], [IsActor], [IsSinger], [IsWriter], [isBand], [IsTechnical], [Tags])

   values ('545A9495-DB58-44EC-BA47-FD0B7E478D4A'
            ,null
            ,'2023-05-30 10:03:58.1345654'
            ,'Mark Carter'
            ,'2023-05-30 10:05:48.9436483'
            ,1
            ,'Bob'
            ,'Blair'
            ,'bob.blair@thisisnotarealemail.com'
            ,'/images/picture.png'
            ,1
            ,0
            ,0
            ,0
            ,0
            ,'["Test","Male"]'
            )
        , ('2B3FA075-D0B5-49AB-B897-DAB1428CA500'
            ,null
            ,'2023-05-19 09:05:58.8453258'
            ,'Mark Carter'
            ,'2023-05-19 10:04:48.6789658'
            ,1
            ,'Sue'
            ,'Smith'
            ,'sue.smith@fakeemail.com'
            ,'/images/picture3.png'
            ,1
            ,0
            ,0
            ,0
            ,0
            ,'["Test","Female"]'
            )
END;


if not exists(select * from dbo.ScriptItemUpdate)
BEGIN


   INSERT dbo.ScriptItemUpdate ([Id], [ConflictId], [Created], [CreatedBy], [UpdatedOnServer], [IsActive], [ParentID], [OrderNo], [Type], [Text], [PartIds], [Tags])

   VALUES ('0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,null
            ,'2023-04-19 07:55:58.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:55:59.9436483'
            ,1
            ,null
            ,1
            ,'Scene'
            ,'Husband Greets Wife'
            ,'["68417C12-80C3-48BC-8EBE-3F3F2A91B8E5","17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"]'
            ,'["Test"]'
            ),
        ('FC97305D-8A92-42D5-94DB-6FC9F5FF1432'
            ,null
            ,'2023-04-19 07:55:59.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:00.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,1
            ,'Dialogue'
            ,'Hello Ms Test.'
            ,'["68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"]'
            ,'["Test"]'
            ),
         ('744BD79A-1A2B-425F-874F-315A3B3BA9F2'
            ,null
            ,'2023-04-19 07:56:00.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:01.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,2
            ,'Dialogue'
            ,'Good Morning Mr Test'
            ,'["17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"]'
            ,'["Test"]'
            ),
         ('79E604CF-7CC2-41F6-B37F-F30C76AB5F34'
            ,null
            ,'2023-04-19 07:56:01.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:02.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,3
            ,'Dialogue'
            ,'Would you like a cup of coffee?'
            ,'["68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"]'
            ,'["Test"]'
            ),
          ('CD42AD02-CC02-4AA4-8AB6-8C4ACB2E9858'
            ,null
            ,'2023-04-19 07:56:01.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:02.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,4
            ,'Dialogue'
            ,'Yes please! Two sugars, milk and a drop of baileys.'
            ,'["17822466-DD66-4F2D-B4A9-F7EAAD6EB08B"]'
            ,'["Test"]'
            ),
          ('10DD3D80-5853-424B-999D-FB758565B03E'
            ,null
            ,'2023-04-19 07:56:02.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:03.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,5
            ,'Dialogue'
            ,'Isnt it a bit early for that?'
            ,'["68417C12-80C3-48BC-8EBE-3F3F2A91B8E5"]'
            ,'["Test"]'
            ),
          ('ED789FA3-4B2B-41A0-A322-773ED7CE89FE'
            ,null
            ,'2023-04-19 07:56:10.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:11.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,6
            ,'Action'
            ,'(audience laughs)'
            ,null
            ,'["Test"]'
            ),
          ('ED789FA3-4B2B-41A0-A322-773ED7CE89FE'
            ,null
            ,'2023-04-19 07:56:12.1345654'
            ,'Mark Carter'
            ,'2023-04-19 07:56:13.9436483'
            ,1
            ,'0DE2C9A4-41F7-4170-9BDF-04B7B8F64197'
            ,6
            ,'Action'
            ,'(audience laughs tepidly and suspects they should have stayed at home.)'
            ,null
            ,'["Test"]'
            )
            
END;
