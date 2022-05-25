CREATE PROCEDURE SetAuthenticationState(@email varchar(255), @state bit)
AS
BEGIN
    UPDATE Account
    SET IsAuthenticated = @state
    WHERE Email = @email;
END