

#region using statements

using System.Configuration;
using DataJuggler.UltimateHelper;

#endregion

namespace Simon.Security
{

    #region class SecureUserData
    /// <summary>
    /// This class is used to store values such as PlayerName and Password, and settings such as
    /// preferred club & room. Game settings and options as well as timer preferences may be stored here.
    /// </summary>
    public class SecureUserData : ApplicationSettingsBase
    {  

        #region Properties

            #region AppendVoiceName
            /// <summary>
            /// This property gets or sets the value for IgnoreDataSync
            /// </summary>
            [UserScopedSetting()]
            [DefaultSettingValue("True")]
            public bool AppendVoiceName
            {
                get
                {
                    // return the value for IgnoreDataSync
                    return (bool) this["AppendVoiceName"];
                }
                set
                {
                    // set the value
                    this["AppendVoiceName"] = value;
                }   
            }
            #endregion

            #region CountryFilter
            /// <summary>
            /// This property gets or sets the value for CountryFilter
            /// </summary>
            [UserScopedSetting()]
            public string CountryFilter
            {
                get
                {
                    // initial value
                    string countryFilter = "";

                    // if the CountryFilter exists
                    if (this["CountryFilter"] != null)
                    {
                        // set the return value
                        countryFilter = this["CountryFilter"].ToString();
                    }

                    // return the value for countryFilter
                    return countryFilter;
                }
                set
                {
                    // set the value for CountryFilter
                    this["CountryFilter"] = value;
                }   
            }
            #endregion

            #region GenderFilder
            /// <summary>
            /// This property gets or sets the value for GenderFilter
            /// </summary>
            [UserScopedSetting()]
            public string GenderFilter
            {
                get
                {
                    // initial value
                    string genderFilter = "";

                    // if the GenderFilter exists
                    if (this["GenderFilter"] != null)
                    {
                        // set the return value
                        genderFilter = this["GenderFilter"].ToString();
                    }

                    // return the value for genderFilter
                    return genderFilter;
                }
                set
                {
                    // set the value for GenderFilter
                    this["GenderFilter"] = value;
                }   
            }
            #endregion

            #region Voice
            /// <summary>
            /// This property gets or sets the value for Voice
            /// </summary>
            [UserScopedSetting()]
            public string Voice
            {
                get
                {
                    // initial value
                    string voice = "";

                    // if the CompareCount exists
                    if (this["Voice"] != null)
                    {
                        // set the return value
                        voice = this["Voice"].ToString();
                    }

                    // return the value for outputFolder
                    return voice;
                }
                set
                {
                    // set the value for Voice
                    this["Voice"] = value;
                }   
            }
            #endregion

            #region OutputFolder
            /// <summary>
            /// This property gets or sets the value for OutputFolder
            /// </summary>
            [UserScopedSetting()]
            public string OutputFolder
            {
                get
                {
                    // initial value
                    string outputFolder = "";

                    // if the CompareCount exists
                    if (this["OutputFolder"] != null)
                    {
                        // set the return value
                        outputFolder = this["OutputFolder"].ToString();
                    }

                    // return the value for outputFolder
                    return outputFolder;
                }
                set
                {
                    // set the value for CompareCount
                    this["OutputFolder"] = value;
                }   
            }
            #endregion

        #endregion
        
    }
    #endregion

}
