

#region using statements

using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataJuggler.Win.Controls.Interfaces;
using NAudio;
using NAudio.Wave;
using Simon.Util;
using System.Collections;
using System.Text;
using System.Media;
using DataJuggler.Win.Controls;
using System.Diagnostics;

#endregion

namespace Simon
{

    #region class MainForm
    /// <summary>
    /// This class is the main form of this app.
    /// </summary>
    public partial class MainForm : Form, ISelectedIndexListener
    {

        #region Private Variables
        private List<Voice> voices;
        private Voice selectedVoice;
        private int index;
        private const string YouTubePath = "https://www.youtube.com/datajuggler";
        private const string SimonOnGitHub = "https://github.com/DataJuggler/Simon";
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

        #region GitHubButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'GitHubButton' is clicked.
        /// </summary>
        private void GitHubButton_Click(object sender, EventArgs e)
        {
            // launch to YouTube
            ProcessStartInfo info = new ProcessStartInfo { FileName = SimonOnGitHub, UseShellExecute = true };

            // launch
            System.Diagnostics.Process.Start(info);
        }
        #endregion

        #region GitHubButton_MouseEnter(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Git Hub Button _ Mouse Enter
        /// </summary>
        private void GitHubButton_MouseEnter(object sender, EventArgs e)
        {
            // Switch to a pointer
            Cursor = Cursors.Hand;
        }
        #endregion

        #region GitHubButton_MouseLeave(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Git Hub Button _ Mouse Leave
        /// </summary>
        private void GitHubButton_MouseLeave(object sender, EventArgs e)
        {
            // Change the cursor back to the default pointer
            Cursor = Cursors.Default;
        }
        #endregion

        #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
        /// <summary>
        /// event is fired when a selection is made in the 'On'.
        /// </summary>
        public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
        {
            // if a Voice was selected
            if (control.Name == "VoiceComboBox")
            {
                // Get the VoiceName
                string comboBoxText = VoiceComboBox.ComboBoxText;
                string voiceName = VoiceComboBox.ComboBoxText.Substring(0, VoiceComboBox.ComboBoxText.IndexOf(" - ")).Trim();

                // Set the SelectedVoice
                SelectedVoice = Voices.FirstOrDefault(x => x.Name == voiceName);

                // if the value for HasSelectedVoice is true
                if (HasSelectedVoice)
                {
                    // Display the Selected Voice's Gender
                    if (SelectedVoice.Gender == GenderEnum.Female)
                    {
                        // Select Female
                        GenderComboBox.SelectedIndex = 1;
                    }
                    else if (SelectedVoice.Gender == GenderEnum.Male)
                    {
                        // Select Male
                        GenderComboBox.SelectedIndex = 2;
                    }

                    // Display the Selected Voice's Country
                    CountryComboBox.SelectedIndex = CountryComboBox.FindItemIndexByValue(SelectedVoice.Country);

                    // Display the Full Name
                    FullNameControl.Text = SelectedVoice.FullName;
                }
            }
            else
            {
                // Filter by Gender and Country
                FilterLists();
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
            string voice = FullNameControl.Text;
            string textToSpeak = TextToSpeakTextBox.Text;

            if (HasSelectedVoice)
            {
                // replace out the VoiceName
                textToSpeak = textToSpeak.Replace("[VoiceName]", SelectedVoice.Name);
            }

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

                        // if checked and the SelectedVoice exists
                        if ((AppendVoiceNameCheckBox.Checked) && (HasSelectedVoice))
                        {
                            // Set the fileName
                            fileName = fileName.Replace(".wav", "_" + SelectedVoice.Name + ".wav");
                        }

                        // Ensure unique in a folder
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

        #region TryVoicesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'TryVoicesButton' is clicked.
        /// </summary>
        private void TryVoicesButton_Click(object sender, EventArgs e)
        {
            // Set Focus off this button
            HiddenButton.Focus();

            // reset
            Index = -1;

            // Start the timer
            VoicesTimer.Start();
        }
        #endregion

        #region VoicesTimer_Tick(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Voices Timer _ Tick
        /// </summary>
        private void VoicesTimer_Tick(object sender, EventArgs e)
        {
            // Increment the value for Index
            Index++;

            if (Index >= VoiceComboBox.Items.Count)
            {
                // Stop the timer
                VoicesTimer.Stop();
            }
            else
            {
                // Set the Index
                VoiceComboBox.SelectedIndex = Index;

                // Test this out
                SpeakButton_Click(this, new EventArgs());
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

        #region YouTubeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'YouTubeButton' is clicked.
        /// </summary>
        private void YouTubeButton_Click(object sender, EventArgs e)
        {
            // launch to YouTube
            ProcessStartInfo info = new ProcessStartInfo { FileName = YouTubePath, UseShellExecute = true };

            // launch
            System.Diagnostics.Process.Start(info);
        }
        #endregion

        #endregion

        #region Methods

        #region EraseSelections()
        /// <summary>
        /// Erase Selections
        /// </summary>
        public void EraseSelections()
        {
            try
            {
                CountryComboBox.SelectedIndex = -1;
                GenderComboBox.SelectedIndex = -1;
                VoiceComboBox.SelectedIndexListener = null;
                FullNameControl.Text = "";
                SelectedVoice = null;
                VoiceComboBox.SelectedIndex = -1;
                VoiceComboBox.SelectedIndexListener = this;
            }
            catch (Exception error)
            {
                // for debugging only
                DebugHelper.WriteDebugError("EraseSelections", "MainForm", error);
            }
        }
        #endregion

        #region FilterLists()
        /// <summary>
        /// Filter Lists
        /// </summary>
        public void FilterLists()
        {
            // Erase everything currently selected
            EraseSelections();

            // set the country
            string country = FilterCountryComboBox.ComboBoxText;

            // If All is selected
            if ((FilterCountryComboBox.SelectedIndex == 0) && (FilterGenderComboBox.SelectedIndex == 0))
            {
                // Load All Voices
                VoiceComboBox.LoadItems(Voices);
            }
            else if (FilterGenderComboBox.SelectedIndex == 0)
            {
                // All Genders by Country
                VoiceComboBox.LoadItems(Voices.Where(x => x.Country == country).ToList());
            }
            else if (FilterCountryComboBox.SelectedIndex == 0)
            {
                // This is all countries by Gender

                if (FilterGenderComboBox.SelectedIndex == 1)
                {
                    // Load All Voices
                    VoiceComboBox.LoadItems(FemaleVoices);
                }
                else if (FilterGenderComboBox.SelectedIndex == 2)
                {
                    // Load All Voices
                    VoiceComboBox.LoadItems(MaleVoices);
                }
            }
            else
            {
                // A Gender is selected and a Country is selected

                if (FilterGenderComboBox.SelectedIndex == 1)
                {
                    // Load All Voices
                    VoiceComboBox.LoadItems(FemaleVoices.Where(x => x.Country == country).ToList());
                }
                else if (FilterGenderComboBox.SelectedIndex == 2)
                {
                    // Load All Voices
                    VoiceComboBox.LoadItems(MaleVoices.Where(x => x.Country == country).ToList());
                }
            }
        }
        #endregion

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

            // Load the Filter Combo Boxes
            FilterGenderComboBox.LoadItems(typeof(GenderEnum));
            FilterCountryComboBox.LoadItems(typeof(CountryEnum));
            GenderComboBox.LoadItems(typeof(GenderEnum));
            CountryComboBox.LoadItems(typeof(CountryEnum));

            // Default value
            FilterGenderComboBox.SelectedIndex = 0;
            FilterCountryComboBox.SelectedIndex = 0;

            // Setup the Listeners for the Filters
            FilterGenderComboBox.SelectedIndexListener = this;
            FilterCountryComboBox.SelectedIndexListener = this;
            VoiceComboBox.SelectedIndexListener = this;

            // Set the OutputFolder
            OutputFolderControl.Text = @"c:\Temp";
            OutputFileControl.Text = @"Audio.wav";

            // Load the voices from a file
            LoadVoicesFromFile();

            // Load the voices
            VoiceComboBox.LoadItems(Voices);

            // Select Guy for now
            VoiceComboBox.SelectedIndex = VoiceComboBox.FindItemIndexByValue("en-US-TonyNeural");

            // Default Text, so people know how to use the [VoiceName] feature, and leave stars on Git Hub and subscribe.
            TextToSpeakTextBox.Text = "Hello, my name is [VoiceName]. If you think Simon is worth the price of free, please leave a star on Git Hub and subscribe to my YouTube channel.";
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
                                    voice.Gender = ParseGender(words[5].Text);

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

        #region ParseGender(string genderText)
        /// <summary>
        /// returns the Gender
        /// </summary>
        public GenderEnum ParseGender(string genderText)
        {
            // initial value
            GenderEnum gender = GenderEnum.Both;

            // If the genderText string exists
            if (TextHelper.Exists(genderText))
            {
                if (TextHelper.IsEqual(genderText, "Female"))
                {
                    // set to Female
                    gender = GenderEnum.Female;
                }
                else if (TextHelper.IsEqual(genderText, "Male"))
                {
                    // set to Male
                    gender = GenderEnum.Male;
                }
            }

            // return value
            return gender;
        }
        #endregion

        #endregion

        #region Properties

        #region FemaleVoices
        /// <summary>
        /// This read only property returns the value of MaleVoices from the object Voices.
        /// </summary>
        public List<Voice> FemaleVoices
        {

            get
            {
                // initial value
                List<Voice> femaleVoices = null;

                // if Voices exists
                if (Voices != null)
                {
                    // set the return value
                    femaleVoices = Voices.Where(x => x.Gender == GenderEnum.Female).ToList();
                }

                // return value
                return femaleVoices;
            }
        }
        #endregion

        #region HasSelectedVoice
        /// <summary>
        /// This property returns true if this object has a 'SelectedVoice'.
        /// </summary>
        public bool HasSelectedVoice
        {
            get
            {
                // initial value
                bool hasSelectedVoice = (this.SelectedVoice != null);

                // return value
                return hasSelectedVoice;
            }
        }
        #endregion

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

        #region Index
        /// <summary>
        /// This property gets or sets the value for 'Index'.
        /// </summary>
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        #endregion

        #region MaleVoices
        /// <summary>
        /// This read only property returns the value of MaleVoices from the object Voices.
        /// </summary>
        public List<Voice> MaleVoices
        {

            get
            {
                // initial value
                List<Voice> maleVoices = null;

                // if Voices exists
                if (Voices != null)
                {
                    // set the return value
                    maleVoices = Voices.Where(x => x.Gender == GenderEnum.Male).ToList();
                }

                // return value
                return maleVoices;
            }
        }
        #endregion

        #region SelectedVoice
        /// <summary>
        /// This property gets or sets the value for 'SelectedVoice'.
        /// </summary>
        public Voice SelectedVoice
        {
            get { return selectedVoice; }
            set { selectedVoice = value; }
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
