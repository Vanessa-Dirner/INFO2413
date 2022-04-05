CREATE PROC StaffAddorEdit
@userid      INT,
@firstName   VARCHAR (50),
@lastName    VARCHAR (50),
@jobRole     VARCHAR (50),
@eMail      VARCHAR (50),
@userName    VARCHAR (50),
@passwordKey VARCHAR (50)
AS
	IF @userid = 0
	BEGIN
		INSERT INTO staff (firstName, lastName, jobRole, eMail, userName, passwordKey)
		VALUES (@firstName, @lastName, @jobRole, @eMail, @userName, @passwordKey)

	END 
	ELSE 
	BEGIN
		UPDATE staff
		SET 
			firstName = @firstName,
			lastName = @lastName,
			jobRole = @jobRole,
			eMail = @eMail,
			userName = @userName,
			passwordKey = @passwordKey
		WHERE userid = @userid
	END 