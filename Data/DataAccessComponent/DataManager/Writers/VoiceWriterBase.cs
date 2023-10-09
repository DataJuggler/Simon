

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


namespace DataAccessComponent.DataManager.Writers
{

    #region class VoiceWriterBase
    /// <summary>
    /// This class is used for converting a 'Voice' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class VoiceWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Voice voice)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='voice'>The 'Voice' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Voice voice)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (voice != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", voice.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteVoiceStoredProcedure(Voice voice)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteVoice'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Voice_Delete'.
            /// </summary>
            /// <param name="voice">The 'Voice' to Delete.</param>
            /// <returns>An instance of a 'DeleteVoiceStoredProcedure' object.</returns>
            public static DeleteVoiceStoredProcedure CreateDeleteVoiceStoredProcedure(Voice voice)
            {
                // Initial Value
                DeleteVoiceStoredProcedure deleteVoiceStoredProcedure = new DeleteVoiceStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteVoiceStoredProcedure.Parameters = CreatePrimaryKeyParameter(voice);

                // return value
                return deleteVoiceStoredProcedure;
            }
            #endregion

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
            public static FindVoiceStoredProcedure CreateFindVoiceStoredProcedure(Voice voice)
            {
                // Initial Value
                FindVoiceStoredProcedure findVoiceStoredProcedure = null;

                // verify voice exists
                if(voice != null)
                {
                    // Instanciate findVoiceStoredProcedure
                    findVoiceStoredProcedure = new FindVoiceStoredProcedure();

                    // Now create parameters for this procedure
                    findVoiceStoredProcedure.Parameters = CreatePrimaryKeyParameter(voice);
                }

                // return value
                return findVoiceStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Voice voice)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new voice.
            /// </summary>
            /// <param name="voice">The 'Voice' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Voice voice)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify voiceexists
                if(voice != null)
                {
                    // Create [Country] parameter
                    param = new SqlParameter("@Country", voice.Country);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [FullName] parameter
                    param = new SqlParameter("@FullName", voice.FullName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Locale] parameter
                    param = new SqlParameter("@Locale", voice.Locale);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", voice.Name);

                    // set parameters[3]
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertVoiceStoredProcedure(Voice voice)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertVoiceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Voice_Insert'.
            /// </summary>
            /// <param name="voice"The 'Voice' object to insert</param>
            /// <returns>An instance of a 'InsertVoiceStoredProcedure' object.</returns>
            public static InsertVoiceStoredProcedure CreateInsertVoiceStoredProcedure(Voice voice)
            {
                // Initial Value
                InsertVoiceStoredProcedure insertVoiceStoredProcedure = null;

                // verify voice exists
                if(voice != null)
                {
                    // Instanciate insertVoiceStoredProcedure
                    insertVoiceStoredProcedure = new InsertVoiceStoredProcedure();

                    // Now create parameters for this procedure
                    insertVoiceStoredProcedure.Parameters = CreateInsertParameters(voice);
                }

                // return value
                return insertVoiceStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Voice voice)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing voice.
            /// </summary>
            /// <param name="voice">The 'Voice' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Voice voice)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify voiceexists
                if(voice != null)
                {
                    // Create parameter for [Country]
                    param = new SqlParameter("@Country", voice.Country);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [FullName]
                    param = new SqlParameter("@FullName", voice.FullName);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Locale]
                    param = new SqlParameter("@Locale", voice.Locale);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", voice.Name);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", voice.Id);
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateVoiceStoredProcedure(Voice voice)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateVoiceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Voice_Update'.
            /// </summary>
            /// <param name="voice"The 'Voice' object to update</param>
            /// <returns>An instance of a 'UpdateVoiceStoredProcedure</returns>
            public static UpdateVoiceStoredProcedure CreateUpdateVoiceStoredProcedure(Voice voice)
            {
                // Initial Value
                UpdateVoiceStoredProcedure updateVoiceStoredProcedure = null;

                // verify voice exists
                if(voice != null)
                {
                    // Instanciate updateVoiceStoredProcedure
                    updateVoiceStoredProcedure = new UpdateVoiceStoredProcedure();

                    // Now create parameters for this procedure
                    updateVoiceStoredProcedure.Parameters = CreateUpdateParameters(voice);
                }

                // return value
                return updateVoiceStoredProcedure;
            }
            #endregion

            #region CreateFetchAllVoicesStoredProcedure(Voice voice)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllVoicesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Voice_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllVoicesStoredProcedure' object.</returns>
            public static FetchAllVoicesStoredProcedure CreateFetchAllVoicesStoredProcedure(Voice voice)
            {
                // Initial value
                FetchAllVoicesStoredProcedure fetchAllVoicesStoredProcedure = new FetchAllVoicesStoredProcedure();

                // return value
                return fetchAllVoicesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
