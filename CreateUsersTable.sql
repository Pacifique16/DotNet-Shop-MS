-- SQL Script to Create Users Table for Shop Management System

USE ShopDB;
GO

-- Create Users table
CREATE TABLE Users (
    userID INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(50) NOT NULL,
    role NVARCHAR(50) NOT NULL
);
GO

-- Insert default admin user
INSERT INTO Users (username, password, role) VALUES ('admin', 'admin', 'Admin');
GO

-- Verify table creation
SELECT * FROM Users;
GO
