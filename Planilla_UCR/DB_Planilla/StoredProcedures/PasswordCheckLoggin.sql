CREATE PROCEDURE PasswordCheckLoggin(@UserEmail varchar(500), @UserPassword varchar(500))
AS
BEGIN
	Select * from Account where [UserPassword] =  HASHBYTES('SHA2_256',@UserPassword) AND Account.Email = @UserEmail
END