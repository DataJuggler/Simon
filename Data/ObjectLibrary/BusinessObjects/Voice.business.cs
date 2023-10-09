

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Voice
    [Serializable]
    public partial class Voice
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Voice()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Voice Clone()
            {
                // Create New Object
                Voice newVoice = (Voice) this.MemberwiseClone();

                // Return Cloned Object
                return newVoice;
            }
            #endregion

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                return FullName;
            }
            #endregion
            
        #endregion

        #region Properties

        #region Info
        /// <summary>
        /// This read only property the name + the country
        /// </summary>
        public string Info
            {
                get
                {
                    // return the Name
                    return Name + " - " + Country;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}