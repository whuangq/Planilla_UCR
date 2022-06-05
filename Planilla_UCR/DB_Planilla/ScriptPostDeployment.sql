CREATE DATABASE DB_Planilla
USE DB_Planilla

-- Tables
Create Table Person(
	Email varchar(255) NOT NULL primary key,
	Name varchar(255) NOT NULL,
	LastName1 varchar(255),
	LastName2 varchar(255),
	SSN int NOT NULL,
	BankAccount varchar(255) NOT NULL,
	Adress varchar(255),
	PhoneNumber varchar(255)
);

CREATE TABLE Account(
	Email varchar(255) NOT NULL PRIMARY KEY,
	UserPassword VARBINARY(500) NOT NULL,
    FOREIGN KEY(Email) REFERENCES Person(Email),
);

CREATE TABLE Employee(
	Email varchar(255) NOT NULL PRIMARY KEY,
	FOREIGN KEY(Email) REFERENCES Person(Email)
);

CREATE TABLE Employer(
	Email varchar(255) NOT NULL PRIMARY KEY,
	FOREIGN KEY(Email) REFERENCES Person(Email)
);

CREATE TABLE Project(
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	ProjectDescription varchar(255),
	MaximumAmountForBenefits int, 
	MaximumBenefitAmount int,
	PaymentInterval varchar(255),
	PRIMARY KEY(EmployerEmail, ProjectName),
	FOREIGN KEY(EmployerEmail) REFERENCES Employer(Email)
);

CREATE TABLE AgreementType(
	TypeAgreement varchar(255) NOT NULL,
	MountPerHour int NOT NULL,
	PRIMARY KEY(TypeAgreement, MountPerHour)
);

CREATE TABLE Agreement(
	EmployeeEmail varchar(255) NOT NULL,
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	ContractDate date NOT NULL,
	ContractType varchar(255) NOT NULL,
	MountPerHour int NOT NULL,
	Duration date NOT NULL,
	PRIMARY KEY(EmployeeEmail,EmployerEmail,ProjectName,ContractDate),
	FOREIGN KEY(EmployeeEmail) REFERENCES Employee(Email),
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName),
	FOREIGN KEY(ContractType, MountPerHour) REFERENCES AgreementType(TypeAgreement, MountPerHour)
);

CREATE TABLE Subscription
(
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	SubscriptionName varchar(255) NOT NULL,
	ProviderName varchar(255),
	SubscriptionDescription varchar(600),
	Cost float NOT NULL,
	TypeSubscription int NOT NULL,
	IsEnabled int NOT NULL,
	PRIMARY KEY(EmployerEmail, ProjectName, SubscriptionName),
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName)
);

-- Suscription Stored Procedures
GO
CREATE PROCEDURE GetAllBenefits
AS
BEGIN
    SELECT * FROM Subscription WHERE TypeSubscription=1 and IsEnabled=1
END


GO 
CREATE PROCEDURE GetAllDeductions
AS
BEGIN
    SELECT * FROM Subscription WHERE TypeSubscription=0 and IsEnabled=1
END

-- Project Stored Procedures
GO 
CREATE PROCEDURE GetEmployerByEmail(@email VARCHAR(255))
AS
BEGIN
    SELECT * FROM Employer WHERE Employer.Email = @email
END

GO
CREATE PROCEDURE ProjectNameCheck(@ProjectName VARCHAR(255))
AS
BEGIN
    SELECT * FROM Project WHERE Project.ProjectName = @ProjectName
END

-- People Stored Procedures
GO
CREATE PROCEDURE GetPersonByEmail(@email varchar(255))
AS
BEGIN
    SELECT * FROM Person AS P WHERE P.Email = @email
END

-- Employer Stored Procedures
GO
CREATE PROCEDURE GetInfoEmployer(@EmailEmployer varchar(255))
AS
BEGIN
	SELECT Person.Email, Person.Name, Person.LastName1, Person.LastName2, Person.SSN, Person.BankAccount, Person.Adress, Person.PhoneNumber
	FROM  Person JOIN Employer ON  Person.Email  = Employer.Email WHERE Employer.Email = @EmailEmployer
END

-- Employee Stored Procedures
GO
CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
	SELECT Employee.Email, Person.Name, Person.LastName1, Person.LastName2, Person.SSN, Person.BankAccount, Person.Adress, Person.PhoneNumber
	FROM Employee JOIN  Person ON Employee.Email = Person.Email
END

GO
CREATE PROCEDURE [dbo].[GetProjectEmployees]
@projectName VARCHAR(255)
AS
BEGIN
	SELECT P.Email, P.Name, P.LastName1, P.LastName2, P.SSN, P.BankAccount, P.Adress, P.PhoneNumber
	FROM Agreement as A JOIN  Person as P ON A.EmployeeEmail = P.Email
	Where A.ProjectName = @projectName
END

GO
CREATE PROCEDURE GetEmployeeByEmail(@email varchar(255))
AS
BEGIN
    SELECT * FROM Employee AS E WHERE E.Email = @email
END

-- Account Stored Procedures
GO
CREATE Procedure EmailCheckLoggin(@UserEmail varchar(255))
AS
BEGIN
    Select * from Account where Account.Email = @UserEmail
END

GO
Create proc InsertDataToAccountWithPasswordEncripted(@EmailAccount varchar(255),@UserPasswordToEncrypt varchar(255))
As 
Declare @UserPassword varbinary(150)
Declare @EncryptedPassword varbinary(150)
Set @UserPassword = CONVERT(varbinary(150),@UserPasswordToEncrypt);
Set @EncryptedPassword = HASHBYTES('SHA2_256', @UserPassword);
Insert into Account values (@EmailAccount, @EncryptedPassword) 

GO
CREATE PROCEDURE PasswordCheckLoggin(@UserEmail varchar(255), @UserPassword varchar(255))
AS
BEGIN
	Select * from Account where [UserPassword] =  HASHBYTES('SHA2_256',@UserPassword) AND Account.Email = @UserEmail
END

-- Data Insert
INSERT INTO Person
VALUES('jeremy@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
5454454,
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Person
VALUES('leonel@ucr.ac.cr',
'Leonel',
'Campos',
'Murillo',
242342,
'CR40324350012',
'San José, Costa Rica',
'83355316'
)

INSERT INTO Person
VALUES('mau@ucr.ac.cr',
'Mauricio',
'Palma',
'Vitra',
8857655,
'CR4024220012',
'San José, Costa Rica',
'677774'
)

INSERT INTO Employer
VALUES('jeremy@ucr.ac.cr')

INSERT INTO Employer
VALUES('leonel@ucr.ac.cr')

INSERT INTO Employee
VALUES('mau@ucr.ac.cr')

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Proyecto 1',
'Emprendimiento de chocolates',
15000,
10,
'Quincenal'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Proyecto 2',
'Emprendimiento de galletas',
20000,
6,
'Mensual'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Proyecto 3',
'Emprendimiento de confites',
22000,
7,
'Quincenal'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Proyecto 4',
'Emprendimiento de camisetas',
40000,
12,
'Mensual'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Proyecto 5',
'Emprendimiento de perfumes',
20000,
5,
'Mensual'
)

INSERT INTO Project
VALUES('jeremy@ucr.ac.cr',
'Proyecto 1',
'Emprendimiento de panadería',
30000,
20,
'Mensual'
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Proyecto 1',
'Fondo de pensiones',
'CCSS',
'Contribuición voluntaria para el fondo de pensiones.',
12000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Proyecto 1',
'Ayudemos a los niños',
'Hospital de los niños',
'Cuota voluntaria para ayudar a los más necesitados.',
25000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Proyecto 1',
'Rescate de perros',
'Refugio de perros',
'Cuota voluntaria para ayudar a los más necesitados.',
12000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Proyecto 1',
'Gym',
'Golden Gym',
'Gimnasio equipado con todo lo necesario.',
25000,
1,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Proyecto 1',
'Piscina',
'Aquanautas',
'Piscinas temperadas, ubicadas en San Pedro.',
12000,
1,
1
)

INSERT INTO AgreementType
VALUES('Empleado fijo', 22)

INSERT INTO Agreement
VALUES('mau@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Proyecto 1', '9999-12-31','Empleado fijo',22, '9999-12-31')
