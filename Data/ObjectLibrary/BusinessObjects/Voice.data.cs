

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Voice
    public partial class Voice
    {

        #region Private Variables
        private string country;
        private string fullName;
        private int id;
        private string locale;
        private string name;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string Country
            public string Country
            {
                get
                {
                    return country;
                }
                set
                {
                    country = value;
                }
            }
            #endregion

            #region string FullName
            public string FullName
            {
                get
                {
                    return fullName;
                }
                set
                {
                    fullName = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region string Locale
            public string Locale
            {
                get
                {
                    return locale;
                }
                set
                {
                    locale = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
