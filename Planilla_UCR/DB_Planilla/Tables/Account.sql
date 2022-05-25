CREATE TABLE Account
(
	Email varchar(255) NOT NULL PRIMARY KEY,
	UserPassword VARBINARY(500) NOT NULL,
	[IsAuthenticated] BIT NOT NULL, 
    FOREIGN KEY(Email) REFERENCES Person(Email),
);
