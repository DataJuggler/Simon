

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.Excelerate.Interfaces;
using DataJuggler.NET9;
using DataJuggler.UltimateHelper;

#endregion

namespace Simon.Objects
{

    #region class Voice : IExcelerateObject
    public class Voice : IExcelerateObject
    {

        #region Private Variables
        private string changedColumns;
        private string country;
        private string fullName;
        private int gender;
        private int id;
        private bool loading;
        private string locale;
        private string name;
        private Guid rowId;
        #endregion

        #region Methods

            #region Load(Row row)
            /// <summary>
            /// This method loads a Voice object from a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be used to load this object.</param>
            public void Load(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    // Turn Loading On
                    Loading = true;

                    // set values
                    Id = row.Columns[0].IntValue;
                    Name = row.Columns[1].StringValue;
                    Locale = row.Columns[2].StringValue;
                    FullName = row.Columns[3].StringValue;
                    Country = row.Columns[4].StringValue;
                    Gender = row.Columns[5].IntValue;

                    // Turn Loading Off
                    Loading = false;
                }

                // Set RowId
                RowId = row.Id;
            }
            #endregion

            #region Load(Worksheet worksheet)
            /// <summary>
            /// This method loads a list of Voice objects from a Worksheet.
            /// </Summary>
            /// <param name="worksheet">The worksheet which the rows collection will be used to load a list of Voice objects.</param>
            public static List<Voice> Load(Worksheet worksheet)
            {
                // Initial value
                List<Voice> voiceList = new List<Voice>();
                
                // If the worksheet exists and the row's collection exists
                if ((NullHelper.Exists(worksheet)) && (worksheet.HasRows))
                {
                    // Iterate the worksheet.Rows collection
                    foreach (Row row in worksheet.Rows)
                    {
                        // If the row is not a HeaderRow and row's column collection exists
                        if ((!row.IsHeaderRow) && (row.HasColumns))
                        {
                            // Create a new instance of a Voice object.
                            Voice voice = new Voice();
                            
                            // Load this object
                            voice.Load(row);
                            
                            // Add this object to the list
                            voiceList.Add(voice);
                        }
                    }
                }
                
                // return value
                return voiceList;
            }
            #endregion

            #region MapToDataObject
            /// <summary>
            /// This method maps this Simon.Objects.Voice instance to a ObjectLibrary.BusinessObjects.Voice instance.
            /// </summary>
            /// <returns>A new instance of ObjectLibrary.BusinessObjects.Voice with mapped values.</returns>
            public ObjectLibrary.BusinessObjects.Voice MapToDataObject()
            {
                // Create a new instance of the business object
                ObjectLibrary.BusinessObjects.Voice dataObject = new ObjectLibrary.BusinessObjects.Voice();

                // map each property
                dataObject.Name = this.Name.Replace(" Multilingual", "");
                dataObject.Locale = this.Locale;
                dataObject.FullName = this.FullName;
                dataObject.Country = this.Country;
                dataObject.Gender = (ObjectLibrary.Enumerations.GenderEnum) this.Gender;

                // return value
                return dataObject;
            }
            #endregion

            #region NewRow(Row row)
            /// <summary>
            /// This method creates the columns for the row to save a new Voice object.
            /// </Summary>
            /// <param name="row">The row which the Columns will be created for.</param>
            public static Row NewRow(int rowNumber)
            {
                // initial value
                Row newRow = new Row();

                // Create Column
                Column idColumn = new Column("Id", rowNumber, 1, DataManager.DataTypeEnum.Integer);

                // Add this column
                newRow.Columns.Add(idColumn);

                // Create Column
                Column nameColumn = new Column("Name", rowNumber, 2, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(nameColumn);

                // Create Column
                Column localeColumn = new Column("Locale", rowNumber, 3, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(localeColumn);

                // Create Column
                Column fullNameColumn = new Column("FullName", rowNumber, 4, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(fullNameColumn);

                // Create Column
                Column countryColumn = new Column("Country", rowNumber, 5, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(countryColumn);

                // Create Column
                Column genderColumn = new Column("Gender", rowNumber, 6, DataManager.DataTypeEnum.Integer);

                // Add this column
                newRow.Columns.Add(genderColumn);

                // return value
                return newRow;
            }
            #endregion

            #region Save(Row row)
            /// <summary>
            /// This method saves a Voice object back to a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be set to Save back to Excel.</param>
            public Row Save(Row row)
            {
                // If the row exists and the row's column collection exists and the ChangedColumns string is not null or empty
                if ((NullHelper.Exists(row)) && (row.HasColumns) && (TextHelper.Exists(ChangedColumns)))
                {
                    // Parse the changed column indexes
                    List<int> changedColumnIndexes = ExcelHelper.ParseChangedColumnIndexes(ChangedColumns);

                    row.Columns[0].ColumnValue = Id;
                    row.Columns[0].HasChanges = changedColumnIndexes.Contains(0);
                    row.Columns[1].ColumnValue = Name;
                    row.Columns[1].HasChanges = changedColumnIndexes.Contains(1);
                    row.Columns[2].ColumnValue = Locale;
                    row.Columns[2].HasChanges = changedColumnIndexes.Contains(2);
                    row.Columns[3].ColumnValue = FullName;
                    row.Columns[3].HasChanges = changedColumnIndexes.Contains(3);
                    row.Columns[4].ColumnValue = Country;
                    row.Columns[4].HasChanges = changedColumnIndexes.Contains(4);
                    row.Columns[5].ColumnValue = Gender;
                    row.Columns[5].HasChanges = changedColumnIndexes.Contains(5);
                }

                // return value
                return row;
            }
        #endregion

            public override string ToString()
            {
                return Name + " - " + Country + ' ' + Gender;
            }

        #endregion

        #region Properties

            #region string ChangedColumns
            public string ChangedColumns
            {
                get
                {
                    return changedColumns;
                }
                set
                {
                    changedColumns = value;
                }
            }
            #endregion

            #region string Country
            public string Country
            {
                get
                {
                    return country;
                }
                set
                {
                    country = value;

                    if (!Loading)
                    {
                        ChangedColumns += 4 + ",";
                    }
                }
            }
            #endregion

            #region string FullName
            public string FullName
            {
                get
                {
                    return fullName;
                }
                set
                {
                    fullName = value;

                    if (!Loading)
                    {
                        ChangedColumns += 3 + ",";
                    }
                }
            }
            #endregion

            #region int Gender
            public int Gender
            {
                get
                {
                    return gender;
                }
                set
                {
                    gender = value;

                    if (!Loading)
                    {
                        ChangedColumns += 5 + ",";
                    }
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;

                    if (!Loading)
                    {
                        ChangedColumns += 0 + ",";
                    }
                }
            }
            #endregion

            #region bool Loading
            public bool Loading
            {
                get
                {
                    return loading;
                }
                set
                {
                    loading = value;
                }
            }
            #endregion

            #region string Locale
            public string Locale
            {
                get
                {
                    return locale;
                }
                set
                {
                    locale = value;

                    if (!Loading)
                    {
                        ChangedColumns += 2 + ",";
                    }
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;

                    if (!Loading)
                    {
                        ChangedColumns += 1 + ",";
                    }
                }
            }
            #endregion

            #region Guid RowId
            public Guid RowId
            {
                get
                {
                    return rowId;
                }
                set
                {
                    rowId = value;

                    if (!Loading)
                    {
                        ChangedColumns += 6 + ",";
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}