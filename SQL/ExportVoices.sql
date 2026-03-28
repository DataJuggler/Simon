-- Ensure we are using the correct database
-- USE [YourDatabaseName]; 
-- GO

SELECT 
    CAST(Id AS NVARCHAR(10)) + ',' + 
    [Name] + ',' + 
    [Locale] + ',' + 
    [FullName] + ',' + 
    [Country] + ',' + 
    CASE 
        WHEN Gender = 1 THEN 'Female'
        WHEN Gender = 2 THEN 'Male'
        ELSE 'Male' -- Default fallback as requested
    END + ',' + 
    CASE 
        WHEN IsDragon = 1 THEN 'true'
        ELSE 'false'
    END
FROM [dbo].[Voice]
ORDER BY Id;