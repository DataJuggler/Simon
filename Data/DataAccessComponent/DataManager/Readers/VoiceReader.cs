

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class VoiceReader
    /// <summary>
    /// This class loads a single 'Voice' object or a list of type <Voice>.
    /// </summary>
    public class VoiceReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Voice' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Voice' DataObject.</returns>
            public static Voice Load(DataRow dataRow)
            {
                // Initial Value
                Voice voice = new Voice();

                // Create field Integers
                int countryfield = 0;
                int fullNamefield = 1;
                int genderfield = 2;
                int idfield = 3;
                int localefield = 4;
                int namefield = 5;

                try
                {
                    // Load Each field
                    voice.Country = DataHelper.ParseString(dataRow.ItemArray[countryfield]);
                    voice.FullName = DataHelper.ParseString(dataRow.ItemArray[fullNamefield]);
                    voice.Gender = (GenderEnum) DataHelper.ParseInteger(dataRow.ItemArray[genderfield], 0);
                    voice.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    voice.Locale = DataHelper.ParseString(dataRow.ItemArray[localefield]);
                    voice.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                }
                catch
                {
                }

                // return value
                return voice;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Voice' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Voice Collection.</returns>
            public static List<Voice> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Voice> voices = new List<Voice>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Voice' from rows
                        Voice voice = Load(row);

                        // Add this object to collection
                        voices.Add(voice);
                    }
                }
                catch
                {
                }

                // return value
                return voices;
            }
            #endregion

        #endregion

    }
    #endregion

}
