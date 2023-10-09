

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindVoiceStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Voice' object.
    /// </summary>
    public class FindVoiceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindVoiceStoredProcedure' object.
        /// </summary>
        public FindVoiceStoredProcedure()
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
                this.ProcedureName = "Voice_Find";

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
