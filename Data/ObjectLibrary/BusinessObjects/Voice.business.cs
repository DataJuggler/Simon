
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
        private bool findByFullName;
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

        #region FindByFullName
        /// <summary>
        /// This property gets or sets the value for 'FindByFullName'.
        /// </summary>
        public bool FindByFullName
            {
                get { return findByFullName; }
                set { findByFullName = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
