

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllVoicesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Voice' objects.
    /// </summary>
    public class FetchAllVoicesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllVoicesStoredProcedure' object.
        /// </summary>
        public FetchAllVoicesStoredProcedure()
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
                this.ProcedureName = "Voice_FetchAll";

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
