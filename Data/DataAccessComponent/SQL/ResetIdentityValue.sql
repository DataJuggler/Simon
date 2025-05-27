-- Step 1: Create a temporary copy of the data without the Id column
SELECT 
    [Name], [Locale], [FullName], [Country], [Gender]
INTO 
    #TempVoice
FROM 
    [dbo].[Voice]
ORDER BY 
    Id; -- maintain current order if important

-- Step 2: Clear the original table
DELETE FROM [dbo].[Voice];

-- Step 3: Reset identity seed to 0 (next insert will be 1)
DBCC CHECKIDENT ('[dbo].[Voice]', RESEED, 0);

-- Step 4: Reinsert data (Id will auto-increment)
INSERT INTO [dbo].[Voice] ([Name], [Locale], [FullName], [Country], [Gender])
SELECT [Name], [Locale], [FullName], [Country], [Gender]
FROM #TempVoice;

-- Step 5: Cleanup
DROP TABLE #TempVoice;
