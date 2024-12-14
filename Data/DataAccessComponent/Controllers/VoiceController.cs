

#region using statements

using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class VoiceController
    /// <summary>
    /// This class controls a(n) 'Voice' object.
    /// </summary>
    public class VoiceController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'VoiceController' object.
        /// </summary>
        public VoiceController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateVoiceParameter
            /// <summary>
            /// This method creates the parameter for a 'Voice' data operation.
            /// </summary>
            /// <param name='voice'>The 'Voice' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateVoiceParameter(Voice voice)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = voice;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Voice tempVoice)
            /// <summary>
            /// Deletes a 'Voice' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Voice_Delete'.
            /// </summary>
            /// <param name='voice'>The 'Voice' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Voice tempVoice)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteVoice";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempvoice exists before attemptintg to delete
                    if(tempVoice != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteVoiceMethod = this.AppController.DataBridge.DataOperations.VoiceMethods.DeleteVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(tempVoice);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteVoiceMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Voice tempVoice)
            /// <summary>
            /// This method fetches a collection of 'Voice' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Voice_FetchAll'.</summary>
            /// <param name='tempVoice'>A temporary Voice for passing values.</param>
            /// <returns>A collection of 'Voice' objects.</returns>
            public List<Voice> FetchAll(Voice tempVoice)
            {
                // Initial value
                List<Voice> voiceList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.VoiceMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateVoiceParameter(tempVoice);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Voice> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        voiceList = (List<Voice>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return voiceList;
            }
            #endregion

            #region Find(Voice tempVoice)
            /// <summary>
            /// Finds a 'Voice' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Voice_Find'</param>
            /// </summary>
            /// <param name='tempVoice'>A temporary Voice for passing values.</param>
            /// <returns>A 'Voice' object if found else a null 'Voice'.</returns>
            public Voice Find(Voice tempVoice)
            {
                // Initial values
                Voice voice = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempVoice != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.VoiceMethods.FindVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(tempVoice);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Voice != null))
                        {
                            // Get ReturnObject
                            voice = (Voice) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return voice;
            }
            #endregion

            #region Insert(Voice voice)
            /// <summary>
            /// Insert a 'Voice' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Voice_Insert'.</param>
            /// </summary>
            /// <param name='voice'>The 'Voice' object to insert.</param>
            /// <returns>The id (int) of the new  'Voice' object that was inserted.</returns>
            public int Insert(Voice voice)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Voiceexists
                    if(voice != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.VoiceMethods.InsertVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(voice);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Voice voice)
            /// <summary>
            /// Saves a 'Voice' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='voice'>The 'Voice' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Voice voice)
            {
                // Initial value
                bool saved = false;

                // If the voice exists.
                if(voice != null)
                {
                    // Is this a new Voice
                    if(voice.IsNew)
                    {
                        // Insert new Voice
                        int newIdentity = this.Insert(voice);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            voice.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Voice
                        saved = this.Update(voice);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Voice voice)
            /// <summary>
            /// This method Updates a 'Voice' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Voice_Update'.</param>
            /// </summary>
            /// <param name='voice'>The 'Voice' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Voice voice)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(voice != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.VoiceMethods.UpdateVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(voice);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
