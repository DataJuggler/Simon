

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
using System.Collections;
using System.Text;
using System.Media;
using DataJuggler.Win.Controls;
using System.Diagnostics;
using Simon.Security;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

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
        private SoundPlayer player;
        private SecureUserData settings;
        private bool tryVoicesInProgress;
        private string key;
        private string region;

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

        #region MainForm_Load(object sender, EventArgs e)
        /// <summary>
        /// event is fired when Main Form _ Load
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create a new instance of a 'SecureUserData' object.
            Settings = new SecureUserData();

            // Set the OutputFolder
            string outputFolder = Settings.OutputFolder;
            OutputFolderControl.Text = outputFolder;

            // Check for a Gender filter
            string gender = Settings.GenderFilter;

            // if a Gender was found
            if (TextHelper.Exists(gender))
            {
                // attempt to find the index
                int index = GenderComboBox.FindItemIndexByValue(gender);

                // Set the genderIndex
                FilterGenderComboBox.SelectedIndex = index;
            }

            // Check for a Country filter
            string country = Settings.CountryFilter;

            // if a Country was found
            if (TextHelper.Exists(country))
            {
                // attempt to find the index
                int index = CountryComboBox.FindItemIndexByValue(country);

                // Set the genderIndex
                FilterCountryComboBox.SelectedIndex = index;
            }

            // Attempt to Select the last voice if the voice is available with the current filters.
            if (TextHelper.Exists(Settings.Voice))
            {
                // get the voice display text
                string voiceDisplayText = Settings.Voice + " - " + FilterCountryComboBox.ComboBoxText;

                // get the index of the last voice
                int index = VoiceComboBox.FindItemIndexByValue(voiceDisplayText);

                // Set the index
                VoiceComboBox.SelectedIndex = index;
            }

            // Checking this by default
            AppendVoiceNameCheckBox.Checked = Settings.AppendVoiceName;

            // get the value for Emotion
            string emotion = Settings.Emotion;

            // If the emotion string exists
            if (TextHelper.Exists(emotion))
            {
                // Find the Emotion
                EmotionComboBox.SelectedIndex = FindEmotionIndex(emotion);
            }

            // Set the value for Degree
            string degree = Settings.Degree;

            // If the degree string exists
            if (TextHelper.Exists(degree))
            {
                // display the value for Degree
                DegreeTextBox.Text = degree;
            }

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
                // Do not fiilter the lists while TryVoicesInProogress is true
                if (!TryVoicesInProgress)
                {
                    // Filter by Gender and Country
                    FilterLists();
                }
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

            // Restore the color
            StatusLabel.ForeColor = Color.LemonChiffon;

            // Change the text
            StatusLabel.Text = "Processing...";

            // Refresh the UI
            Refresh();
            Application.DoEvents();

            // Load the Environment Variables
            LoadKeyAndRegion();

            // If the strings key and region both exist
            if ((HasKey) && (HasRegion))
            {
                // if a voice is selected
                if (HasSelectedVoice)
                {
                    // Setup Settings
                    Settings.Voice = SelectedVoice.Name;
                    Settings.GenderFilter = GenderComboBox.ComboBoxText;
                    Settings.CountryFilter = CountryComboBox.ComboBoxText;
                    Settings.AppendVoiceName = AppendVoiceNameCheckBox.Checked;
                    Settings.Emotion = EmotionComboBox.ComboBoxText;
                    Settings.Degree = DegreeTextBox.Text;

                    // if the MakeDefaultDirectory checkbox is checked
                    if (MakeDefaultDirectory.Checked)
                    {
                        // Store the Output Folder
                        Settings.OutputFolder = OutputFolderControl.Text;
                    }

                    // Save the settings
                    Settings.Save();

                    // get the text to speack
                    string textToSpeak = TextToSpeakTextBox.Text;

                    // replace out the VoiceName
                    textToSpeak = textToSpeak.Replace("[VoiceName]", SelectedVoice.Name);

                    // Create the SpeachConfig object
                    var config = SpeechConfig.FromSubscription(Key, Region);
                    config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Raw48Khz16BitMonoPcm);

                    config.SpeechSynthesisVoiceName = SelectedVoice.FullName; ;
                    var synthesizer = new SpeechSynthesizer(config, null as AudioConfig);

                    // If the string textToSpeak exists
                    if (TextHelper.Exists(textToSpeak))
                    {
                        // Set the Timer Interval if TryVoicesInProgress is true and this is the first item
                        if ((TryVoicesInProgress) && (Index == 0))
                        {
                            // set the timer interval
                            VoicesTimer.Interval = textToSpeak.Length * 75;
                        }

                        // if the directory exists
                        if (Directory.Exists(OutputFolderControl.Text))
                        {
                            // if the OutputFileControl has a value
                            if (TextHelper.Exists(OutputFileControl.Text))
                            {
                                // Get the text of the file
                                string fileText = GetSSMLFileText();

                                // Set the fileText
                                fileText = fileText.Replace("[TextToSpeak]", textToSpeak);

                                // Speak the text
                                // var result = await synthesizer.SpeakTextAsync(textToSpeak);
                                var result = await synthesizer.SpeakSsmlAsync(fileText);

                                // if success
                                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                                {
                                    // load the AudioDataStream in Memory  
                                    AudioDataStream audioDataStream = AudioDataStream.FromResult(result);

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
                                    Player = new SoundPlayer(fileName2);

                                    // Play the sound
                                    Player.Play();
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
                                StatusLabel.Text = "You must enter a file name, and it must end in .wav";
                            }
                        }
                        else
                        {
                            // Show in red
                            StatusLabel.ForeColor = Color.Firebrick;

                            if (TextHelper.Exists(OutputFolderControl.Text))
                            {
                                // show the status
                                StatusLabel.Text = "You must select or enter an Output Folder.";
                            }
                            else if (!Directory.Exists(OutputFolderControl.Text))
                            {
                                // show the status
                                StatusLabel.Text = "The ouput folder does not exist.";
                            }
                        }
                    }
                    else
                    {
                        // Show in red
                        StatusLabel.ForeColor = Color.Firebrick;

                        // show the status
                        StatusLabel.Text = "You must enter the text to speak.";
                    }
                }
                else
                {
                    // Show in red
                    StatusLabel.ForeColor = Color.Firebrick;

                    // show the status
                    StatusLabel.Text = "You must select a voice.";
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
        #endregion

        #region StopButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'StopButton' is clicked.
        /// </summary>
        private void StopButton_Click(object sender, EventArgs e)
        {
            // Stop the Timer
            VoicesTimer.Stop();

            // Reset Timer Duration
            VoicesTimer.Stop();

            // Reset
            Index = -1;

            // No longer trying voices
            TryVoicesInProgress = false;

            // if the value for HasPlayer is true
            if (HasPlayer)
            {
                // Stop Player
                Player.Stop();

                // Show a message
                StatusLabel.Text = "Status: Player was stopped.";
            }
        }
        #endregion

        #region TryVoicesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'TryVoicesButton' is clicked.
        /// </summary>
        private void TryVoicesButton_Click(object sender, EventArgs e)
        {
            // Reset the Interval
            VoicesTimer.Interval = 5000;

            // Show the user a message
            StatusLabel.Text = "Setting up voices, please wait...";
            StatusLabel.ForeColor = Color.LemonChiffon;

            // Set Focus off this button
            HiddenButton.Focus();

            // Refresh the App
            Refresh();
            Application.DoEvents();

            // reset
            Index = -1;

            // Set this to true, so voices are not stored during Speak
            TryVoicesInProgress = true;

            // Start the timer
            VoicesTimer.Start();

            // Set this to false, so next Voice selected will be stored
            TryVoicesInProgress = true;
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

            // if hte last voice has finished
            if (Index >= VoiceComboBox.Items.Count)
            {
                // Show a message finished
                StatusLabel.Text = "Status: Try Voices Complete.";

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

        #region FindEmotionIndex(string emotion)
        /// <summary>
        /// returns the Emotion Index
        /// </summary>
        public static int FindEmotionIndex(string emotion)
        {
            // initial value (Narration Relaxed Reading)
            int index = 21;

            // Determine the action by the emotion
            switch (emotion)
            {
                case "Advertisement Upbeat":

                    // set the return value
                    index = 0;

                    // required
                    break;

                case "Affectionate":

                    // set the return value
                    index = 1;

                    // required
                    break;

                case "Angry":

                    // set the return value
                    index = 2;

                    // required
                    break;

                case "Assistant":

                    // set the return value
                    index = 3;

                    // required
                    break;

                case "Calm":

                    // set the return value
                    index = 4;

                    // required
                    break;

                case "Chat":

                    // set the return value
                    index = 5;

                    // required
                    break;

                case "Cheerful":

                    // set the return value
                    index = 6;

                    // required
                    break;

                case "Customer Service":

                    // set the return value
                    index = 7;

                    // required
                    break;

                case "Depressed":

                    // set the return value
                    index = 8;

                    // required
                    break;

                case "Disgruntled":

                    // set the return value
                    index = 9;

                    // required
                    break;

                case "Documentary Narration":

                    // set the return value
                    index = 10;

                    // required
                    break;

                case "Embarrassed":

                    // set the return value
                    index = 11;

                    // required
                    break;

                case "Empathetic":

                    // set the return value
                    index = 12;

                    // required
                    break;

                case "Envious":

                    // set the return value
                    index = 13;

                    // required
                    break;

                case "Excited":

                    // set the return value
                    index = 14;

                    // required
                    break;

                case "Fearful":

                    // set the return value
                    index = 15;

                    // required
                    break;

                case "Friendly":

                    // set the return value
                    index = 16;

                    // required
                    break;

                case "Gentle":

                    // set the return value
                    index = 17;

                    // required
                    break;

                case "Hopeful":

                    // set the return value
                    index = 18;

                    // required
                    break;

                case "Lyrical":

                    // set the return value
                    index = 19;

                    // required
                    break;

                case "Narration Professional":

                    // set the return value
                    index = 20;

                    // required
                    break;

                case "Newscast":

                    // set the return value
                    index = 22;

                    // required
                    break;

                case "Newscast Casual":

                    // set the return value
                    index = 23;

                    // required
                    break;

                case "Newscast_Formal":

                    // set the return value
                    index = 24;

                    // required
                    break;

                case "Poetry Reading":

                    // set the return value
                    index = 25;

                    // required
                    break;

                case "Shouting":

                    // set the return value
                    index = 26;

                    // required
                    break;

                case "Sports Commentary":

                    // set the return value
                    index = 27;

                    // required
                    break;

                case "Sports Commentary Excited":

                    // set the return value
                    index = 28;

                    // required
                    break;

                case "Terrified":

                    // set the return value
                    index = 29;

                    // required
                    break;

                case "Unfriendly":

                    // set the return value
                    index = 30;

                    // required
                    break;

                case "Whispering":

                    // set the return value
                    index = 31;

                    // required
                    break;

                default:

                    // default to Narration Relaxed Reading
                    index = 21;

                    // required
                    break;
            }

            // return value
            return index;
        }
        #endregion

        #region GetCountry(string locale)
        /// <summary>
        /// returns the Country
        /// </summary>
        public static string GetCountry(string locale)
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

        #region GetEmotion()
        /// <summary>
        /// returns the Emotion
        /// </summary>
        public string GetEmotion()
        {
            // initial value
            string emotion = EmotionComboBox.ComboBoxText.Replace(" ", "");

            // Determine the action by the emotion
            switch (emotion)
            {
                case "DocumentaryNarration":

                    // set the return value
                    emotion = "documentary-narration";

                    // required
                    break;

                case "NarrationProfessional":

                    // set the return value
                    emotion = "narration-professional";

                    // required
                    break;

                case "NarrationRelaxedReading":

                    // set the return value
                    emotion = "narration-relaxedreading";

                    // required
                    break;

                default:

                    // set the return value
                    emotion = TextHelper.CapitalizeFirstChar(emotion, true);

                    // required
                    break;
            }

            // return value
            return emotion;
        }
        #endregion

        #region GetRole()
        /// <summary>
        /// returns the Role
        /// </summary>
        public string GetRole()
        {
            // initial value
            string role = "";

            if (HasSelectedVoice)
            {
                if (SelectedVoice.Gender == GenderEnum.Female)
                {
                    // Girl
                    role = "Girl";
                }
                else
                {
                    // Muse be a boy
                    role = "Boy";
                }
            }

            // return value
            return role;
        }
        #endregion

        #region GetSSMLFileText()
        /// <summary>
        /// returns the SSML File Text
        /// </summary>
        public string GetSSMLFileText()
        {
            // initial value
            string fileText = "";

            // Create the path
            string path = @"../../../SSML/VoiceInfo.txt";

            // if the directory exists
            if (!FileHelper.Exists(path))
            {
                // Must be installed version
                path = "SSML/VoiceInfo.txt";
            }

            // Read all the text of the file            
            fileText = File.ReadAllText(path).Replace("[VoiceName]", SelectedVoice.FullName);

            // if the file exists
            if (TextHelper.Exists(fileText))
            {
                // Get the users selections
                string emotion = GetEmotion();
                string role = GetRole();
                string degree = DegreeTextBox.Text;

                // Set the role
                fileText = fileText.Replace("[Role]", role);

                // Set the Emotion
                fileText = fileText.Replace("[Emotion]", emotion);

                // Set the Degree
                fileText = fileText.Replace("[Degree]", degree);

                // Replace out the Locale
                fileText = fileText.Replace("[Locale]", SelectedVoice.Locale);
            }

            // return value
            return fileText;
        }
        #endregion

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
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

            // Set the OutputFile
            OutputFileControl.Text = @"Audio.wav";

            // Load the voices from a file
            LoadVoicesFromFile();

            // Load the voices
            VoiceComboBox.LoadItems(Voices);

            // Load the Emotions
            EmotionComboBox.LoadItems(typeof(EmotionEnum));

            // Deafult to 
            EmotionComboBox.SelectedIndex = EmotionComboBox.FindItemIndexByValue("Narration Relaxed Reading");

            // Default to 1 degree for emotion
            DegreeTextBox.Text = "1";

            // Default Text, so people know how to use the [VoiceName] feature, and leave stars on Git Hub and subscribe.
            TextToSpeakTextBox.Text = "Hello, my name is [VoiceName]. If you think Simon is worth the price of free, please leave a star on GitHub, and subscribe to my YouTube channel.";
        }
        #endregion

        #region LoadKeyAndRegion()
        /// <summary>
        /// Load Key And Region
        /// </summary>
        public void LoadKeyAndRegion()
        {
            // ensure EnvironmentVariables for key and region and loaded
            if (!HasKey)
            {
                // set the value for Key
                Key = EnvironmentVariableHelper.GetEnvironmentVariableValue("SpeechKey", EnvironmentVariableTarget.Machine);
            }

            // if the value for HasRegion is false
            if (!HasRegion)
            {
                // set the value for Key
                Region = EnvironmentVariableHelper.GetEnvironmentVariableValue("SpeechRegion", EnvironmentVariableTarget.Machine);
            }
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
        public static GenderEnum ParseGender(string genderText)
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

        #region HasKey
        /// <summary>
        /// This property returns true if the 'Key' exists.
        /// </summary>
        public bool HasKey
        {
            get
            {
                // initial value
                bool hasKey = (TextHelper.Exists(Key));

                // return value
                return hasKey;
            }
        }
        #endregion

        #region HasPlayer
        /// <summary>
        /// This property returns true if this object has a 'Player'.
        /// </summary>
        public bool HasPlayer
        {
            get
            {
                // initial value
                bool hasPlayer = (this.Player != null);

                // return value
                return hasPlayer;
            }
        }
        #endregion

        #region HasRegion
        /// <summary>
        /// This property returns true if the 'Region' exists.
        /// </summary>
        public bool HasRegion
        {
            get
            {
                // initial value
                bool hasRegion = (TextHelper.Exists(Region));

                // return value
                return hasRegion;
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

        #region Key
        /// <summary>
        /// This property gets or sets the value for 'Key'.
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
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

        #region Player
        /// <summary>
        /// This property gets or sets the value for 'Player'.
        /// </summary>
        public SoundPlayer Player
        {
            get { return player; }
            set { player = value; }
        }
        #endregion

        #region Region
        /// <summary>
        /// This property gets or sets the value for 'Region'.
        /// </summary>
        public new string Region
        {
            get { return region; }
            set { region = value; }
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

        #region Settings
        /// <summary>
        /// This property gets or sets the value for 'Settings'.
        /// </summary>
        public SecureUserData Settings
        {
            get { return settings; }
            set { settings = value; }
        }
        #endregion

        #region TryVoicesInProgress
        /// <summary>
        /// This property gets or sets the value for 'TryVoicesInProgress'.
        /// </summary>
        public bool TryVoicesInProgress
        {
            get { return tryVoicesInProgress; }
            set { tryVoicesInProgress = value; }
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
