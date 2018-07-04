CREATE TABLE Directors(
Id INT IDENTITY,
DirectorName VARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX),
CONSTRAINT PK_Directors PRIMARY KEY (Id)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES
('Vasko', 'ne nosq belyo na rabota'),
('Vesko', 'ne nosq belyo na rebota'),
('Petran', 'spq gol'),
('Blagoi', 'ne moga da spq'),
('Kondyo', NULL)


CREATE TABLE Genres(
Id INT IDENTITY,
GenreName VARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX),
CONSTRAINT PK_Genres PRIMARY KEY (Id)
)

INSERT INTO Genres(GenreName, Notes)
VALUES
('Comedy', NULL),
('Horror', 'mn stra6no, ujas'),
('KindOfHorror', 'mn malko strashno, ne ujas'),
('Action', 'mqsa na Rambo'),
('Boring', 'neshto tursko')


CREATE TABLE Categories(
Id INT IDENTITY,
CategoryName VARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX),
CONSTRAINT PK_Categories PRIMARY KEY (Id)
)


INSERT INTO Categories(CategoryName, Notes)
VALUES
('category1', NULL),
('category2', NULL),
('category3', 'taq kategoriq e skuchna'),
('category 4', NULL),
('category5', 'taq kategoriq ne e skuchna')

CREATE TABLE Movies(
Id INT IDENTITY,
Title VARCHAR(50) NOT NULL,
DirectorId INT NOT NULL,
CopyrightYear DATE NOT NULL,
Length TIME NOT NULL,
GenreId INT NOT NULL,
CategoryId INT NOT NULL,
Rating INT NOT NULL,
Notes NVARCHAR(MAX)
CONSTRAINT PK_Movies PRIMARY KEY (Id)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
('Dim bez cvqt1', 1, '04/04/1993', '09:08:44', 1, 2, 0, NULL),
('Dim bez cvqt2', 1, '04/04/1993', '09:08:44', 1, 2, 0, NULL),
('Dim bez cvqt3', 1, '04/04/1993', '09:08:44', 1, 2, 0, NULL),
('Dim bez cvqt4', 1, '04/04/1993', '09:08:44', 1, 2, 0, NULL),
('Dim bez cvqt5', 1, '04/04/1993', '09:08:44', 1, 2, 0, NULL)