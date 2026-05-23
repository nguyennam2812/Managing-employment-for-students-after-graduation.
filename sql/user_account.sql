IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserAccount]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[UserAccount](
        [UserAccountId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Username] NVARCHAR(100) NOT NULL UNIQUE,
        [PasswordHash] NVARCHAR(512) NOT NULL,
        [PasswordSalt] NVARCHAR(256) NULL,
        [Role] NVARCHAR(50) NULL,
        [IsActive] BIT NOT NULL DEFAULT(1),
        [CreatedAt] DATETIME2 NOT NULL DEFAULT(SYSDATETIME())
    );
END

-- Seed admin with password 'admin123' if not exists. Hash is SHA256 of password+salt.
DECLARE @salt NVARCHAR(256) = N''; -- empty salt placeholder

DECLARE @users TABLE(Username NVARCHAR(100), Pwd NVARCHAR(200), Role NVARCHAR(50));
INSERT INTO @users(Username, Pwd, Role)
VALUES (N'admin', N'admin123', N'Admin'),
       (N'pdt', N'pdt123', N'PhongDaoTao'),
       (N'viewer', N'viewer123', N'Viewer'),
       (N'sv', N'sv123', N'SinhVien');

DECLARE @u NVARCHAR(100), @p NVARCHAR(200), @r NVARCHAR(50);
DECLARE cur CURSOR FOR SELECT Username, Pwd, Role FROM @users;
OPEN cur;
FETCH NEXT FROM cur INTO @u, @p, @r;
WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[UserAccount] WHERE [Username] = @u)
    BEGIN
        DECLARE @hash VARBINARY(32) = HASHBYTES('SHA2_256', CONVERT(varbinary(max), @p + @salt));
        DECLARE @hashb64 NVARCHAR(512) = CAST(N'' as xml).value('xs:base64Binary(sql:variable("@hash"))', 'NVARCHAR(512)');
        INSERT INTO [dbo].[UserAccount]([Username], [PasswordHash], [PasswordSalt], [Role], [IsActive])
        VALUES (@u, @hashb64, @salt, @r, 1);
    END
    FETCH NEXT FROM cur INTO @u, @p, @r;
END
CLOSE cur;
DEALLOCATE cur;
