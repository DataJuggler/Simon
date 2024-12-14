

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data
{

    #region class VoiceManager
    /// <summary>
    /// This class is used to manage a 'Voice' object.
    /// </summary>
    public class VoiceManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'VoiceManager' object.
        /// </summary>
        public VoiceManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteVoice()
            /// <summary>
            /// This method deletes a 'Voice' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteVoice(DeleteVoiceStoredProcedure deleteVoiceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteVoiceProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllVoices()
            /// <summary>
            /// This method fetches a  'List<Voice>' object.
            /// This method uses the 'Voices_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Voice>'</returns>
            /// </summary>
            public static List<Voice> FetchAllVoices(FetchAllVoicesStoredProcedure fetchAllVoicesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Voice> voiceCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allVoicesDataSet = DataHelper.LoadDataSet(fetchAllVoicesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allVoicesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allVoicesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            voiceCollection = VoiceReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return voiceCollection;
            }
            #endregion

            #region FindVoice()
            /// <summary>
            /// This method finds a  'Voice' object.
            /// This method uses the 'Voice_Find' procedure.
            /// </summary>
            /// <returns>A 'Voice' object.</returns>
            /// </summary>
            public static Voice FindVoice(FindVoiceStoredProcedure findVoiceProc, DataConnector databaseConnector)
            {
                // Initial Value
                Voice voice = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet voiceDataSet = DataHelper.LoadDataSet(findVoiceProc, databaseConnector);

                    // Verify DataSet Exists
                    if(voiceDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(voiceDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Voice
                            voice = VoiceReader.Load(row);
                        }
                    }
                }

                // return value
                return voice;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertVoice()
            /// <summary>
            /// This method inserts a 'Voice' object.
            /// This method uses the 'Voice_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertVoice(InsertVoiceStoredProcedure insertVoiceProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertVoiceProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateVoice()
            /// <summary>
            /// This method updates a 'Voice'.
            /// This method uses the 'Voice_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateVoice(UpdateVoiceStoredProcedure updateVoiceProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateVoiceProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
