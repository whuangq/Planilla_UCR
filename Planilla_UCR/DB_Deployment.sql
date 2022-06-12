CREATE DATABASE DB_Planilla
GO
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
	ContractStartDate date NOT NULL,
	ContractType varchar(255) NOT NULL,
	MountPerHour int NOT NULL,
	ContractFinishDate date NOT NULL,
	PRIMARY KEY(EmployeeEmail,EmployerEmail,ProjectName,ContractStartDate),
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

GO
CREATE OR ALTER PROCEDURE ModifySubscription(
	@EmployerEmail varchar(255),
	@ProjectName varchar(255),
	@SubscriptionName varchar(255),
	@NewSubscriptionName varchar(255),
	@ProviderName varchar(255),
	@SubscriptionDescription varchar(600),
	@Cost float,
	@TypeSubscription int,
	@IsEnabled int,
	@Transaction int output
) AS
BEGIN
	IF ((@NewSubscriptionName in (SELECT SubscriptionName FROM Subscription WHERE EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName)) AND (@SubscriptionName <> @NewSubscriptionName))
	BEGIN 
		SET @Transaction = 0;
	END
	ELSE
		BEGIN
			SET @Transaction = 1;

			UPDATE Subscription
			SET SubscriptionName = @NewSubscriptionName, SubscriptionDescription = @SubscriptionDescription,Cost = @Cost, ProviderName = @ProviderName 
			WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName;
		END
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


GO
CREATE PROCEDURE UpdatePerson(
	@EmailPerson varchar(255),
	@NewName varchar(255),
	@NewLastName1 varchar(255),
	@NewLastName2 varchar(255),
	@NewSSN int,
	@NewBankAccount varchar(255),
	@NewAdress varchar(255),
	@NewPhoneNumber varchar(255)
)
AS
BEGIN
	UPDATE Person 
	SET Name=@NewName, LastName1=@NewLastName1, LastName2=@NewLastName2, 
	SSN=@NewSSN, BankAccount=@NewBankAccount, 
	Adress=@NewAdress, PhoneNumber=@NewPhoneNumber
	WHERE Email=@EmailPerson
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
@projectName VARCHAR(255)
AS
BEGIN
	SELECT P.Email, P.Name, P.LastName1, P.LastName2, P.SSN, P.BankAccount, P.Adress, P.PhoneNumber
	FROM Employee JOIN  Person AS P ON Employee.Email = P.Email left JOIN Agreement as A ON A.EmployeeEmail = Employee.Email
	Where A.ProjectName IS NULL OR A.ProjectName != @projectName
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

GO
CREATE or ALTER PROCEDURE GetSalaryPerAgreement(@MountPerHour int)
AS
BEGIN 
	SELECT * FROM AgreementType WHERE MountPerHour = @MountPerHour
END

GO
CREATE PROCEDURE GetContracteeByEmail(@ContracteeEmail varchar(255))
AS
BEGIN 
	SELECT * FROM Agreement WHERE EmployeeEmail = @ContracteeEmail
END

-- Data Insert
GO
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
Insert into AgreementType
Values('Tiempo completo', 1000)

Insert into AgreementType
Values('Medio tiempo', 500)

Insert into AgreementType
Values('Servicios profesionales', 700)

Insert into AgreementType
Values('Por horas', 10)
