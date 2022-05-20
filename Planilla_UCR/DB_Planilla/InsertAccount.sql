CREATE PROCEDURE [dbo].[InsertAccount]
	@EmailAccount varchar(255),
	@PasswordAccount nvarchar(255)
AS
	insert into Account values (
	@EmailAccount,
	ENCRYPTBYPASSPHRASE('EncryptedPassword',@PasswordAccount))
