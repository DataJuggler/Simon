

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertVoiceStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Voice' object.
    /// </summary>
    public class InsertVoiceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertVoiceStoredProcedure' object.
        /// </summary>
        public InsertVoiceStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "Voice_Insert";

                // Set tableName
                this.TableName = "Voice";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
