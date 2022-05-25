CREATE PROCEDURE PasswordCheckLoggin(@UserEmail varchar(255), @UserPassword varchar(255))
AS
BEGIN
	Select * from Account where [UserPassword] =  HASHBYTES('SHA2_256',@UserPassword) AND Account.Email = @UserEmail
END