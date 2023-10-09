

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using ObjectLibrary.BusinessObjects;
using NAudio;
using NAudio.Wave;
using Simon.Util;
using System.Collections;
using System.Text;
using System.Media;

#endregion

namespace Simon
{

    #region class MainForm
    /// <summary>
    /// This class is the main form of this app.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Private Variables
        private List<Voice> voices;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region GetVoicesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'GetVoicesButton' is clicked.
        /// </summary>
        private async void GetVoicesButton_Click(object sender, EventArgs e)
        {
            string key = EnvironmentVariableHelper.GetEnvironmentVariableValue("SpeechKey", EnvironmentVariableTarget.Machine);
            string region = EnvironmentVariableHelper.GetEnvironmentVariableValue("SpeechRegion", EnvironmentVariableTarget.Machine);

            var config = SpeechConfig.FromSubscription(key, region);
            using var synthesizer = new SpeechSynthesizer(config, null as AudioConfig);
            using var result = await synthesizer.GetVoicesAsync();
            if (result.Reason == ResultReason.VoicesListRetrieved)
            {
                // retrieve the voices
                List<VoiceInfo> voices = result.Voices.Where(x => x.Locale.StartsWith("en")).ToList();

                // Create a new instance of a 'Gateway' object.
                // Gateway gateway = new Gateway(ApplicationLogicComponent.Connection.Connection.Name);

                // Iterate the collection of VoiceInfo objects
                foreach (VoiceInfo voiceInfo in voices)
                {
                    // Create a new instance of a 'Voice' object.
                    Voice voice = new Voice();

                    voice.Name = voiceInfo.LocalName;
                    voice.Locale = voiceInfo.Locale;
                    voice.FullName = voiceInfo.ShortName;
                    voice.Country = GetCountry(voiceInfo.Locale);

                    // Save this voice
                    // bool saved = gateway.SaveVoice(ref voice);

                    // if (!saved)
                    // {
                    // Exception error = gateway.GetLastException();
                    // }
                }

                // Set the text
                StatusLabel.Text = "Status: Finshed.";
            }
        }
        #endregion

        #region SpeakButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'SpeakButton' is clicked.
        /// </summary>
        private async void SpeakButton_Click(object sender, EventArgs e)
        {
            // Set Focus to the HiddenButton
            HiddenButton.Focus();

            // Make sure the UI updates with the SpeakButton lost focus
            Refresh();
            Application.DoEvents();

            string key = EnvironmentVariableHelper.GetEnvironmentVariableValue("SpeechKey", EnvironmentVariableTarget.Machine);
            string region = EnvironmentVariableHelper.GetEnvironmentVariableValue("SpeechRegion", EnvironmentVariableTarget.Machine);

            // get the text of the selected voice
            string voice = VoiceComboBox.ComboBoxText;
            string textToSpeak = TextToSpeakTextBox.Text;

            var config = SpeechConfig.FromSubscription(key, region);
            config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Raw48Khz16BitMonoPcm);

            config.SpeechSynthesisVoiceName = voice;
            var synthesizer = new SpeechSynthesizer(config, null as AudioConfig);

            // If the strings voice and textToSpeak both exist
            if (TextHelper.Exists(voice, textToSpeak))
            {
                // if the directory exists
                if (Directory.Exists(OutputFolderControl.Text))
                {
                    // Speak the text
                    var result = await synthesizer.SpeakTextAsync(textToSpeak);

                    // if success
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        // load the AudioDataStream
                        AudioDataStream audioDataStream = AudioDataStream.FromResult(result);  // to return in Memory  

                        // set the fileName and fileName2
                        string fileName = Path.Combine(OutputFolderControl.Text, OutputFileControl.Text);
                        string fileName2 = FileHelper.CreateFileNameWithPartialGuid(fileName, 12);

                        // get the byte array
                        byte[] buffer = result.AudioData;

                        // create the wavFormat
                        WaveFormat format = new WaveFormat(48000, 16, 1);

                        // now write out the file
                        using (WaveFileWriter writer = new WaveFileWriter(fileName2, format))
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }

                        // Show in red
                        StatusLabel.ForeColor = Color.LemonChiffon;

                        // show the status
                        StatusLabel.Text = "Status: The file " + fileName2 + " was created.";

                        // Play the Sound
                        SoundPlayer simpleSound = new SoundPlayer(fileName2);
                        simpleSound.Play();
                    }
                    else
                    {
                        // Show in red
                        StatusLabel.ForeColor = Color.Firebrick;

                        // show the status
                        StatusLabel.Text = "Houston, we have a problem. Something did not work.";
                    }
                }
                else
                {
                    // Show in red
                    StatusLabel.ForeColor = Color.Firebrick;

                    // show the status
                    StatusLabel.Text = "You must set the environment variables for SpeechKey and SpeechRegion must be 'centralus'";
                }
            }
            else
            {
                // Show in red
                StatusLabel.ForeColor = Color.Firebrick;

                // show the status
                StatusLabel.Text = "You must select a voice and enter the Text to Speak";
            }
        }
        #endregion

        #region WriteVoicesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'WriteVoicesButton' is clicked.
        /// </summary>
        private void WriteVoicesButton_Click(object sender, EventArgs e)
        {
            // locals
            StringBuilder sb = new StringBuilder();
            char comma = ',';

            // if my machine (database loaded voices)
            if (ListHelper.HasOneOrMoreItems(Voices))
            {
                // Create the path
                string path = @"../../../Voices/";

                // if the directory exists
                if (!Directory.Exists(path))
                {
                    // Must be installed version
                    path = "Voices";
                }

                // try again
                if (Directory.Exists(path))
                {
                    // Create a file
                    string filePath = Path.Combine(path, "Voices.txt");

                    // Iterate the collection of Voice objects
                    foreach (Voice voice in voices)
                    {
                        // Append Id
                        sb.Append(voice.Id);
                        sb.Append(comma);
                        sb.Append(voice.Name);
                        sb.Append(comma);
                        sb.Append(voice.Locale);
                        sb.Append(comma);
                        sb.Append(voice.FullName);
                        sb.Append(comma);
                        sb.Append(voice.Country);
                        sb.Append(Environment.NewLine);
                    }

                    // write out the text
                    string fileText = sb.ToString();
                    File.WriteAllText(filePath, fileText);

                    // Show that we are done
                    StatusLabel.Text = "Status: Voices have been exported to " + filePath;
                }
            }
        }
        #endregion

        #endregion

        #region Methods

        #region GetCountry(string locale)
        /// <summary>
        /// returns the Country
        /// </summary>
        public string GetCountry(string locale)
        {
            // initial value
            string country = "";

            // If the locale string exists
            if (TextHelper.Exists(locale))
            {
                switch (locale)
                {
                    case "en-AU":

                        country = "Australia";

                        // required
                        break;

                    case "en-CA":

                        country = "Canada";

                        // required
                        break;

                    case "en-GB":

                        country = "Breat Britain";

                        // required
                        break;

                    case "en-HK":

                        country = "Hong Kong";

                        // required
                        break;

                    case "en-IE":

                        country = "Ireland";

                        // required
                        break;

                    case "en-IN":

                        country = "India";

                        // required
                        break;

                    case "en-KE":

                        country = "Kenya";

                        // required
                        break;

                    case "en-NG":

                        country = "Nigeria";

                        // required
                        break;

                    case "en-PH":

                        country = "Philippines";

                        // required
                        break;

                    case "en-NZ":

                        country = "New Zealand";

                        // required
                        break;

                    case "en-SG":

                        country = "Singapore";

                        // required
                        break;

                    case "en-TZ":

                        country = "Tanzania";

                        // required
                        break;

                    case "en-ZA":

                        country = "South Africa";

                        // required
                        break;


                    case "en-US":

                        country = "United States";

                        // required
                        break;

                    default:

                        // for debugging only when finding the countries used
                        country = "";

                        // required
                        break;
                }
            }

            // return value
            return country;
        }
        #endregion

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // swithching to loading the voices from a text file, to make it easier to setup for non-sql developers
            // Gateway gateway = new Gateway(ApplicationLogicComponent.Connection.Connection.Name);
            // Voices = gateway.LoadVoices();

            // Set the OutputFolder
            OutputFolderControl.Text = @"c:\Temp";
            OutputFileControl.Text = @"Audio.wav";

            // Load the voices from a file
            LoadVoicesFromFile();

            // Load the voices
            VoiceComboBox.LoadItems(Voices);

            // Select Guy for now
            VoiceComboBox.SelectedIndex = VoiceComboBox.FindItemIndexByValue("en-US-TonyNeural");
        }
        #endregion

        #region LoadVoicesFromFile()
        /// <summary>
        /// returns a list of Voices From File
        /// </summary>
        public void LoadVoicesFromFile()
        {
            // local
            char[] delimiter = { ',' };

            // initial value
            Voices = new List<Voice>();

            // Create the path
            string path = @"../../../Voices/";

            // if the directory exists
            if (!Directory.Exists(path))
            {
                // Must be installed version
                path = "Voices";
            }

            // try again
            if (Directory.Exists(path))
            {
                // Create a file
                string filePath = Path.Combine(path, "Voices.txt");

                // if the file exists
                if (FileHelper.Exists(filePath))
                {
                    // read all text
                    string fileText = File.ReadAllText(filePath);

                    // If the fileText string exists
                    if (TextHelper.Exists(fileText))
                    {
                        // get the textLines
                        List<TextLine> lines = TextHelper.GetTextLines(fileText);

                        // If the lines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // Iterate the collection of TextLine objects
                            foreach (TextLine line in lines)
                            {
                                // get the words
                                List<Word> words = TextHelper.GetWords(line.Text, delimiter);

                                // if there are five words
                                if (ListHelper.HasXOrMoreItems(words, 5))
                                {
                                    // Create a new instance of a 'Voice' object.
                                    Voice voice = new Voice();

                                    // get the id
                                    voice.UpdateIdentity(NumericHelper.ParseInteger(words[0].Text, -1, -2));
                                    voice.Name = words[1].Text;
                                    voice.Locale = words[2].Text;
                                    voice.FullName = words[3].Text;
                                    voice.Country = words[4].Text;

                                    // Add this voice
                                    voices.Add(voice);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Properties

        #region HasVoices
        /// <summary>
        /// This property returns true if this object has a 'Voices'.
        /// </summary>
        public bool HasVoices
        {
            get
            {
                // initial value
                bool hasVoices = (this.Voices != null);

                // return value
                return hasVoices;
            }
        }
        #endregion

        #region Voices
        /// <summary>
        /// This property gets or sets the value for 'Voices'.
        /// </summary>
        public List<Voice> Voices
        {
            get { return voices; }
            set { voices = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
