CREATE TABLE [dbo].[Table]
(
	[RequestID] INT NOT NULL PRIMARY KEY,
	FirstName VARCHAR(10)  NOT NULL, 
	LastName VARCHAR(10) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	ApartmentName VARCHAR(25) NOT NULL,
	UnitNumber INT NOT NULL,
	MaintenanceRequired VARCHAR(100) NOT NULL,
	TimeOfRequest DATETIME NOT NULL
)
