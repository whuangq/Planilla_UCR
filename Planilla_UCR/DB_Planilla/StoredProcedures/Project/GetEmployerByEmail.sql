CREATE Procedure GetEmployerByEmail(@email varchar(255))
AS
BEGIN
    Select * from Employer where Employer.Email = @email
END