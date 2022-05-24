use [DB_Planilla]

INSERT INTO Person
VALUES('jeremy@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
'117810140',
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Employer
VALUES('jeremy@ucr.ac.cr')

INSERT INTO Project
VALUES('jeremy@ucr.ac.cr',
'Proyecto 1',
'Emprendimiento de chocolates',
15000,
10,
'Mensual')

INSERT INTO Project
VALUES('jeremy@ucr.ac.cr',
'Proyecto 2',
'Emprendimiento de candelas',
15000,
10,
'Mensual')

select *
from Subscription

DROP TABLE Subscription

CREATE PROCEDURE GetAllDeductions
AS
BEGIN
    SELECT * FROM Subscription WHERE TypeSubscription=0 and IsEnabled=1
END

CREATE PROCEDURE GetAllBenefits
AS
BEGIN
    SELECT * FROM Subscription WHERE TypeSubscription=1 and IsEnabled=1
END