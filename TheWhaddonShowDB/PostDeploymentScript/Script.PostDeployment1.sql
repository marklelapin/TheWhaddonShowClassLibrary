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
BEGIN --RESET PERSON LOG TEST DATA


DELETE 
FROM dbo.PersonLog

INSERT dbo.PersonLog (Id,UpdatedLocally,UpdatedOnServer,ConflictID,IsActive,FirstName,LastName,IsActor,IsSinger,IsWriter,IsBand,IsTechnical,Tags) 

VALUES

(newid(),'2023-03-01 09:00','2023-03-01 09:01',null,1,'Mark','Carter',1,1,1,0,0,'Male')
,(newid(),'2023-03-03 10:00','2023-03-03 10:01',null,1,'Sharon','Bessell',1,1,0,0,0,'Female')
,(newid(),'2023-03-03 10:02','2023-03-03 10:02',null,1,'Guy','Birch-Jones',1,0,1,0,0,'Male')
,(newid(),'2023-03-03 10:04','2023-03-03 10:04',null,1,'Graham','Hain',1,0,0,1,0,'Male')
,(newid(),'2023-03-03 10:10','2023-03-03 10:11',null,1,'Jamie','Spinks',0,0,0,1,0,'Male')
,(newid(),'2023-03-03 10:11','2023-03-03 10:12',null,1,'John','Robinson',0,0,0,1,0,'Male')
,(newid(),'2023-03-03 10:11','2023-03-03 10:12',null,0,'Pete','Bush',0,0,0,1,0,'Male')
,('55B4FE80-AD18-488B-913C-366C19D19B7B','2023-03-03 10:00','2023-03-03 10:01',null,1,'George','Carter',1,1,0,0,0,'Male,Kid')
,(newid(),'2023-03-03 10:02','2023-03-03 10:02',null,1,'Rose','Ambler-Boateng',1,0,1,0,0,'Female,Kid')
,(newid(),'2023-03-03 10:04','2023-03-03 10:04',null,1,'Grace','Birch-Jones',1,0,0,1,0,'Female,Kid')
,(newid(),'2023-03-03 10:10','2023-03-03 10:11',null,1,'David','Porteous',0,0,0,1,0,'Male')
,('913FBA0B-24DC-47B1-9C18-BEA3FFD61E41','2023-03-03 10:11','2023-03-03 10:12',null,1,'Tanera','Snell',0,0,0,1,0,'Female');

END

BEGIN --RESET PART LOG TEST DATA
DELETE 
FROM dbo.PartLog 

INSERT dbo.PartLog (Id,UpdatedLocally,UpdatedOnServer,ConflictID,IsActive,[Name],PersonID,Tags) 

VALUES

(newid(),'2023-03-05 13:00','2023-03-05 13:00',null,1,'Grace',null,'Kid')
,(newid(),'2023-03-05 13:00','2023-03-05 13:00',null,1,'Rose',null,'Kid')
,(newid(),'2023-03-05 13:00','2023-03-05 13:00',null,1,'George','55B4FE80-AD18-488B-913C-366C19D19B7B','Kid')
,(newid(),'2023-03-05 13:00','2023-03-05 13:00',null,1,'Mr Porteous',null,null)
,(newid(),'2023-03-05 13:00','2023-03-05 13:00',null,1,'Ms Snell','913FBA0B-24DC-47B1-9C18-BEA3FFD61E41',null);

END

BEGIN --RESET SCRIPT ITEM LOG TEST DATA
DELETE
FROM dbo.ScriptItemLog

INSERT dbo.ScriptItemLog (Id,UpdatedLocally,UpdatedOnServer,ConflictID,IsActive,ParentID,OrderNo,[Type],[Text],Parts,Tags)

VALUES ('55FCA102-891F-4064-ABA5-A720E087C3DB','2023-03-07 21:00','2023-03-07 21:02',null,1,null,1,'Show','Test Show',null,null)
,('886B3B26-A554-4CE7-BB1A-853DBD324E11','2023-03-07 21:00','2023-03-07 21:02',null,1,'55FCA102-891F-4064-ABA5-A720E087C3DB',1,'Act','Act One',null,null)
,('D58A6E3B-11D8-4F19-98C7-0230D33D08F6','2023-03-05 21:00','2023-03-05 21:02',null,1,'886B3B26-A554-4CE7-BB1A-853DBD324E11',1,'Scene','No Title',null,null)
,('D58A6E3B-11D8-4F19-98C7-0230D33D08F6','2023-03-06 21:00','2023-03-06 21:02',null,1,'886B3B26-A554-4CE7-BB1A-853DBD324E11',1,'Scene','Really need to come up with Title',null,null)
,('D58A6E3B-11D8-4F19-98C7-0230D33D08F6','2023-03-07 21:00','2023-03-07 21:02',null,1,'886B3B26-A554-4CE7-BB1A-853DBD324E11',1,'Scene','MUST come up with Title',null,null)
,('D58A6E3B-11D8-4F19-98C7-0230D33D08F6','2023-03-08 21:00','2023-03-08 21:02',null,1,'886B3B26-A554-4CE7-BB1A-853DBD324E11',1,'Scene','Fidget Spinning Intro',null,null)

,('A96B01C1-C7AC-4D71-ACC3-087A03AED44F','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',1,'Synopsis','Kids compare gadgets / fidget spinners. Ends with one of the kids waving drinks order tickets telling them they can get alcohol. Gets confiscated by teacher who then offers them out to other teachers.',null,null)
,('04A980A3-5799-4636-9802-09F6AC0D2594','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',1,'Staging','In front of curtain.',null,null)
,('122CC54E-058B-43A7-BFE8-0D4C11140509','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',2,'Dialogue','Enters playing with Fidget Spinner.',null,null)
,('122CC54E-058B-43A7-BFE8-0D4C11140509','2023-03-07 21:30','2023-03-07 21:32',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',2,'Dialoge','Enters playing with yo yo.',null,null)
,('122CC54E-058B-43A7-BFE8-0D4C11140509','2023-03-07 21:45','2023-03-07 21:47',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',2,'Action','Enters playing with yo yo.',null,null)
,('CD95B7E9-0956-4468-8FCC-236BF6CAEE5B','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',3,'Dialogue','Where did you get that?',null,null)
,('73FC3721-98FA-40CD-9A49-277C782C093A','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',4,'Dialogue','I’ve got one here - I’ll sell it to you',null,null)
,('359BD51B-3B20-40CE-BA4C-30122A958609','2023-03-07 21:00','2023-03-07 21:02',null,1,'73FC3721-98FA-40CD-9A49-277C782C093A',1,'Action','Yo yo comes out of blazer.',null,null)
,('4DD19F7F-0839-47E4-8C29-48FABE6CE989','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',5,'Dialogue','Can I have one of those',null,null)
,('09E19228-7D20-4370-9D4D-527CA20BD8DF','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',6,'Dialogue','You don’t want one of those you want one of these.',null,null)
,('0A36DBAA-B7CA-48C8-ACF2-5A4296E2FC81','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',7,'Dialogue','Great I’ll take one. What else have you got?',null,null)
,('602FDB34-A64A-4A37-84E4-5B3E1BD375FD','2023-03-07 21:00','2023-03-07 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',8,'Dialogue','Take your pick…. ',null,null)
,('CC0F4159-F00B-4C6E-95DE-5D2C36BBA9F3','2023-03-07 21:00','2023-03-07 21:02',null,1,'602FDB34-A64A-4A37-84E4-5B3E1BD375FD',1,'Action','(Opens blazer to reveal tonne of stuff)',null,null)
,('AA76EBF2-A57E-4950-A3C8-5D3691246139','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',9,'Dialogue','Got, Got, Got, Got…. Nah.',null,null)
,('0B60BC0F-7746-4B2D-94D7-62A9E0B8BBD3','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',10,'Dialogue','I tell you what you haven’t got. These are new in.',null,null)
,('D515FC38-D8C0-4143-ABB9-67685514D38B','2023-03-08 21:00','2023-03-08 21:02',null,1,'0B60BC0F-7746-4B2D-94D7-62A9E0B8BBD3',1,'Action','Holds up drinks ticket.',null,null)
,('C55D5F59-0D70-46C7-A8FD-74D57D8A5DE0','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',11,'Dialogue','I’ll tell you what this is… and you lot need to know as well.',null,null)
,('3B9A9D1D-D0A8-4526-B5BF-74F60A643AD0','2023-03-08 21:00','2023-03-08 21:02',null,1,'C55D5F59-0D70-46C7-A8FD-74D57D8A5DE0',1,'Action','to audience',null,null)
,('AB0EBE0B-BD5C-4CC4-8C2E-81233D5226AF','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',12,'Dialogue','You waive them in the air, and someone brings you alcohol.',null,null)
,('BB0AD164-8A48-40D5-8135-8180E4C9A355','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',13,'Action','Someone comes on hands George a pint',null,null)
,('D1810865-5EBA-4179-AEAA-863713D5A3E6','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',14,'Dialogue','Where did you get those?',null,null)
,('42C9768A-31B6-4BF6-AE3E-8E9E2BDC072B','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',15,'Dialogue','They were on all these seats',null,null)
,('EFAF5283-822C-4B91-A7FB-91C027771771','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',16,'Dialogue','What have you get there. What is this ',null,null)
,('55A6C795-9A89-4B07-9DB0-9704A11232B8','2023-03-08 21:00','2023-03-08 21:02',null,1,'EFAF5283-822C-4B91-A7FB-91C027771771',1,'Action','waving ticket in the air',null,null)
,('76EAC550-FB9D-4F2A-A5FA-9C93F0451921','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',17,'Action','Drink comes on from green room',null,null)
,('231558D2-3726-4183-B53F-9E6D8A441C93','2023-03-08 21:00','2023-03-08 21:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',18,'Dialogue','Oh thanks! Hang on. You shouldn’t have any of these. Go on clear off.',null,null)
,('D33D27B5-7CDD-492C-87F1-BF7A6E5F447C','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',19,'Action','Mr Porteous comes on and takes drink from George',null,null)
,('0901005C-1042-4A79-8D83-CB01D1B51646','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',20,'Dialogue','Hey. Give that to me.',null,null)
,('C969CD32-8C3F-4430-AB5B-CBD3483E54F2','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',21,'Dialogue','Here watch this.',null,null)
,('92CAE371-2D64-4332-9947-D07E8968A013','2023-03-08 22:00','2023-03-09 05:02',null,1,'C969CD32-8C3F-4430-AB5B-CBD3483E54F2',1,'Action','Waves wrong ticket in the air and two posh cocktails come out.',null,null)
,('6DA53F95-E379-40DA-B967-DBC987E462EB','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',22,'Dialogue','That’s your pink punters membership cared you fool. Still, I’ll have one of those tickets.',null,null)
,('35F7548A-1D6E-40DB-B3B9-F6E204D6761B','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',23,'Dialogue','That’ll be a fiver.',null,null)
,('9483FAF4-7AB7-43A1-A4BE-F7BDDA6A08A6','2023-03-08 22:10','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',24,'Dialogue','Done',null,null)
,('9483FAF4-7AB7-43A1-A4BE-F7BDDA6A08A6','2023-03-08 22:09','2023-03-09 05:02',null,0,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',24,'Dialogue','Excellent thats the transaction completed',null,null)
,('9483FAF4-7AB7-43A1-A4BE-F7BDDA6A08A6','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',24,'Dialogue','Excellent thats the transaction completed',null,null)
,('AAF4775A-F5C9-49FD-810F-FB433C414C29','2023-03-08 22:00','2023-03-09 05:02',null,1,'D58A6E3B-11D8-4F19-98C7-0230D33D08F6',25,'Sound','School Bell Rings',null,null)

SELECT 'Reset was successful'

END