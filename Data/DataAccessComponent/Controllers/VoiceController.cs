

#region using statements

using DataAccessComponent.Logging;
using DataAccessComponent.DataOperations;
using DataAccessComponent.DataBridge;
using DataAccessComponent.Data;
using System;
using System.Collections.Generic;
using ObjectLibrary.BusinessObjects;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class VoiceController
    /// <summary>
    /// This class controls a(n) 'Voice' object.
    /// </summary>
    public class VoiceController
    {

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

            #region Delete(Voice tempVoice, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Voice' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Voice_Delete'.
            /// </summary>
            /// <param name='voice'>The 'Voice' to delete.</param>
            /// <returns>The result of the Delete</returns>
            public static PolymorphicObject Delete(Voice tempVoice, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteVoice";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempvoice exists before attemptintg to delete
                    if (tempVoice != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteVoiceMethod = VoiceMethods.DeleteVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(tempVoice);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteVoiceMethod, parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Store the Error
                    result.Exception = error;

                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll(Voice tempVoice, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Voice' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Voice_FetchAll'.</summary>
            /// <param name='tempVoice'>A temporary Voice for passing values.</param>
            /// <returns>A collection of 'Voice' objects.</returns>
            public static List<Voice> FetchAll(Voice tempVoice, DataManager dataManager)
            {
                // Initial value
                List<Voice> voiceList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = VoiceMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateVoiceParameter(tempVoice);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Voice> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        voiceList = (List<Voice>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return voiceList;
            }
            #endregion

            #region Find(Voice tempVoice, DataManager dataManager)
            /// <summary>
            /// Finds a 'Voice' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Voice_Find'</param>
            /// </summary>
            /// <param name='tempVoice'>A temporary Voice for passing values.</param>
            /// <returns>A 'Voice' object if found else a null 'Voice'.</returns>
            public static Voice Find(Voice tempVoice, DataManager dataManager)
            {
                // Initial values
                Voice voice = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempVoice != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = VoiceMethods.FindVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(tempVoice);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return voice;
            }
            #endregion

            #region Insert(Voice voice, DataManager dataManager)
            /// <summary>
            /// Insert a 'Voice' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Voice_Insert'.</param>
            /// </summary>
            /// <param name='voice'>The 'Voice' object to insert.</param>
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'Voice' object that was inserted.</returns>
            public static PolymorphicObject Insert(Voice voice, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If Voiceexists
                    if (voice != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = VoiceMethods.InsertVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(voice);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Store the Error
                    result.Exception = error;

                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region Save(ref Voice voice, DataManager dataManager)
            /// <summary>
            /// Saves a 'Voice' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='voice'>The 'Voice' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref Voice voice, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the voice exists.
                if (voice != null)
                {
                    // Is this a new Voice
                    if (voice.IsNew)
                    {
                        // Insert new Voice
                        result = Insert(voice, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            voice.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update Voice
                        result  = Update(voice, dataManager);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region Update(Voice voice, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Voice' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Voice_Update'.</param>
            /// </summary>
            /// <param name='voice'>The 'Voice' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static PolymorphicObject Update(Voice voice, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (voice != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = VoiceMethods.UpdateVoice;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateVoiceParameter(voice);
                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Store the Error
                    result.Exception = error;

                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
