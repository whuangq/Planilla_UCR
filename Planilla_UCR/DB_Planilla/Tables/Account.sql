CREATE TABLE Account
(
	Email varchar(255) NOT NULL PRIMARY KEY,
	Password varchar(255) NOT NULL
	FOREIGN KEY(Email) REFERENCES Person(Email)
);
