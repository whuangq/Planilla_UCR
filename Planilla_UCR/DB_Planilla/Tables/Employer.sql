CREATE TABLE Employer(
	Email varchar(255) NOT NULL PRIMARY KEY,
	FOREIGN KEY(Email) REFERENCES Person(Email)
);