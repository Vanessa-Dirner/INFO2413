CREATE PROC staffViewByID
@userid int 
AS 
	SELECT *
	FROM staff
	WHERE userid = @userid