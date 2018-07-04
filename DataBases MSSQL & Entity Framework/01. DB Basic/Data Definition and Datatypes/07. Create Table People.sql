CREATE TABLE People(
Id INT IDENTITY,
Name NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height NUMERIC(3,2),
Weight NUMERIC(5,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX),
CONSTRAINT PK_People PRIMARY KEY (Id),
CONSTRAINT CK_People_Gender CHECK(Gender = 'm' OR Gender = 'f')
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('Pesho', 010101010, 1.123, 1.43, 'm', '1995/12/02', 'kazvam se stoqn.'),
('Goshoslav', 01010100101, 1.123, 1.43, 'm', '1995/12/02', 'idvam ot mesopotamiq'),
('Piper', 01010101001, 1.123, 1.43, 'm', '1995/12/02', 'kmaika mi e bobur'),
('Kaloqn', 010101001, 1.123, 1.43, 'm', '1995/12/02', 'ne nosq chorapi'),
('Prakash', 010101010, 1.123, 1.43, 'm', '1995/12/02', 'imam strah ot pustri cvetove')