

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateVoiceStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Voice' object.
    /// </summary>
    public class UpdateVoiceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateVoiceStoredProcedure' object.
        /// </summary>
        public UpdateVoiceStoredProcedure()
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
                this.ProcedureName = "Voice_Update";

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
