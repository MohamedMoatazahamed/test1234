create table usertable123(
userID int primary key identity(1,1),
name varchar (50),
password varchar(50),
Email varchar (50),
role varchar (50),




);
create table Tasks123(
TaskId int primary key identity(1,1),

title varchar (50),
Descrption varchar(50),
status varchar(50),
DueDate datetime,
 userID INT,
    FOREIGN KEY (userID) REFERENCES usertable123(userID)

);

insert into usertable123(name,password,Email,role)
values ('Mohamed','1234','Mohamed@gmail.com','Manager'),
('yare','123456','yara.gmail.com','Employees'),
('Medo','123456','Mo@gmail.com','Employees');
insert into Tasks123(title,Descrption,status,userID)
values('frontend','finish loginpage','Pending',2),
('Back end','addpyment servise','in progress',2),
('pytion','end page signup','Pending',3),
('cesharp','Mangementsystem','in progress',3),
('cesharp1','Mangementsystem','completed',2);
select*from usertable123;
select*from Tasks123;




