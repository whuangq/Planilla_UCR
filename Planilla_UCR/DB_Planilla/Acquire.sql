CREATE TABLE Acquire(
	ContractEmployeeEmail varchar(255) NOT NULL,
	ContractEmployerEmail varchar(255) NOT NULL,
	ContractProyectName varchar(255) NOT NULL,
	ContractDate date NOT NULL,
	ProjectEmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	BenefictEmployerEmail varchar(255) NOT NULL,
	BenefictName varchar(255) NOT NULL,
	PRIMARY KEY(ContractEmployeeEmail, ContractEmployerEmail, ContractProyectName, ContractDate, ProjectEmployerEmail, ProjectName, BenefictEmployerEmail, BenefictName),
	FOREIGN KEY(ContractEmployeeEmail, ContractEmployerEmail, ContractProyectName, ContractDate) REFERENCES Agreement(EmployeeEmail, EmployerEmail, ProjectName, ContractDate),
	FOREIGN KEY(ProjectEmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName),
	FOREIGN KEY(BenefictEmployerEmail, BenefictName) REFERENCES Subscription(EmployerEmail, NameSubscription)
);