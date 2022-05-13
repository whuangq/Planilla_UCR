CREATE TABLE Subscription
(
	EmployerEmail varchar(255) NOT NULL,
	NameSubscription varchar(255) NOT NULL,
	Cost int NOT NULL,
	TypeSubscription int NOT NULL,
	PRIMARY KEY(EmployerEmail, NameSubscription),
	FOREIGN KEY(EmployerEmail) REFERENCES Employer(Email)
);
