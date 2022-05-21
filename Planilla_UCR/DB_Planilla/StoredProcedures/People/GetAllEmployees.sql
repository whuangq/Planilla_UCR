CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
	SELECT Employee.Email, Person.Name, Person.LastName1, Person.LastName2, Person.SSN, Person.BankAccount, Person.Adress, Person.PhoneNumber
	FROM Employee JOIN  Person ON Employee.Email = Person.Email
END
