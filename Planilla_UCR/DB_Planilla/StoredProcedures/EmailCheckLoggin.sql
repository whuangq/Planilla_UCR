
CREATE Procedure EmailCheckLoggin(@UserEmail varchar(500))
AS
BEGIN
    Select * from Account where Account.Email = @UserEmail
END