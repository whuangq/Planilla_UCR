CREATE PROCEDURE GetInfoEmployer(@EmailEmployer varchar(255))
AS
BEGIN
	SELECT Person.Email, Person.Name, Person.LastName1, Person.LastName2, Person.SSN, Person.BankAccount, Person.Adress, Person.PhoneNumber
	FROM  Person JOIN Employer ON  Person.Email  = Employer.Email where Employer.Email = @EmailEmployer
END
