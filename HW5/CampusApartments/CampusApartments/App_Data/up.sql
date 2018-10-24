--Requests Table
CREATE TABLE [dbo].[Requests]
(
	[RequestID]        INT IDENTITY (1,1)    NOT NULL,
    [FirstName]    NVARCHAR(64)        NOT NULL,
    [LastName]    NVARCHAR(128)        NOT NULL,
	[PhoneNumber] NVARCHAR(15) NOT NULL,
	[ApartmentName] NVARCHAR(25) NOT NULL,
	[UnitNumber] INT NOT NULL,
	[MaintenanceRequired] NVARCHAR(1000) NOT NULL,
    [TimeOfRequest]        DateTime            NOT NULL,
    CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([RequestID] ASC)
);

INSERT INTO [dbo].[Requests] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, MaintenanceRequired, TimeOfRequest) VALUES
    ('Dean', 'Chase', '(609) 452-9112', 'Cedar', 5, 'The toilet is plugged.','2018-10-22 01:20:00'),
    ('Muriel', 'Shaffer', '(944) 212-0880', 'Willow', 1, 'The kitchen sink is leaking.','2018-10-12 02:00:00'),
    ('Erasmo', 'Brandt', '(660) 295-2306', 'Cedar', 2, 'I just moved in and like 10 of the light bulbs are dead. The bathroom upstairs is also super disgusting.','2018-10-22 03:30:00'),
	('Terrance', 'Walsh', '(973) 450-7157', 'Spruce', 8, 'The neighbors are being really loud. Make it stop.','2018-10-21 12:30:15'),
    ('Paulette', 'Daniels', '(201) 697-5077', 'Willow', 3, 'We are missing a screen on one of the windows. Can we get one?','2018-10-25 01:45:14')
GO