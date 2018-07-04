CREATE TABLE Manufacturers(
	ManufacturerID INT IDENTITY,
	Name VARCHAR(60) NOT NULL,
	EstablishedOn DATE NOT NULL,
	CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)
)

CREATE TABLE Models(
	ModelID INT IDENTITY,
	Name VARCHAR(60) NOT NULL,
	ManufacturerID INT NOT NULL,
	CONSTRAINT PK_Models PRIMARY KEY (ModelID),
	CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) REFERENCES  Manufacturers(ManufacturerID)
)