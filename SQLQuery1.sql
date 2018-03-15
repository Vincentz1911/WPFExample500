IF EXISTS (SELECT '{Username}' FROM dbo.LoginTable) UPDATE dbo.LoginTable SET Password = '{Password}' WHERE PK_Username = '{Username}';

IF EXISTS (SELECT '{Username}' FROM dbo.LoginTable) UPDATE dbo.UserTable SET PK_Profilename = '{Profilename}' , Email = '{Email}' WHERE FK_Username = '{Username}'

select FK_Username, [Password], PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable where PK_Username=123