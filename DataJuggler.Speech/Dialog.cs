

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Enumerations;

#endregion

namespace DataJuggler.Speech
{

    #region class Dialog
    /// <summary>
    /// This class represents speaking by one character.
    /// </summary>
    public class Dialog
    {
        
        #region Private Variables
        private string name;
        private string voiceName;
        private string textToSpeak;
        private RateEnum rate;
        private EmotionEnum emotion;
        #endregion

        #region Properties

            #region Emotion
            /// <summary>
            /// This property gets or sets the value for 'Emotion'.
            /// </summary>
            public EmotionEnum Emotion
            {
                get { return emotion; }
                set { emotion = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Rate
            /// <summary>
            /// This property gets or sets the value for 'Rate'.
            /// </summary>
            public RateEnum Rate
            {
                get { return rate; }
                set { rate = value; }
            }
            #endregion
            
            #region TextToSpeak
            /// <summary>
            /// This property gets or sets the value for 'TextToSpeak'.
            /// </summary>
            public string TextToSpeak
            {
                get { return textToSpeak; }
                set { textToSpeak = value; }
            }
            #endregion
            
            #region VoiceName
            /// <summary>
            /// This property gets or sets the value for 'VoiceName'.
            /// </summary>
            public string VoiceName
            {
                get { return voiceName; }
                set { voiceName = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
