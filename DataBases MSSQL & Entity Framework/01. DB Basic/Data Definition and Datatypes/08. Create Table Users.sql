CREATE TABLE Users(
Id INT IDENTITY,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(900),
LastLoginTime DATETIME,
IsDeleted BIT DEFAULT 0,
CONSTRAINT PK_Users PRIMARY KEY (Id),
)

INSERT INTO Users
VALUES
('4ernotoZlo', 'parola123', 010101010, '05/05/2018', 0),
('username1', 'parola123', 010101010, '05/05/2018', 0),
('username2', 'parola123', 010101010, '05/05/2018', 0),
('username3', 'parola123', 010101010, '05/05/2018', 0),
('username4', 'parola123', 010101010, '05/05/2018', 0)