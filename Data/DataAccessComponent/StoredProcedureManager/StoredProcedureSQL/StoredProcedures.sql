Use [Simon]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Voice_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   10/7/2023
-- Description:    Insert a new Voice
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Voice_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Voice_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Voice_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Voice_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Voice_Insert >>>'

    End

GO

Create PROCEDURE Voice_Insert

    -- Add the parameters for the stored procedure here
    @Country nvarchar(50),
    @FullName nvarchar(128),
    @Locale nvarchar(20),
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Voice]
    ([Country],[FullName],[Locale],[Name])

    -- Begin Values List
    Values(@Country, @FullName, @Locale, @Name)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Voice_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   10/7/2023
-- Description:    Update an existing Voice
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Voice_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Voice_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Voice_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Voice_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Voice_Update >>>'

    End

GO

Create PROCEDURE Voice_Update

    -- Add the parameters for the stored procedure here
    @Country nvarchar(50),
    @FullName nvarchar(128),
    @Id int,
    @Locale nvarchar(20),
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Voice]

    -- Update Each field
    Set [Country] = @Country,
    [FullName] = @FullName,
    [Locale] = @Locale,
    [Name] = @Name

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Voice_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   10/7/2023
-- Description:    Find an existing Voice
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Voice_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Voice_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Voice_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Voice_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Voice_Find >>>'

    End

GO

Create PROCEDURE Voice_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Country],[FullName],[Id],[Locale],[Name]

    -- From tableName
    From [Voice]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Voice_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   10/7/2023
-- Description:    Delete an existing Voice
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Voice_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Voice_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Voice_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Voice_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Voice_Delete >>>'

    End

GO

Create PROCEDURE Voice_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Voice]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Voice_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   10/7/2023
-- Description:    Returns all Voice objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Voice_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Voice_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Voice_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Voice_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Voice_FetchAll >>>'

    End

GO

Create PROCEDURE Voice_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Country],[FullName],[Id],[Locale],[Name]

    -- From tableName
    From [Voice]

END

-- Thank you for using DataTier.Net.

