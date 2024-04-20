IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'PandaShopDB')
BEGIN
    RETURN;
END;

USE [PandaShopDB]
IF (OBJECT_ID('ROLE', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM Role))
BEGIN
    INSERT INTO Role(id, name, isDeleted) VALUES(1, 'user', 0);
    INSERT INTO Role(id, name, isDeleted) VALUES(2, 'shop', 0);
    INSERT INTO Role(id, name, isDeleted) VALUES(3, 'admin', 0);
END

