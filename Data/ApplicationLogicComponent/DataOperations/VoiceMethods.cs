

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class VoiceMethods
    /// <summary>
    /// This class contains methods for modifying a 'Voice' object.
    /// </summary>
    public class VoiceMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'VoiceMethods' object.
        /// </summary>
        public VoiceMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteVoice(Voice)
            /// <summary>
            /// This method deletes a 'Voice' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Voice' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteVoice(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteVoiceStoredProcedure deleteVoiceProc = null;

                    // verify the first parameters is a(n) 'Voice'.
                    if (parameters[0].ObjectValue as Voice != null)
                    {
                        // Create Voice
                        Voice voice = (Voice) parameters[0].ObjectValue;

                        // verify voice exists
                        if(voice != null)
                        {
                            // Now create deleteVoiceProc from VoiceWriter
                            // The DataWriter converts the 'Voice'
                            // to the SqlParameter[] array needed to delete a 'Voice'.
                            deleteVoiceProc = VoiceWriter.CreateDeleteVoiceStoredProcedure(voice);
                        }
                    }

                    // Verify deleteVoiceProc exists
                    if(deleteVoiceProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.VoiceManager.DeleteVoice(deleteVoiceProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Voice' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Voice' to delete.
            /// <returns>A PolymorphicObject object with all  'Voices' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Voice> voiceListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllVoicesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get VoiceParameter
                    // Declare Parameter
                    Voice paramVoice = null;

                    // verify the first parameters is a(n) 'Voice'.
                    if (parameters[0].ObjectValue as Voice != null)
                    {
                        // Get VoiceParameter
                        paramVoice = (Voice) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllVoicesProc from VoiceWriter
                    fetchAllProc = VoiceWriter.CreateFetchAllVoicesStoredProcedure(paramVoice);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    voiceListCollection = this.DataManager.VoiceManager.FetchAllVoices(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(voiceListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = voiceListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindVoice(Voice)
            /// <summary>
            /// This method finds a 'Voice' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Voice' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindVoice(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Voice voice = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindVoiceStoredProcedure findVoiceProc = null;

                    // verify the first parameters is a 'Voice'.
                    if (parameters[0].ObjectValue as Voice != null)
                    {
                        // Get VoiceParameter
                        Voice paramVoice = (Voice) parameters[0].ObjectValue;

                        // verify paramVoice exists
                        if(paramVoice != null)
                        {
                            // Now create findVoiceProc from VoiceWriter
                            // The DataWriter converts the 'Voice'
                            // to the SqlParameter[] array needed to find a 'Voice'.
                            findVoiceProc = VoiceWriter.CreateFindVoiceStoredProcedure(paramVoice);
                        }

                        // Verify findVoiceProc exists
                        if(findVoiceProc != null)
                        {
                            // Execute Find Stored Procedure
                            voice = this.DataManager.VoiceManager.FindVoice(findVoiceProc, dataConnector);

                            // if dataObject exists
                            if(voice != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = voice;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertVoice (Voice)
            /// <summary>
            /// This method inserts a 'Voice' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Voice' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertVoice(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Voice voice = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertVoiceStoredProcedure insertVoiceProc = null;

                    // verify the first parameters is a(n) 'Voice'.
                    if (parameters[0].ObjectValue as Voice != null)
                    {
                        // Create Voice Parameter
                        voice = (Voice) parameters[0].ObjectValue;

                        // verify voice exists
                        if(voice != null)
                        {
                            // Now create insertVoiceProc from VoiceWriter
                            // The DataWriter converts the 'Voice'
                            // to the SqlParameter[] array needed to insert a 'Voice'.
                            insertVoiceProc = VoiceWriter.CreateInsertVoiceStoredProcedure(voice);
                        }

                        // Verify insertVoiceProc exists
                        if(insertVoiceProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.VoiceManager.InsertVoice(insertVoiceProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateVoice (Voice)
            /// <summary>
            /// This method updates a 'Voice' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Voice' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateVoice(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Voice voice = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateVoiceStoredProcedure updateVoiceProc = null;

                    // verify the first parameters is a(n) 'Voice'.
                    if (parameters[0].ObjectValue as Voice != null)
                    {
                        // Create Voice Parameter
                        voice = (Voice) parameters[0].ObjectValue;

                        // verify voice exists
                        if(voice != null)
                        {
                            // Now create updateVoiceProc from VoiceWriter
                            // The DataWriter converts the 'Voice'
                            // to the SqlParameter[] array needed to update a 'Voice'.
                            updateVoiceProc = VoiceWriter.CreateUpdateVoiceStoredProcedure(voice);
                        }

                        // Verify updateVoiceProc exists
                        if(updateVoiceProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.VoiceManager.UpdateVoice(updateVoiceProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
