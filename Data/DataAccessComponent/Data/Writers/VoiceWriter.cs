
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion

namespace DataAccessComponent.Data.Writers
{

    #region class VoiceWriter
    /// <summary>
    /// This class is used for converting a 'Voice' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class VoiceWriter : VoiceWriterBase
    {

        #region Static Methods

            #region CreateFindVoiceStoredProcedure(Voice voice)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindVoiceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Voice_Find'.
            /// </summary>
            /// <param name="voice">The 'Voice' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindVoiceStoredProcedure CreateFindVoiceStoredProcedure(Voice voice)
            {
                // Initial Value
                FindVoiceStoredProcedure findVoiceStoredProcedure = null;

                // verify voice exists
                if(voice != null)
                {
                    // Instanciate findVoiceStoredProcedure
                    findVoiceStoredProcedure = new FindVoiceStoredProcedure();

                    // if voice.FindByFullName is true
                    if (voice.FindByFullName)
                    {
                            // Change the procedure name
                            findVoiceStoredProcedure.ProcedureName = "Voice_FindByFullName";
                            
                            // Create the @FullName parameter
                            findVoiceStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@FullName", voice.FullName);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findVoiceStoredProcedure.Parameters = CreatePrimaryKeyParameter(voice);
                    }
                }

                // return value
                return findVoiceStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
