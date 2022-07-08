--DB

CREATE DATABASE DB_Planilla
GO
USE DB_Planilla

-- Tables
CREATE TABLE Person(
	Email varchar(255) NOT NULL primary key,
	Name varchar(255) NOT NULL,
	LastName1 varchar(255),
	LastName2 varchar(255),
	SSN int NOT NULL,
	BankAccount varchar(255) NOT NULL,
	Adress varchar(255),
	PhoneNumber varchar(255),
	IsEnabled int NOT NULL
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
	ProjectDescription varchar(600),
	MaximumAmountForBenefits float, 
	MaximumBenefitAmount int,
	PaymentInterval varchar(255),
	IsEnabled int NOT NULL,
	LastPaymentDate date
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
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName) ON UPDATE CASCADE,
	FOREIGN KEY(ContractType, MountPerHour) REFERENCES AgreementType(TypeAgreement, MountPerHour),
	IsEnabled int NOT NULL,
	Justification varchar(max)
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
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName) ON UPDATE CASCADE
);

CREATE TABLE ReportOfHours(
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	EmployeeEmail varchar(255) NOT NULL,
	ReportDate date NOT NULL,
	ReportHours float NOT NULL,
	Approved int NOT NULL,
	PRIMARY KEY(EmployerEmail, ProjectName, EmployeeEmail, ReportDate),
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName) ON UPDATE CASCADE,
	FOREIGN KEY(EmployeeEmail) REFERENCES Employee(Email)
);

CREATE TABLE Subscribes(
	EmployeeEmail varchar(255) NOT NULL,
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	SubscriptionName varchar(255) NOT NULL,
	Cost float NOT NULL,
	StartDate datetime NOT NULL,
	EndDate date,
	PRIMARY KEY(EmployeeEmail,EmployerEmail,ProjectName, SubscriptionName, StartDate),
	FOREIGN KEY(EmployerEmail, ProjectName, SubscriptionName) REFERENCES Subscription(EmployerEmail, ProjectName, SubscriptionName) ON UPDATE CASCADE,
	FOREIGN KEY(EmployeeEmail) REFERENCES Employee(Email)
);

CREATE TABLE LegalDeduction(
	DeductionName varchar(255) NOT NULL,
	Cost float NOT NULL,
	PRIMARY KEY(DeductionName),
);

CREATE TABLE Payment(
	EmployeeEmail varchar(255) NOT NULL,
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	GrossSalary float NOT NULL, 
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	PRIMARY KEY(EmployeeEmail,EmployerEmail,ProjectName, StartDate, EndDate),
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName) ON UPDATE CASCADE,
	FOREIGN KEY(EmployeeEmail) REFERENCES Employee(Email)
);

-- Suscription Stored Procedures
GO
 CREATE OR ALTER PROCEDURE GetAllBenefits
AS
BEGIN
    SELECT * FROM Subscription WHERE TypeSubscription=1 and IsEnabled=1
END

GO 
CREATE OR ALTER PROCEDURE GetAllDeductions
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
	@IsEnabled int
) AS
BEGIN
	UPDATE Subscription
	SET SubscriptionName = @NewSubscriptionName, SubscriptionDescription = @SubscriptionDescription,Cost = @Cost, ProviderName = @ProviderName 
	WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName;
END

GO
CREATE OR ALTER PROCEDURE DeleteSubscription(
	@EmployerEmail varchar(255),
	@ProjectName varchar(255),
	@SubscriptionName varchar(255)
) AS
BEGIN
	UPDATE Subscription
	SET IsEnabled = 0
	WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName;

	DECLARE @EmployeeEmail varchar(255)
	DECLARE @StartDate datetime
	DECLARE cursor_Subscribes CURSOR FOR
	SELECT EmployeeEmail, StartDate
	FROM Subscribes WHERE EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName
	OPEN cursor_Subscribes
		FETCH NEXT FROM cursor_Subscribes INTO @EmployeeEmail, @StartDate
		WHILE @@FETCH_STATUS = 0 BEGIN
			DELETE FROM Subscribes WHERE  EmployeeEmail = @EmployeeEmail AND EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName AND StartDate = @StartDate
			FETCH NEXT FROM cursor_Subscribes INTO @EmployeeEmail, @StartDate
		END
	CLOSE cursor_Subscribes
	DEALLOCATE cursor_Subscribes
END

GO
CREATE OR ALTER PROCEDURE GetDeductionsByEmployee(@EmployeeEmail varchar(255), @ProjectName varchar(255))
AS
BEGIN
	SELECT S.EmployerEmail, S.ProjectName, S.SubscriptionName, S.ProviderName, S.SubscriptionDescription, S.Cost, S.TypeSubscription, S.IsEnabled
	FROM Agreement A RIGHT JOIN Subscription S ON A.EmployerEmail = S.EmployerEmail AND A.ProjectName = S.ProjectName
	WHERE S.TypeSubscription = 0 AND S.IsEnabled = 1 AND A.EmployeeEmail = @EmployeeEmail AND A.ProjectName = @ProjectName AND S.SubscriptionName NOT IN(SELECT SubscriptionName FROM Subscribes WHERE EmployeeEmail = @EmployeeEmail AND EndDate IS NULL)
END

GO
CREATE OR ALTER PROCEDURE GetBenefitsByEmployee(@EmployeeEmail varchar(255), @ProjectName varchar(255))
AS
BEGIN
	SELECT S.EmployerEmail, S.ProjectName, S.SubscriptionName, S.ProviderName, S.SubscriptionDescription, S.Cost, S.TypeSubscription, S.IsEnabled
	FROM Agreement A RIGHT JOIN Subscription S ON A.EmployerEmail = S.EmployerEmail AND A.ProjectName = S.ProjectName
	WHERE S.TypeSubscription = 1 AND S.IsEnabled = 1 AND A.EmployeeEmail = @EmployeeEmail AND A.ProjectName = @ProjectName AND S.SubscriptionName NOT IN(SELECT SubscriptionName FROM Subscribes WHERE EmployeeEmail = @EmployeeEmail AND EndDate IS NULL)
END

-- Subscribe Stored Procedures
GO
CREATE OR ALTER PROCEDURE GetEmployeesBySubscription(
	@EmployerEmail varchar(255),
	@ProjectName varchar(255),
	@SubscriptionName varchar(255))
AS
BEGIN
	SELECT * 
	FROM Subscribes 
	WHERE EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName
END

GO
CREATE OR ALTER PROCEDURE GetEmployeeBenefits(@EmployeeEmail varchar(255), @ProjectName varchar(255))
AS
BEGIN
	SELECT S.EmployeeEmail, S.EmployerEmail, S.ProjectName, S.SubscriptionName, S.Cost, S.StartDate, S.EndDate
	FROM Subscribes S RIGHT JOIN Subscription C ON 
		S.EmployerEmail = C.EmployerEmail AND
		S.ProjectName = C.ProjectName AND
		S.SubscriptionName = C.SubscriptionName
	WHERE S.EmployeeEmail = @EmployeeEmail AND C.IsEnabled = 1 AND C.TypeSubscription = 1 AND  S.ProjectName =  @ProjectName AND S.EndDate IS NULL
END

GO
CREATE OR ALTER PROCEDURE GetEmployeeDeductions(@EmployeeEmail varchar(255), @ProjectName varchar(255))
AS
BEGIN
	SELECT S.EmployeeEmail, S.EmployerEmail, S.ProjectName, S.SubscriptionName, S.Cost, S.StartDate, S.EndDate
	FROM Subscribes S RIGHT JOIN Subscription C ON 
		S.EmployerEmail = C.EmployerEmail AND
		S.ProjectName = C.ProjectName AND
		S.SubscriptionName = C.SubscriptionName
	WHERE S.EmployeeEmail = @EmployeeEmail AND C.IsEnabled = 1 AND C.TypeSubscription = 0 AND  S.ProjectName =  @ProjectName AND S.EndDate IS NULL
END

GO
CREATE OR ALTER PROCEDURE AddNewSubscribes(
	@EmployeeEmail varchar(255),
	@EmployerEmail varchar(255),
	@ProjectName varchar(255),
	@SubscriptionName varchar(255),
	@Cost float,
	@StartDate datetime,
	@TypeSubscription tinyint,
	@ErrorCode tinyint OUTPUT
)
AS
BEGIN
	SET @ErrorCode = 0
	IF @TypeSubscription = 0
		BEGIN
			SET @ErrorCode = 1
			INSERT INTO Subscribes (EmployeeEmail,EmployerEmail,ProjectName,SubscriptionName,Cost,StartDate)
			VALUES (@EmployeeEmail, @EmployerEmail, @ProjectName, @SubscriptionName, @Cost, @StartDate)
		END
	ELSE
		BEGIN
			DECLARE @MAFB float
			SELECT @MAFB = MaximumAmountForBenefits FROM Project WHERE EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName
			DECLARE @MBA int
			SELECT @MBA = MaximumBenefitAmount FROM Project WHERE EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName
			DECLARE @EmployeeAmountForBenefitCount float
			DECLARE @EmployeeBenefitAmountCount int
			SELECT @EmployeeAmountForBenefitCount = ISNULL(SUM(S.Cost), 0) + @Cost, @EmployeeBenefitAmountCount = COUNT(S.SubscriptionName) + 1
			FROM Subscribes S RIGHT JOIN Subscription C ON 
				S.EmployerEmail = C.EmployerEmail AND
				S.ProjectName = C.ProjectName AND
				S.SubscriptionName = C.SubscriptionName
			WHERE C.TypeSubscription = @TypeSubscription AND EmployeeEmail = @EmployeeEmail AND S.EndDate IS NULL
		
			IF(@MAFB = 0 AND @MBA = 0)
				BEGIN
					SET @ErrorCode = 1
					INSERT INTO Subscribes (EmployeeEmail,EmployerEmail,ProjectName,SubscriptionName,Cost,StartDate)
					VALUES (@EmployeeEmail, @EmployerEmail, @ProjectName, @SubscriptionName, @Cost, @StartDate)
				END
			IF(@MAFB > 0 AND @MBA = 0)
				BEGIN
					IF (@EmployeeAmountForBenefitCount <= @MAFB)
						BEGIN
							SET @ErrorCode = 1
							INSERT INTO Subscribes (EmployeeEmail,EmployerEmail,ProjectName,SubscriptionName,Cost,StartDate)
							VALUES (@EmployeeEmail, @EmployerEmail, @ProjectName, @SubscriptionName, @Cost, @StartDate)
						END
				END
			IF(@MAFB = 0 AND @MBA > 0)
				BEGIN
					IF (@EmployeeBenefitAmountCount <= @MBA)
						BEGIN
							SET @ErrorCode = 1
							INSERT INTO Subscribes (EmployeeEmail,EmployerEmail,ProjectName,SubscriptionName,Cost,StartDate)
							VALUES (@EmployeeEmail, @EmployerEmail, @ProjectName, @SubscriptionName, @Cost, @StartDate)
						END
				END
			IF(@MAFB > 0 AND @MBA > 0)
				BEGIN
					IF (@EmployeeBenefitAmountCount <= @MBA AND @EmployeeAmountForBenefitCount <= @MAFB)
						BEGIN
							SET @ErrorCode = 1
							INSERT INTO Subscribes (EmployeeEmail,EmployerEmail,ProjectName,SubscriptionName,Cost,StartDate)
							VALUES (@EmployeeEmail, @EmployerEmail, @ProjectName, @SubscriptionName, @Cost, @StartDate)
						END
				END
		END
END

GO
CREATE OR ALTER TRIGGER EndOfSubscribes
ON Subscribes INSTEAD OF DELETE
AS
BEGIN
	DECLARE @EndDate date
	SELECT @EndDate = CONVERT(date, GETDATE())
	
	DECLARE @EmployeeEmail varchar(255)
	DECLARE @EmployerEmail varchar(255)
	DECLARE @ProjectName varchar(255)
	DECLARE @SubscriptionName varchar(255)
	DECLARE @StartDate datetime
	SELECT @EmployeeEmail = D.EmployeeEmail, @EmployerEmail = D.EmployerEmail, @ProjectName = D.ProjectName, @SubscriptionName = D.SubscriptionName, @StartDate =  D.StartDate
	FROM deleted D

	UPDATE Subscribes
	SET EndDate = @EndDate
	WHERE EmployeeEmail = @EmployeeEmail AND EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName AND StartDate =  @StartDate
END

GO
CREATE OR ALTER PROCEDURE DeleteSubscribes(
	@EmployeeEmail varchar(255),
	@EmployerEmail varchar(255),
	@ProjectName varchar(255),
	@SubscriptionName varchar(255)
)
AS
BEGIN
	DELETE FROM Subscribes
	WHERE EmployeeEmail = @EmployeeEmail AND EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName 
END

-- Project Stored Procedures
GO 
CREATE OR ALTER PROCEDURE GetEmployerByEmail(@email VARCHAR(255))
AS
BEGIN
    SELECT * FROM Employer WHERE Employer.Email = @email 
END

GO

CREATE OR ALTER PROCEDURE ProjectNameCheck(@ProjectName VARCHAR(255))
AS
BEGIN
    SELECT * FROM Project WHERE Project.ProjectName = @ProjectName AND Project.IsEnabled = 1;
END

GO
CREATE OR ALTER PROCEDURE ModifyProject(
	@ProjectName varchar(255),
	@EmployerEmail varchar(255),
	@NewProjectName varchar(255),
	@NewProjectDescription varchar(600),
	@NewMaximumAmountForBenefits float,
	@NewMaximumBenefitAmount int,
	@NewPaymentInterval varchar(255)
) AS
BEGIN
	UPDATE Project
	SET ProjectName = @NewProjectName, ProjectDescription = @NewProjectDescription, MaximumAmountForBenefits = @NewMaximumAmountForBenefits, 
		MaximumBenefitAmount = @NewMaximumBenefitAmount,PaymentInterval = @NewPaymentInterval
	WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName;
END

GO
CREATE OR ALTER PROCEDURE DisableProject
(
	@ProjectName varchar(255),
	@EmployerEmail varchar(255)
) AS
BEGIN
	UPDATE Project
	SET IsEnabled = 0
	WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName;
END
GO
CREATE OR ALTER PROCEDURE UpdatePaymentDate(
	@ProjectName varchar(255),
	@EmployerEmail varchar(255),
	@LastPaymentDate date
) AS
BEGIN
	UPDATE Project
	SET LastPaymentDate = @LastPaymentDate
	WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName;
END

-- People Stored Procedures
GO
CREATE OR ALTER PROCEDURE GetPersonByEmail(@email varchar(255))
AS
BEGIN
    SELECT * FROM Person AS P WHERE P.Email = @email AND P.IsEnabled=1
END

GO
CREATE OR ALTER PROCEDURE UpdatePerson(
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
	WHERE Email=@EmailPerson AND IsEnabled=1
END

GO
CREATE OR ALTER PROCEDURE GetInfoPerson(@EmailPerson varchar(255))
AS
BEGIN
	SELECT Person.Email, Person.Name, Person.LastName1, Person.LastName2, Person.SSN, Person.BankAccount, 
	Person.Adress, Person.PhoneNumber, Person.IsEnabled
	FROM  Person WHERE Person.Email = @EmailPerson AND Person.IsEnabled=1
END

--Employer Stored Procedures

GO
CREATE OR ALTER PROCEDURE DeleteEmployer(
	@EmployerEmail varchar(255)
) AS
BEGIN
	UPDATE Person
	SET IsEnabled = 0
	WHERE Person.Email = @EmployerEmail;

END

-- Employee Stored Procedures
GO
CREATE OR ALTER PROCEDURE [dbo].[GetAllEmployees]
@projectName VARCHAR(255)
AS
BEGIN
	SELECT P.Email, P.Name, P.LastName1, P.LastName2, P.SSN, P.BankAccount, P.Adress, P.PhoneNumber, P.IsEnabled
	FROM Employee JOIN  Person AS P ON Employee.Email = P.Email left JOIN Agreement as A ON A.EmployeeEmail = Employee.Email
	Where A.ProjectName IS NULL OR A.ProjectName != @projectName OR A.IsEnabled <= 1
	Group by P.Email, P.Name, P.LastName1, P.LastName2, P.SSN, P.BankAccount, P.Adress, P.PhoneNumber, P.IsEnabled
END

GO
CREATE OR ALTER PROCEDURE [dbo].[GetProjectEmployees](
@projectName VARCHAR(255),
@employerEmail VARCHAR(255))
AS
BEGIN
	SELECT P.Email, P.Name, P.LastName1, P.LastName2, P.SSN, P.BankAccount, P.Adress, P.PhoneNumber, P.IsEnabled
	FROM Agreement as A JOIN  Person as P ON A.EmployeeEmail = P.Email
	Where A.ProjectName = @projectName AND A.IsEnabled = 1 AND A.EmployerEmail = @employerEmail
END

GO
CREATE OR ALTER PROCEDURE GetEmployeeByEmail(@email varchar(255))
AS
BEGIN
    SELECT * FROM Employee AS E WHERE E.Email = @email 
END

-- AgreementType Stored procedures

GO
CREATE OR ALTER PROCEDURE GetAllAgreementTypes
AS
BEGIN
	SELECT *
	FROM AgreementType AS ATP
END

GO
CREATE OR ALTER PROCEDURE checkAgreementType(
@AgreementType varchar(255),
@MountPerHour int) 
AS
BEGIN
	SELECT *
	FROM AgreementType AS ATP
	Where ATP.TypeAgreement = @AgreementType and ATP.MountPerHour = @MountPerHour
END

-- Agreements stored procedures

GO
CREATE OR ALTER PROCEDURE GetAllAgreementsByProjectAndEmployer(
@Project varchar(255), 
@EmployerEmail varchar(255))
AS
BEGIN
	SELECT *
	FROM Agreement as A
	WHERE A.ProjectName = @Project AND A.EmployerEmail = @EmployerEmail AND A.IsEnabled = 1 AND A.ContractFinishDate > GETDATE()
END

GO
CREATE OR ALTER PROCEDURE DesactivateAgreement(
@EmployeeEmail varchar(255), 
@EmployerEmail varchar(255),
@ProjectName varchar(255), 
@Justification varchar(max))
AS
BEGIN
	UPDATE Agreement
	SET Agreement.IsEnabled = -1, Agreement.Justification = @Justification, Agreement.ContractFinishDate = GETDATE()
	WHERE Agreement.EmployeeEmail = @EmployeeEmail AND Agreement.EmployerEmail = @EmployerEmail AND Agreement.ProjectName = @ProjectName;
END

GO
CREATE or ALTER PROCEDURE CheckAgreementTypeOfContractee(
@EmployeeEmail varchar(255), 
@EmployerEmail varchar(255), 
@ProjectName varchar(255), 
@ContractType varchar(255))
AS
BEGIN 
	SELECT * 
	FROM Agreement AS A 
	WHERE A.IsEnabled = 1 AND 
	A.EmployeeEmail = @EmployeeEmail AND 
	A.EmployerEmail = @EmployerEmail AND
	A.ProjectName = @ProjectName AND
	A.ContractType = @ContractType
END

--Payments stored procedures 
GO
CREATE OR ALTER PROCEDURE GetEmployeePayments
@employeeEmail VARCHAR(255)
AS
BEGIN
	SELECT *
	FROM Payment 
	Where EmployeeEmail = @employeeEmail;
END


GO
CREATE OR ALTER PROCEDURE CheckIfAgreementIsDesactivated(
@EmployeeEmail varchar(255), 
@EmployerEmail varchar(255),
@ProjectName varchar(255))
AS
BEGIN
	Select *
	From Agreement as A
	Where A.EmployeeEmail = @EmployeeEmail AND A.EmployerEmail = @EmployerEmail AND A.ProjectName = @ProjectName AND A.IsEnabled = -1 
END

GO
CREATE OR ALTER PROCEDURE UpdateAgreementStatus(
@EmployeeEmail varchar(255), 
@EmployerEmail varchar(255),
@ProjectName varchar(255),
@ContractStartDate date,
@ContractFinishDate date,
@ContractType varchar(255),
@MountPerHour int)
AS
BEGIN
	UPDATE Agreement
	SET Agreement.ContractStartDate = @ContractStartDate, Agreement.ContractType = @ContractType, 
	Agreement.MountPerHour = @MountPerHour, Agreement.ContractFinishDate = @ContractFinishDate,
	Agreement.IsEnabled = 1, Agreement.Justification = ''
	WHERE Agreement.EmployeeEmail = @EmployeeEmail AND Agreement.EmployerEmail = @EmployerEmail AND Agreement.ProjectName = @ProjectName and Agreement.IsEnabled <= 0;
END

--- Report Hours Stored Procedures
GO
CREATE OR ALTER PROCEDURE ApproveHoursReport(
@EmployeeEmail varchar(255), 
@EmployerEmail varchar(255),
@ProjectName varchar(255),
@ReportDate varchar(255) 
)
AS
BEGIN
	UPDATE ReportOfHours
	SET ReportOfHours.Approved = 1
	WHERE ReportOfHours.EmployeeEmail = @EmployeeEmail AND ReportOfHours.EmployerEmail = @EmployerEmail AND ReportOfHours.ProjectName = @ProjectName AND ReportOfHours.ReportDate = @ReportDate;
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
'62571204',
1
)

INSERT INTO Person
VALUES('leonel@ucr.ac.cr',
'Leonel',
'Campos',
'Murillo',
242342,
'CR40324350012',
'San José, Costa Rica',
'83355316',
1
)

INSERT INTO Person
VALUES('mau@ucr.ac.cr',
'Mauricio',
'Palma',
'Vitra',
8857655,
'CR4024220012',
'San José, Costa Rica',
'677774',
1
)

INSERT INTO Person
VALUES('naye@ucr.ac.cr',
'Nasheri',
'Azofeifa',
'Porras',
118070615,
'CR4024',
'San José, Costa Rica',
'89433965',
1
)

INSERT INTO Person
VALUES('wendy@ucr.ac.cr',
'Wendy',
'Ortiz',
'',
242342,
'CR40324350012',
'San José, Costa Rica',
'83355226',
1
)

INSERT INTO Person
VALUES('nyazofeifa3003@gmail.com',
'Nayeri',
'Azofeifa',
'Porras',
118070615,
'CR4024',
'San José, Costa Rica',
'89433965',
1
)

INSERT INTO Person
VALUES('nayeri.azofeifa@ucr.ac.cr',
'NayNay',
'Azofeifa',
'Porras',
118070615,
'CR4024',
'San José, Costa Rica',
'89433965',
1
)

INSERT INTO Employer
VALUES('leonel@ucr.ac.cr')

INSERT INTO Employer
VALUES('nyazofeifa3003@gmail.com')

INSERT INTO Employer
VALUES('wendy@ucr.ac.cr')

INSERT INTO Employee
VALUES('mau@ucr.ac.cr')

INSERT INTO Employee
VALUES('jeremy@ucr.ac.cr')

INSERT INTO Employee
VALUES('naye@ucr.ac.cr')

INSERT INTO Employee
VALUES('nayeri.azofeifa@ucr.ac.cr')

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Emprendimiento de chocolates',
15000,
10,
'Quincenal',
1,
'2022-06-14'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Dulces artesanales',
'Emprendimiento de confites',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Armario Vintage',
'Emprendimiento de camisetas',
40000,
12,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Fragancias Doradas',
'Emprendimiento de perfumes',
20000,
5,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('wendy@ucr.ac.cr',
'Fabrica de chocolates',
'Emprendimiento de comida',
20000,
5,
'Mensual',
1,
'2022-06-14'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Kaites',
'Emprendimiento de zapatos',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Peluches felices',
'Emprendimiento de peluches',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'CarmelArt',
'Emprendimiento artesanal',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Tech Solutions',
'Emprendimiento tecnológico',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'La Hilita',
'Emprendimiento de costura',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)


INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Vanidosa',
'Salón de belleza',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Super Praga',
'Pulperia',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Asian Bay',
'Chino',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'El pueblo',
'Pulperia',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Project
VALUES('leonel@ucr.ac.cr',
'Trendy Purse',
'Emprendimiento de bolsos',
22000,
7,
'Quincenal',
1,
'2022-06-28'
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Deducción Ejemplo',
'Ejemplo',
'Ejemplo',
200000,
0,
1
)


INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Fondo de pensiones',
'CCSS',
'Contribuición voluntaria para el fondo de pensiones.',
12000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Ayudemos a los niños',
'Hospital de los niños',
'Cuota voluntaria para ayudar a los más necesitados.',
25000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Rescate de perros',
'Refugio de perros',
'Cuota voluntaria para ayudar a los más necesitados.',
12000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Gym',
'Golden Gym',
'Gimnasio equipado con todo lo necesario.',
25000,
1,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Piscina',
'Aquanautas',
'Piscinas temperadas, ubicadas en San Pedro.',
12000,
1,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Starbucks descuento',
'Starbucks',
'Descuento en un starbucks',
12000,
0,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Dulces artesanales',
'Apple del futuro',
'Apple',
'Subscripción futura',
55000,
0,
1
)


INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Dulces artesanales',
'Gym',
'Golden Gym',
'Gimnasio equipado con todo lo necesario.',
25000,
1,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Dulces artesanales',
'Piscina',
'Aquanautas',
'Piscinas temperadas, ubicadas en San Pedro.',
12000,
1,
1
)

INSERT INTO Subscription
VALUES('leonel@ucr.ac.cr',
'Dulces artesanales',
'Starbucks descuento',
'Starbucks',
'Descuento en un starbucks',
12000,
0,
1
)

INSERT INTO AgreementType
VALUES('Tiempo completo', 1600)

INSERT INTO AgreementType
VALUES('Servicios profesionales', 2000)

INSERT INTO AgreementType
VALUES('Medio tiempo', 1600)

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Fabrica de chocolates','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Dulces artesanales','2022-06-1','Servicios profesionales', 2000, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Armario Vintage','2022-06-1','Medio tiempo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Fragancias Doradas','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('mau@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Fabrica de chocolates','2022-06-1','Servicios profesionales', 2000, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('naye@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Fabrica de chocolates','2022-06-1','Medio tiempo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('naye@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Dulces artesanales','2022-06-1','Medio tiempo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Kaites','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Peluches felices','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'CarmelArt','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Tech Solutions','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'La Hilita','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Vanidosa','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Super Praga','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Asian Bay','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'El pueblo','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')

INSERT INTO Agreement
VALUES('jeremy@ucr.ac.cr', 'leonel@ucr.ac.cr', 'Trendy Purse','2022-06-1','Tiempo completo', 1600, '2026-06-1', 1, '')


INSERT INTO ReportOfHours
VALUES('leonel@ucr.ac.cr', 'Fabrica de chocolates','mau@ucr.ac.cr', '2022-06-15',4.0 ,0)

INSERT INTO ReportOfHours
VALUES('leonel@ucr.ac.cr', 'Fabrica de chocolates','mau@ucr.ac.cr', '2022-06-17',5.0 ,0)

INSERT INTO ReportOfHours
VALUES('leonel@ucr.ac.cr', 'Fabrica de chocolates','mau@ucr.ac.cr', '2022-06-20',8.0 ,0)


INSERT INTO Subscribes (EmployerEmail, ProjectName, SubscriptionName, EmployeeEmail, Cost, StartDate)
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Ayudemos a los niños',
'jeremy@ucr.ac.cr',
25000,
'2022-06-1'
)

INSERT INTO Subscribes (EmployerEmail, ProjectName, SubscriptionName, EmployeeEmail, Cost, StartDate)
VALUES('leonel@ucr.ac.cr',
'Fabrica de chocolates',
'Gym',
'jeremy@ucr.ac.cr',
12000,
'2022-06-2'
)

INSERT INTO Subscribes (EmployerEmail, ProjectName, SubscriptionName, EmployeeEmail, Cost, StartDate)
VALUES('leonel@ucr.ac.cr',
'Dulces artesanales',
'Gym',
'jeremy@ucr.ac.cr',
12000,
'2022-06-2'
)

INSERT INTO LegalDeduction (DeductionName, Cost)
VALUES('CCSS',
25000.3
)

INSERT INTO LegalDeduction (DeductionName, Cost)
VALUES('Hacienda',
48000.3
)

--select * from Agreement order by ProjectName

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Armario Vintage',153600, '2022-06-01', '2022-06-14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Armario Vintage',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Asian Bay',153600, '2022/06/1', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Asian Bay',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','CarmelArt',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','CarmelArt',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Dulces artesanales',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Dulces artesanales',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('naye@ucr.ac.cr','leonel@ucr.ac.cr','Dulces artesanales',75000, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('naye@ucr.ac.cr','leonel@ucr.ac.cr','Dulces artesanales',75000, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','El pueblo',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','El pueblo',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Fabrica de chocolates',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('naye@ucr.ac.cr','leonel@ucr.ac.cr','Fabrica de chocolates',75000, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('mau@ucr.ac.cr','leonel@ucr.ac.cr','Fabrica de chocolates',100000, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Fragancias Doradas',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Fragancias Doradas',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Kaites',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Kaites',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','La Hilita',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','La Hilita',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Peluches felices',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Peluches felices',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Super Praga',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Super Praga',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Tech Solutions',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Tech Solutions',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Trendy Purse',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Trendy Purse',153600, '2022/06/15', '2022/06/28')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Vanidosa',153600, '2022/06/01', '2022/06/14')

INSERT INTO Payment
VALUES('jeremy@ucr.ac.cr','leonel@ucr.ac.cr','Vanidosa',153600, '2022/06/15', '2022/06/28')