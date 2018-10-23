CREATE TABLE Requests
(
	[RequestID] INT NOT NULL PRIMARY KEY,
	FirstName VARCHAR(10)  NOT NULL, 
	LastName VARCHAR(10) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	ApartmentName VARCHAR(25) NOT NULL,
	UnitNumber INT NOT NULL,
	MaintenanceRequired VARCHAR(100) NOT NULL,
	TimeOfRequest DATE NOT NULL
);

INSERT INTO Requests
VALUES("Dean", "Chase", "(609) 452-9112", "Cedar", 5, "The toilet is plugged.", "2018-10-12");

INSERT INTO Requests
VALUES("Muriel", "Shaffer", "(944) 212-0880", "Willow", 1, "The kitchen sink is leaking.", "2018-10-08");

INSERT INTO Requests
VALUES("Erasmo", "Brandt", "(660) 295-2306", "Cedar", 2, "I just moved in and like 10 of the light bulbs are dead. The bathroom upstairs is also super disgusting.", "2018-10-20");

INSERT INTO Requests
VALUES("Terrance", "Walsh", "(973) 450-7157", "Spruce", 8, "The neighbors are being really loud. Make it stop.", "2018-10-22");

INSERT INTO Requests
VALUES("Paulette", "Daniels", "(201) 697-5077", "Willow", 3, "We are missing a screen on one of the windows. Can we get one?", "2018-10-10");
