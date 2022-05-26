CREATE Procedure ProjectNameCheck(@ProjectName varchar(255))
AS
BEGIN
    Select * from Project where Project.ProjectName = @ProjectName
END