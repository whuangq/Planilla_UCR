
CREATE Procedure EmailCheckLoggin(@UserEmail varchar(255), @UserPassword varchar(255))
AS
BEGIN
    Select * from Account where Account.Email = @UserEmail
END