CREATE SEQUENCE RequestSequence
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 999;

CREATE TABLE Requests
(
	[RequestID] INT NOT NULL PRIMARY KEY,
	FirstName VARCHAR(10)  NOT NULL, 
	LastName VARCHAR(10) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	ApartmentName VARCHAR(25) NOT NULL,
	UnitNumber INT NOT NULL,
	MaintenanceRequired VARCHAR(100) NOT NULL,
	TimeOfRequest DATETIME NOT NULL
);

INSERT INTO Requests (RequestID, FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, MaintenanceRequired, TimeOfRequest)
VALUES
	(RequestSequence.NEXTVAL, 'Dean', 'Chase', '(609) 452-9112', 'Cedar', 5, 'The toilet is plugged.', (SYSDATETIME()-2)),
	(RequestSequence.NEXTVAL, 'Muriel', 'Shaffer', '(944) 212-0880', 'Willow', 1, 'The kitchen sink is leaking.', (SYSDATETIME()-4)),
	(RequestSequence.NEXTVAL, 'Erasmo', 'Brandt', '(660) 295-2306', 'Cedar', 2, 'I just moved in and like 10 of the light bulbs are dead. The bathroom upstairs is also super disgusting.', (SYSDATETIME()-14)),
	(RequestSequence.NEXTVAL, 'Terrance', 'Walsh', '(973) 450-7157', 'Spruce', 8, 'The neighbors are being really loud. Make it stop.', (SYSDATETIME()-3)),
	(RequestSequence.NEXTVAL, 'Paulette', 'Daniels', '(201) 697-5077', 'Willow', 3, 'We are missing a screen on one of the windows. Can we get one?', '2018-10-10', (SYSDATETIME()-9));