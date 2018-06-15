CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(100), @word VARCHAR(100))
RETURNS BIT
AS
BEGIN
      DECLARE @IsThere BIT = 0
	  DECLARE @CurrentChar CHAR(1)
	  DECLARE @CurrentIndex INT = 1
	  DECLARE @Final INT = LEN(@word)

	  WHILE(@CurrentIndex <= @Final)
	  BEGIN
		    SET @CurrentChar = SUBSTRING(@word, @CurrentIndex, 1)
			IF(CHARINDEX(@CurrentChar, @setOfLetters) = 0)
			 RETURN @IsThere
			SET @CurrentIndex += 1
	  END
	  RETURN @IsThere + 1
END
