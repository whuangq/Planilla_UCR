CREATE PROCEDURE GetInfoEmployer(@EmailEmployer varchar(255))
AS
BEGIN
	SELECT Employer.Email, Person.Name, Person.LastName1, Person.LastName2, Person.SSN, Person.BankAccount, Person.Adress, Person.PhoneNumber
FROM Employer JOIN  Person ON Employer.Email = Person.Email where Employer.Email = @EmailEmployer
END