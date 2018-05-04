CREATE PROCEDURE sp_User_Search_Paged
	@SearchText nvarchar(200),
	@PageIndex int,
	@PageSize int,
	@TotalRecord int OUTPUT
AS
BEGIN
	SELECT @TotalRecord = COUNT(a.Id)
	FROM System_Users a
	WHERE a.UserName LIKE '%' + @SearchText + '%' 
		OR a.PhoneNumber = @SearchText 
		OR a.Email = @SearchText;
	 
	WITH TABLE_NEW AS
	(
		 SELECT a.Id
			  ,a.UserName
			  ,a.FullName
			  ,a.PhoneNumber
			  ,a.Email
			  ,a.IsLockedOut
			  ,a.SuperUser
			  ,ROW_NUMBER() OVER (ORDER BY a.Id) AS RowNumber
		 FROM System_Users a
		 WHERE a.UserName LIKE '%' + @SearchText + '%' 
		 OR a.PhoneNumber = @SearchText 
		 OR a.Email = @SearchText
	) 
	SELECT * FROM TABLE_NEW 
	WHERE TABLE_NEW.RowNumber BETWEEN ((@PageIndex - 1) * @PageSize + 1) AND (@PageIndex * @PageSize);
END
GO
CREATE PROCEDURE sp_User_ByRoles_Paged
	@SearchText nvarchar(200),
	@RoleId int,
	@PageIndex int,
	@PageSize int,
	@TotalRecord int OUTPUT
AS
BEGIN
	SELECT @TotalRecord = COUNT(a.Id)
	FROM System_Users a INNER JOIN System_UsersInRoles b ON a.Id = b.UserId
	WHERE 
	(
		a.UserName LIKE '%' + @SearchText + '%' 
		OR a.PhoneNumber = @SearchText 
		OR a.Email = @SearchText
	) 
	AND (b.RoleId = @RoleId OR @RoleId = 0);
	 
	WITH TABLE_NEW AS
	(
		 SELECT a.Id
			  ,a.UserName
			  ,a.FullName
			  ,a.PhoneNumber
			  ,a.Email
			  ,a.IsLockedOut
			  ,a.SuperUser
			  ,ROW_NUMBER() OVER (ORDER BY a.Id) AS RowNumber
		 FROM System_Users a INNER JOIN System_UsersInRoles b ON a.Id = b.UserId
		 WHERE 
		(
			a.UserName LIKE '%' + @SearchText + '%' 
			OR a.PhoneNumber = @SearchText 
			OR a.Email = @SearchText 
		) 
		AND (b.RoleId = @RoleId OR @RoleId = 0) 
	) 
	SELECT * FROM TABLE_NEW 
	WHERE TABLE_NEW.RowNumber BETWEEN ((@PageIndex - 1) * @PageSize + 1) AND (@PageIndex * @PageSize);
END
GO
CREATE PROCEDURE sp_User_GetById
	@Id int
AS
BEGIN
	SELECT * FROM System_Users WHERE Id = @Id;
END
GO
CREATE PROCEDURE sp_User_GetRolesByUserId
	@UserId int
AS
BEGIN
	SELECT a.Id, a.Name 
	FROM System_Roles a INNER JOIN System_UsersInRoles b ON a.Id = b.RoleId 
	WHERE b.UserId = @UserId;
END
GO
CREATE PROCEDURE sp_User_GetUserByUserName
	@UserName nvarchar(255)
AS
BEGIN
	SELECT * FROM System_Users WHERE UserName = @UserName;
END
GO
CREATE PROCEDURE sp_User_GetUserByEmail
	@Email nvarchar(255)
AS
BEGIN
	SELECT * FROM System_Users WHERE Email = @Email;
END
GO
CREATE PROCEDURE sp_LocalAccountsUser_GetByUserId
	@UserId int
AS
BEGIN
	SELECT * FROM System_LocalAccounts WHERE UserId = @UserId;
END
GO
CREATE PROCEDURE sp_LocalAccountsUser_GetByConfirmationToken
	@ConfirmationToken nvarchar(max)
AS
BEGIN
	SELECT * FROM System_LocalAccounts WHERE ConfirmationToken = @ConfirmationToken;
END
GO
CREATE PROCEDURE sp_LocalAccountsUser_GetByPasswordVerificationToken
	@PasswordVerificationToken nvarchar(max)
AS
BEGIN
	SELECT * FROM System_LocalAccounts WHERE PasswordVerificationToken = @PasswordVerificationToken;
END
GO
CREATE PROCEDURE sp_User_Delete
	@UserId int
AS
BEGIN
	Delete From System_LocalAccounts WHERE UserId = @UserId;
	Delete From System_UsersInRoles WHERE UserId = @UserId;
	Delete From System_Users WHERE Id = @UserId;
END
GO
CREATE PROCEDURE sp_UsersInRoles_GetByUserId
	@UserId int
AS
BEGIN
	SELECT * FROM System_UsersInRoles WHERE UserId = @UserId;
END
GO
CREATE PROCEDURE sp_UsersInRoles_GetByRoleId
	@RoleId int
AS
BEGIN
	SELECT * FROM System_UsersInRoles WHERE RoleId = @RoleId;
END
GO
CREATE PROCEDURE sp_UserProfiles_GetByUserId
	@UserId int
AS
BEGIN
	SELECT * FROM System_UserProfiles WHERE UserId = @UserId;
END
GO
CREATE PROCEDURE sp_Zones_GetByName
	@Name nvarchar(255)
AS
BEGIN
	SELECT TOP(1) * FROM System_Zones WHERE Name = @Name;
END
GO
CREATE PROCEDURE sp_Widgets_GetByZone
	@ZoneId INT
AS
BEGIN
	SELECT TOP(1) * FROM System_Widgets WHERE ZoneId = @ZoneId AND Enabled = 1;
END
GO
CREATE PROCEDURE sp_QueuedEmails_GetMessages_Paged
	@SentTries int,
	@SentOnUtc datetime,
	@PageIndex int,
	@PageSize int,
	@TotalRecord int OUTPUT
AS
BEGIN
	declare @start as int;
	declare @end as int;
	set @start = @PageSize * (@PageIndex-1) + 1;
	set @end = @PageSize * @PageIndex;

	declare @query as nvarchar(max);
	SET @query = ' (1=1) ';

	IF (@SentTries != -1)
		SET @query += ' AND SentTries <= ' + STR(@SentTries);
	
	IF @SentOnUtc != '01/01/1900'
		SET @query += ' AND Convert(DateTime, Convert(VarChar, SentOnUtc, 101)) >= '+ CHAR(39)+ CONVERT(nvarchar,@SentOnUtc,121)+ CHAR(39); 

	DECLARE @Temp table(TotalRecord int);
	INSERT INTO @Temp EXEC ('SELECT COUNT(Id) FROM System_QueuedEmails WHERE ' + @query);
	SELECT @TotalRecord = TotalRecord FROM @Temp;
	exec
	(
		'WITH #TABLE_NEW AS
		(
			SELECT a.*, ROW_NUMBER() OVER (ORDER BY a.CreatedOnUtc ASC) AS RowNumber
			FROM System_QueuedEmails a WHERE ' + @query + 	
		') 
		SELECT * FROM #TABLE_NEW 
		WHERE RowNumber BETWEEN '+ @start  +'  AND  '+ @end
	);
END