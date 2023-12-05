
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
        private bool findByName;
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
                // Display the Name and Country
                return Name + " - " + Country;
            }
            #endregion
            
        #endregion

        #region Properties

        #region FindByName
        /// <summary>
        /// This property gets or sets the value for 'FindByName'.
        /// </summary>
        public bool FindByName
        {
            get { return findByName; }
            set { findByName = value; }
        }
        #endregion

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