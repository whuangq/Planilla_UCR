CREATE PROCEDURE GetAuthenticationState(@UserEmail varchar(255))
AS
BEGIN
    SELECT *
	FROM Account AS A 
	WHERE A.Email = @UserEmail AND A.IsAuthenticated = 1
END