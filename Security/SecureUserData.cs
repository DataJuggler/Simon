

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

            #region Degree
            /// <summary>
            /// This property gets or sets the value for Degree
            /// </summary>
            [UserScopedSetting()]
            public string Degree
            {
                get
                {
                    // initial value
                    string degree = "";

                    // if the Emotion exists
                    if (this["Degree"] != null)
                    {
                        // set the return value
                        degree = this["Degree"].ToString();
                    }

                    // return the value for Degree
                    return degree;
                }
                set
                {
                    // set the value for Degree
                    this["Degree"] = value;
                }   
            }
            #endregion

            #region Emotion
            /// <summary>
            /// This property gets or sets the value for Emotion
            /// </summary>
            [UserScopedSetting()]
            public string Emotion
            {
                get
                {
                    // initial value
                    string emotion = "";

                    // if the Emotion exists
                    if (this["Emotion"] != null)
                    {
                        // set the return value
                        emotion = this["Emotion"].ToString();
                    }

                    // return the value for Emotion
                    return emotion;
                }
                set
                {
                    // set the value for Emotion
                    this["Emotion"] = value;
                }   
            }
            #endregion

            #region GenderFilter
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

            #region Pitch
            /// <summary>
            /// This property gets or sets the value for Pitch
            /// </summary>
            [UserScopedSetting()]
            public string Pitch
            {
                get
                {
                    // initial value
                    string pitch = "default";

                    // if the Pitch exists
                    if (this["Pitch"] != null)
                    {
                        // set the return value
                        pitch = this["Pitch"].ToString();
                    }

                    // return the value for pitch
                    return pitch;
                }
                set
                {
                    // set the value for Pitch
                    this["Pitch"] = value;
                }   
            }
            #endregion

            #region Rate
            /// <summary>
            /// This property gets or sets the value for Rate
            /// </summary>
            [UserScopedSetting()]
            public string Rate
            {
                get
                {
                    // initial value
                    string rate = "default";

                    // if the Rate exists
                    if (this["Rate"] != null)
                    {
                        // set the return value
                        rate = this["Rate"].ToString();
                    }

                    // return the value for pitch
                    return rate;
                }
                set
                {
                    // set the value for Pitch
                    this["Rate"] = value;
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

        #endregion
        
    }
    #endregion

}
