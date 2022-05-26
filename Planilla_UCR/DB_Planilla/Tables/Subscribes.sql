CREATE TABLE Subscribes(
	SubscriptionEmployerEmail varchar(255) NOT NULL,
	SubscriptionProjectName varchar(255) NOT NULL,
	SubscriptionName varchar(255) NOT NULL,
	EmployeeEmail varchar(255) NOT NULL,
	StartDate date NOT NULL,
	EndDate date,
	PRIMARY KEY(SubscriptionEmployerEmail, SubscriptionProjectName, SubscriptionName, EmployeeEmail),
	FOREIGN KEY(SubscriptionEmployerEmail, SubscriptionProjectName, SubscriptionName) REFERENCES Subscription(EmployerEmail, ProjectName, SubscriptionName),
	FOREIGN KEY(EmployeeEmail) REFERENCES Employee(Email)
);