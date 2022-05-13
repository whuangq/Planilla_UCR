CREATE TABLE Project(
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	ProjectDescription varchar(255),
	MaximumAmountForBenefits int, 
	MaximumBenefitAmount int,
	PaymentInterval varchar(255),
	PRIMARY KEY(EmployerEmail, ProjectName),
	FOREIGN KEY(EmployerEmail) REFERENCES Employer(Email)
);