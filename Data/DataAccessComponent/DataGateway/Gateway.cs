
#region using statements

using DataAccessComponent.Controllers;
using DataAccessComponent.Data;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

#endregion

namespace DataAccessComponent.DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method, create a custom method
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;        
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName)
        {
            // store the ConnectionName
            ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteVoice(int id, Voice tempVoice = null)
            /// <summary>
            /// This method is used to delete Voice objects.
            /// </summary>
            /// <param name="id">Delete the Voice with this id</param>
            /// <param name="tempVoice">Pass in a tempVoice to perform a custom delete.</param>
            public bool DeleteVoice(int id, Voice tempVoice = null)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempVoice does not exist
                    if (tempVoice == null)
                    {
                        // create a temp Voice
                        tempVoice = new Voice();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempVoice.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    result = VoiceController.Delete(tempVoice, DataManager);
                }
        
                // return value
                return result.Success;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.Data.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindVoice(int id, Voice tempVoice = null)
            /// <summary>
            /// This method is used to find 'Voice' objects.
            /// </summary>
            /// <param name="id">Find the Voice with this id</param>
            /// <param name="tempVoice">Pass in a tempVoice to perform a custom find.</param>
            public Voice FindVoice(int id, Voice tempVoice = null)
            {
                // initial value
                Voice voice = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempVoice does not exist
                    if (tempVoice == null)
                    {
                        // create a temp Voice
                        tempVoice = new Voice();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempVoice.UpdateIdentity(id);
                    }

                    // perform the find
                    voice = VoiceController.Find(tempVoice, DataManager);
                }

                // return value
                return voice;
            }
            #endregion

            #region FindVoiceByFullName(string fullName)
            /// <summary>
            /// This method is used to find 'Voice' objects for the FullName given.
            /// </summary>
            public Voice FindVoiceByFullName(string fullName)
            {
                // initial value
                Voice voice = null;
                
                // Create a temp Voice object
                Voice tempVoice = new Voice();
                
                // Set the value for FindByFullName to true
                tempVoice.FindByFullName = true;
                
                // Using FullName As fullName
                tempVoice.FullName = fullName;
                
                // Perform the find
                voice = FindVoice(0, tempVoice);
                
                // return value
                return voice;
            }
            #endregion
            
            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// returns the Last Exception
            /// </summary>
            public Exception GetLastException()
            {
                // initial value
                Exception lastException = null;

                // if the value for HasDataManager is true and DataManager.HasExceptions is true
                if ((HasDataManager) && (DataManager.HasExceptions))
                {
                    // set the return value
                    lastException = DataManager.Exceptions.LastOrDefault();
                }

                // return value
                return lastException;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadVoices(Voice tempVoice = null)
            /// <summary>
            /// This method loads a collection of 'Voice' objects.
            /// </summary>
            public List<Voice> LoadVoices(Voice tempVoice = null)
            {
                // initial value
                List<Voice> voices = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    voices = VoiceController.FetchAll(tempVoice, DataManager);
                }

                // return value
                return voices;
            }
            #endregion

            #region SaveVoice(ref Voice voice)
            /// <summary>
            /// This method is used to save 'Voice' objects.
            /// </summary>
            /// <param name="voice">The Voice to save.</param>
            public bool SaveVoice(ref Voice voice)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    result = VoiceController.Save(ref voice, DataManager);
                }

                // return value
                return result.Success;
            }
            #endregion

            #region TestDatabaseConnection(ref Exception error)
            /// <summary>
            /// returns the Database Connection
            /// </summary>
            public bool TestDatabaseConnection(ref Exception error)
            {
                // initial value
                bool connected = false;

                // If the this object does not have a HasAppController property
                if (!this.HasAppController)
                {
                    // Create the Controller
                    this.AppController = new ApplicationController(this.ConnectionName);
                }

                // If the AppController object exists
                if ((this.HasAppController) && (!this.AppController.HasConnectionName))
                {
                    // Set the ConnectionName
                    this.AppController.ConnectionName = this.ConnectionName;
                }

                // perform the test
                connected = this.AppController.TestDatabaseConnection(ref error, this.DataManager);

                // return value
                return connected;
            }
            #endregion
            
        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region DataManager
            /// <summary>
            /// This read only property returns the value of DataManager from the object AppController.
            /// </summary>
            public DataManager DataManager
            {

                get
                {
                    // initial value
                    DataManager dataManager = null;

                    // if AppController exists
                    if (HasAppController)
                    {
                        // set the return value
                        dataManager = AppController.DataManager;
                    }

                    // return value
                    return dataManager;
                }
            }
            #endregion

            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
            #region HasDataManager
            /// <summary>
            /// This property returns true if this object has a 'DataManager'.
            /// </summary>
            public bool HasDataManager
            {
                get
                {
                    // initial value
                    bool hasDataManager = (DataManager != null);

                    // return value
                    return hasDataManager;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

