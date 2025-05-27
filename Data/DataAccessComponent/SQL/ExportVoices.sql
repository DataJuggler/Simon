SELECT 
    CAST(Id AS varchar) + ',' +
    Name + ',' +
    Locale + ',' +
    FullName + ',' +
    Country + ',' +
    CASE Gender
        WHEN 1 THEN 'Female'
        WHEN 2 THEN 'Male'
        ELSE 'Both'
    END AS VoiceTextLine
FROM 
    [dbo].[Voice]
ORDER BY 
    Id;
