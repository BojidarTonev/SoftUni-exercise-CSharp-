CREATE TABLE Teachers(
  TeacherID INT IDENTITY,
  Name NVARCHAR(50) NOT NULL,
  ManagerID INT,
  CONSTRAINT PK_Teachers PRIMARY KEY (TeacherID),
  CONSTRAINT FK_Teachers_Managers FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)