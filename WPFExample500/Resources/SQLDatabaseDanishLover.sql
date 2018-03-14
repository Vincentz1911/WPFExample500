use master 
go

if exists(select * from sys.databases where name = 'DanishLover.dk')
begin
alter database [DanishLover.dk] set single_user with rollback immediate
drop database [DanishLover.dk]
print 'Deleting already existing database'
end
go	

if not exists(select * from sys.databases where name = 'DanishLover.dk')
begin	
print 'Creating database DanishLover.dk'
Create database [DanishLover.dk]
end
else

begin
print 'Database DanishLover.dk already exists'
end
go
alter database [DanishLover.dk] set multi_user
go
use [DanishLover.dk]
go


if exists(select * from information_schema.tables where table_name = 'UserTable')
begin
print 'Dropping table UserTable'
drop table UserTable
end
go

if exists(select * from information_schema.tables where table_name = 'UserDataTable')
begin
print 'Dropping table UserDataTable'
drop table UserDataTable
end
go

if exists(select * from information_schema.tables where table_name = 'MessageTable')
begin
print 'Dropping table MessageTable'
drop table MessageTable
end
go

if exists(select * from information_schema.tables where table_name = 'ImageTable')
begin
print 'Dropping table ImageTable'
drop table ImageTable
end
go

if exists(select * from information_schema.tables where table_name = 'LikesTable')
begin
print 'Dropping table LikesTable'
drop table LikesTable
end
go

--******************* CREATING TABLES ********************

print 'Creating table PostalCodeTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'PostalCodeTable')
Create table PostalCodeTable
(
--PK_PostalCode int not null Primary Key,
PK_City nvarchar(50) Primary Key not null,
PosX int,
PosY int
)


print 'Creating table LoginTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'LoginTable')
Create table LoginTable
(
PK_Username nvarchar(50) Primary Key,
[Password] nvarchar(50)
)

--print 'Creating table UserDataTable'
--if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'UserDataTable')
--Create table UserDataTable
--(
--[FK_Username] nvarchar(50) foreign key references LoginTable(PK_Username),
--Country nvarchar(50) not null,
--Telephone nvarchar(50) not null,
--CreditCard nvarchar(50)
--)

print 'Creating table Sexual_PrefTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Sexual_PrefTable')
Create table Sexual_PrefTable
(
PK_Sexual_Pref nvarchar(50) Primary Key
)

print 'Creating table HairColorTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'HairColorTable')
Create table HairColorTable
(
PK_Haircolor nvarchar(50) Primary Key
)

print 'Creating table GenderTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'GenderTable')
Create table GenderTable
(
PK_Gender nvarchar(50) Primary Key
)

print 'Creating table UserTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'UserTable')
Create table UserTable
(
PK_Profilename nvarchar(50) not null Primary Key,
FK_Username nvarchar(50) foreign key references LoginTable(PK_Username),
FK_City nvarchar(50) not null foreign key references PostalCodeTable(PK_City),
FK_Gender nvarchar(50) not null foreign key references GenderTable(PK_Gender),
Email nvarchar(50) not null,

Ethnicity nvarchar(50),
Birthday date check(Birthday <= DateAdd(yy, -18, CONVERT (date, GetDate()))),
--Birthday datetime check(Birthday <= DateAdd(yy, -18, CONVERT (date, GetDate()))),
HeightCm int not null,
WeightKg int not null,
Job nvarchar(50),

StartDate DateTime not null,
EndDate DateTime default null,
FK_Sexual_Pref nvarchar(50) not null foreign key references Sexual_PrefTable(PK_Sexual_Pref),
FK_HairColor nvarchar(50) not null foreign key references HairColorTable(PK_HairColor),
)
go


print 'Creating table MessageTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'MessageTable')
Create table MessageTable
(
PK_MessageID int IDENTITY(1,1) Primary Key, 
FK_Sender nvarchar(50) not null foreign key references LoginTable([PK_Username]),
FK_Reciever nvarchar(50) not null foreign key references LoginTable([PK_Username]),
SubjectText nvarchar(50) not null,
MessageText nvarchar(1000) not null,
DateCreated timestamp not null,
IsRead bit not null

)
go

print 'Creating table LikesTable'
if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'LikesTable')
Create table LikesTable
(
FK_Sender nvarchar(50) not null foreign key references LoginTable([PK_Username]),
FK_Reciever nvarchar(50) not null foreign key references LoginTable([PK_Username]),
IsRead bit not null,
CONSTRAINT PK_Likes Primary Key (FK_Sender, FK_Reciever)
)
go

print 'Create index'
create index id_Usertable_Age ON Usertable (Birthday asc)


print 'Create Stored Procedure'
go
Create Procedure GetUserData
as
begin
select * from UserTable
end

go
--*********INSERT DATA**********
insert into GenderTable values ('Mand'), ('Kvinde')
insert into Sexual_PrefTable values ('No Homo'), ('Little bit Homo'), ('Homo');
insert into HairColorTable values ('Blond'), ('Sort'), ('Brun'), ('Rød'), ('Skaldet');
insert into LoginTable values ('Aloyard', 'Passw0rd'), ('123', '123');
insert into PostalCodeTable values ('København', 282, 232), ('Århus', 141, 182), ('Odense', 153, 266) , ('Aalborg', 123,84), ('Næstved',236,285), ('Esbjerg', 34,257), ('Aabenraa',92,305), ('Vejle',100,232),('Holstebro',43,161)

--insert into UserDataTable values ('Aloyard', 'Alma', 'Andreasen', 'Tværgyden 71', 'Klarup', 'Denmark', '53-41-76-00' , 'AlmaMAndreasen@dayrep.com', 'Visa')
insert into UserTable values ('ProfName' , 'Aloyard',  'København', 'Kvinde', 'AlmaMAndreasen@dayrep.com', 'Danish','1972-11-22', 169, 70, 'pack://application:,,,/Resources/Image.jpg', GETDATE(), Null, 'No Homo', 'Blond')
insert into UserTable values ('Mr 123' , '123',  'Odense', 'Mand', 'hvp@hvp.dk', 'Danish','1972-11-22', 169, 84, 'pack://application:,,,/Resources/Image.jpg', GETDATE(), Null, 'No Homo', 'Brun')
