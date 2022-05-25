Create proc InsertDataToAccountWithPasswordEncripted(@EmailAccount varchar(255),@UserPasswordToEncrypt varchar(255))
As 
Declare @UserPassword varbinary(150)
Declare @EncryptedPassword varbinary(150)
Set @UserPassword = CONVERT(varbinary(150),@UserPasswordToEncrypt);
Set @EncryptedPassword = HASHBYTES('SHA2_256', @UserPassword);
Insert into Account values (@EmailAccount, @EncryptedPassword, 1) 