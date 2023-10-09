

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteVoiceStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Voice' object.
    /// </summary>
    public class DeleteVoiceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteVoiceStoredProcedure' object.
        /// </summary>
        public DeleteVoiceStoredProcedure()
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
                this.ProcedureName = "Voice_Delete";

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
