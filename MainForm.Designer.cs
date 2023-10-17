

#region using statements


#endregion

namespace Simon
{

    #region class MainForm
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    partial class MainForm
    {

        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Label StatusLabel;
        private DataJuggler.Win.Controls.LabelTextBoxControl TextToSpeakTextBox;
        private DataJuggler.Win.Controls.Button GetVoicesButton;
        private DataJuggler.Win.Controls.Button SpeakButton;
        private DataJuggler.Win.Controls.LabelComboBoxControl VoiceComboBox;
        private DataJuggler.Win.Controls.Button WriteVoicesButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl OutputFileControl;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl OutputFolderControl;
        private DataJuggler.Win.Controls.Button PreviewButton;
        #endregion

        #region Methods

        #region Dispose(bool disposing)
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitializeComponent()
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TextToSpeakTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            GetVoicesButton = new DataJuggler.Win.Controls.Button();
            SpeakButton = new DataJuggler.Win.Controls.Button();
            StatusLabel = new Label();
            VoiceComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            WriteVoicesButton = new DataJuggler.Win.Controls.Button();
            OutputFileControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            OutputFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            HiddenButton = new DataJuggler.Win.Controls.Button();
            VoicesTimer = new System.Windows.Forms.Timer(components);
            TryVoicesButton = new DataJuggler.Win.Controls.Button();
            AppendVoiceNameCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            FullNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            GenderComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            CountryComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            FilterPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            FilterCountryComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            FilterGenderComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            FilterLabel = new Label();
            GitHubButton = new PictureBox();
            YouTubeButton = new PictureBox();
            LeaveAStarPleaseLabel = new Label();
            SubscribeLabel = new Label();
            StopButton = new DataJuggler.Win.Controls.Button();
            FilterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GitHubButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YouTubeButton).BeginInit();
            SuspendLayout();
            // 
            // TextToSpeakTextBox
            // 
            TextToSpeakTextBox.BackColor = Color.Transparent;
            TextToSpeakTextBox.BottomMargin = 0;
            TextToSpeakTextBox.Editable = true;
            TextToSpeakTextBox.Encrypted = false;
            TextToSpeakTextBox.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TextToSpeakTextBox.Inititialized = true;
            TextToSpeakTextBox.LabelBottomMargin = 0;
            TextToSpeakTextBox.LabelColor = Color.LemonChiffon;
            TextToSpeakTextBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TextToSpeakTextBox.LabelText = "Text To Speak:";
            TextToSpeakTextBox.LabelTopMargin = 0;
            TextToSpeakTextBox.LabelWidth = 160;
            TextToSpeakTextBox.Location = new Point(31, 185);
            TextToSpeakTextBox.MultiLine = true;
            TextToSpeakTextBox.Name = "TextToSpeakTextBox";
            TextToSpeakTextBox.OnTextChangedListener = null;
            TextToSpeakTextBox.PasswordMode = false;
            TextToSpeakTextBox.ScrollBars = ScrollBars.None;
            TextToSpeakTextBox.Size = new Size(821, 189);
            TextToSpeakTextBox.TabIndex = 0;
            TextToSpeakTextBox.TextBoxBottomMargin = 0;
            TextToSpeakTextBox.TextBoxDisabledColor = Color.LightGray;
            TextToSpeakTextBox.TextBoxEditableColor = Color.White;
            TextToSpeakTextBox.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TextToSpeakTextBox.TextBoxTopMargin = 0;
            TextToSpeakTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // GetVoicesButton
            // 
            GetVoicesButton.BackColor = Color.Transparent;
            GetVoicesButton.ButtonText = "Get Voices";
            GetVoicesButton.Enabled = false;
            GetVoicesButton.FlatStyle = FlatStyle.Flat;
            GetVoicesButton.ForeColor = Color.LemonChiffon;
            GetVoicesButton.Location = new Point(-600, 607);
            GetVoicesButton.Margin = new Padding(5);
            GetVoicesButton.Name = "GetVoicesButton";
            GetVoicesButton.Size = new Size(175, 55);
            GetVoicesButton.TabIndex = 1;
            GetVoicesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            GetVoicesButton.Visible = false;
            GetVoicesButton.Click += GetVoicesButton_Click;
            // 
            // SpeakButton
            // 
            SpeakButton.BackColor = Color.Transparent;
            SpeakButton.ButtonText = "Speak";
            SpeakButton.FlatStyle = FlatStyle.Flat;
            SpeakButton.ForeColor = Color.LemonChiffon;
            SpeakButton.Location = new Point(378, 580);
            SpeakButton.Margin = new Padding(5);
            SpeakButton.Name = "SpeakButton";
            SpeakButton.Size = new Size(127, 55);
            SpeakButton.TabIndex = 2;
            SpeakButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            SpeakButton.Click += SpeakButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Dock = DockStyle.Bottom;
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(0, 676);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(893, 33);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Status:";
            // 
            // VoiceComboBox
            // 
            VoiceComboBox.BackColor = Color.Transparent;
            VoiceComboBox.ComboBoxLeftMargin = 1;
            VoiceComboBox.ComboBoxText = "";
            VoiceComboBox.ComoboBoxFont = null;
            VoiceComboBox.Editable = true;
            VoiceComboBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            VoiceComboBox.HideLabel = false;
            VoiceComboBox.LabelBottomMargin = 0;
            VoiceComboBox.LabelColor = Color.LemonChiffon;
            VoiceComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            VoiceComboBox.LabelText = "Voice:";
            VoiceComboBox.LabelTopMargin = 0;
            VoiceComboBox.LabelWidth = 160;
            VoiceComboBox.List = null;
            VoiceComboBox.Location = new Point(31, 91);
            VoiceComboBox.Name = "VoiceComboBox";
            VoiceComboBox.SelectedIndex = -1;
            VoiceComboBox.SelectedIndexListener = null;
            VoiceComboBox.Size = new Size(483, 28);
            VoiceComboBox.Sorted = true;
            VoiceComboBox.Source = null;
            VoiceComboBox.TabIndex = 4;
            VoiceComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // WriteVoicesButton
            // 
            WriteVoicesButton.BackColor = Color.Transparent;
            WriteVoicesButton.ButtonText = "Write Voices";
            WriteVoicesButton.FlatStyle = FlatStyle.Flat;
            WriteVoicesButton.ForeColor = Color.LemonChiffon;
            WriteVoicesButton.Location = new Point(-800, 607);
            WriteVoicesButton.Margin = new Padding(5);
            WriteVoicesButton.Name = "WriteVoicesButton";
            WriteVoicesButton.Size = new Size(175, 55);
            WriteVoicesButton.TabIndex = 5;
            WriteVoicesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            WriteVoicesButton.Visible = false;
            WriteVoicesButton.Click += WriteVoicesButton_Click;
            // 
            // OutputFileControl
            // 
            OutputFileControl.BackColor = Color.Transparent;
            OutputFileControl.BottomMargin = 0;
            OutputFileControl.Editable = true;
            OutputFileControl.Encrypted = false;
            OutputFileControl.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            OutputFileControl.Inititialized = true;
            OutputFileControl.LabelBottomMargin = 0;
            OutputFileControl.LabelColor = Color.LemonChiffon;
            OutputFileControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            OutputFileControl.LabelText = "File Name:";
            OutputFileControl.LabelTopMargin = 0;
            OutputFileControl.LabelWidth = 160;
            OutputFileControl.Location = new Point(31, 442);
            OutputFileControl.MultiLine = false;
            OutputFileControl.Name = "OutputFileControl";
            OutputFileControl.OnTextChangedListener = null;
            OutputFileControl.PasswordMode = false;
            OutputFileControl.ScrollBars = ScrollBars.None;
            OutputFileControl.Size = new Size(821, 32);
            OutputFileControl.TabIndex = 6;
            OutputFileControl.TextBoxBottomMargin = 0;
            OutputFileControl.TextBoxDisabledColor = Color.LightGray;
            OutputFileControl.TextBoxEditableColor = Color.White;
            OutputFileControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OutputFileControl.TextBoxTopMargin = 0;
            OutputFileControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // OutputFolderControl
            // 
            OutputFolderControl.BackColor = Color.Transparent;
            OutputFolderControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            OutputFolderControl.ButtonColor = Color.LemonChiffon;
            OutputFolderControl.ButtonImage = (Image)resources.GetObject("OutputFolderControl.ButtonImage");
            OutputFolderControl.ButtonWidth = 48;
            OutputFolderControl.DarkMode = false;
            OutputFolderControl.DisabledLabelColor = Color.Empty;
            OutputFolderControl.Editable = true;
            OutputFolderControl.EnabledLabelColor = Color.Empty;
            OutputFolderControl.Filter = null;
            OutputFolderControl.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OutputFolderControl.HideBrowseButton = false;
            OutputFolderControl.LabelBottomMargin = 0;
            OutputFolderControl.LabelColor = Color.LemonChiffon;
            OutputFolderControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            OutputFolderControl.LabelText = "Output Folder:";
            OutputFolderControl.LabelTopMargin = 0;
            OutputFolderControl.LabelWidth = 160;
            OutputFolderControl.Location = new Point(31, 391);
            OutputFolderControl.Name = "OutputFolderControl";
            OutputFolderControl.OnTextChangedListener = null;
            OutputFolderControl.OpenCallback = null;
            OutputFolderControl.ScrollBars = ScrollBars.None;
            OutputFolderControl.SelectedPath = null;
            OutputFolderControl.Size = new Size(821, 32);
            OutputFolderControl.StartPath = null;
            OutputFolderControl.TabIndex = 7;
            OutputFolderControl.TextBoxBottomMargin = 0;
            OutputFolderControl.TextBoxDisabledColor = Color.Empty;
            OutputFolderControl.TextBoxEditableColor = Color.Empty;
            OutputFolderControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OutputFolderControl.TextBoxTopMargin = 0;
            OutputFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // HiddenButton
            // 
            HiddenButton.BackColor = Color.Transparent;
            HiddenButton.ButtonText = "Hidden";
            HiddenButton.FlatStyle = FlatStyle.Flat;
            HiddenButton.ForeColor = Color.LemonChiffon;
            HiddenButton.Location = new Point(-2000, 551);
            HiddenButton.Margin = new Padding(5);
            HiddenButton.Name = "HiddenButton";
            HiddenButton.Size = new Size(175, 55);
            HiddenButton.TabIndex = 8;
            HiddenButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // VoicesTimer
            // 
            VoicesTimer.Interval = 10000;
            VoicesTimer.Tick += VoicesTimer_Tick;
            // 
            // TryVoicesButton
            // 
            TryVoicesButton.BackColor = Color.Transparent;
            TryVoicesButton.ButtonText = "Try Voices";
            TryVoicesButton.FlatStyle = FlatStyle.Flat;
            TryVoicesButton.ForeColor = Color.LemonChiffon;
            TryVoicesButton.Location = new Point(216, 580);
            TryVoicesButton.Margin = new Padding(5);
            TryVoicesButton.Name = "TryVoicesButton";
            TryVoicesButton.Size = new Size(127, 55);
            TryVoicesButton.TabIndex = 9;
            TryVoicesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            TryVoicesButton.Click += TryVoicesButton_Click;
            // 
            // AppendVoiceNameCheckBox
            // 
            AppendVoiceNameCheckBox.BackColor = Color.Transparent;
            AppendVoiceNameCheckBox.CheckBoxHorizontalOffSet = 0;
            AppendVoiceNameCheckBox.CheckBoxVerticalOffSet = 3;
            AppendVoiceNameCheckBox.CheckChangedListener = null;
            AppendVoiceNameCheckBox.Checked = false;
            AppendVoiceNameCheckBox.Editable = true;
            AppendVoiceNameCheckBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AppendVoiceNameCheckBox.LabelColor = Color.LemonChiffon;
            AppendVoiceNameCheckBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AppendVoiceNameCheckBox.LabelText = "Append Voice Name:";
            AppendVoiceNameCheckBox.LabelWidth = 196;
            AppendVoiceNameCheckBox.Location = new Point(642, 477);
            AppendVoiceNameCheckBox.Name = "AppendVoiceNameCheckBox";
            AppendVoiceNameCheckBox.Size = new Size(220, 28);
            AppendVoiceNameCheckBox.TabIndex = 10;
            AppendVoiceNameCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // FullNameControl
            // 
            FullNameControl.BackColor = Color.Transparent;
            FullNameControl.BottomMargin = 0;
            FullNameControl.Editable = true;
            FullNameControl.Encrypted = false;
            FullNameControl.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FullNameControl.Inititialized = true;
            FullNameControl.LabelBottomMargin = 0;
            FullNameControl.LabelColor = Color.LemonChiffon;
            FullNameControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FullNameControl.LabelText = "Full Name:";
            FullNameControl.LabelTopMargin = 0;
            FullNameControl.LabelWidth = 160;
            FullNameControl.Location = new Point(31, 135);
            FullNameControl.MultiLine = false;
            FullNameControl.Name = "FullNameControl";
            FullNameControl.OnTextChangedListener = null;
            FullNameControl.PasswordMode = false;
            FullNameControl.ScrollBars = ScrollBars.None;
            FullNameControl.Size = new Size(483, 32);
            FullNameControl.TabIndex = 11;
            FullNameControl.TextBoxBottomMargin = 0;
            FullNameControl.TextBoxDisabledColor = Color.LightGray;
            FullNameControl.TextBoxEditableColor = Color.White;
            FullNameControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FullNameControl.TextBoxTopMargin = 0;
            FullNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // GenderComboBox
            // 
            GenderComboBox.BackColor = Color.Transparent;
            GenderComboBox.ComboBoxLeftMargin = 1;
            GenderComboBox.ComboBoxText = "";
            GenderComboBox.ComoboBoxFont = null;
            GenderComboBox.Editable = true;
            GenderComboBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GenderComboBox.HideLabel = false;
            GenderComboBox.LabelBottomMargin = 0;
            GenderComboBox.LabelColor = Color.LemonChiffon;
            GenderComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            GenderComboBox.LabelText = "Gender:";
            GenderComboBox.LabelTopMargin = 0;
            GenderComboBox.LabelWidth = 100;
            GenderComboBox.List = null;
            GenderComboBox.Location = new Point(539, 91);
            GenderComboBox.Name = "GenderComboBox";
            GenderComboBox.SelectedIndex = -1;
            GenderComboBox.SelectedIndexListener = null;
            GenderComboBox.Size = new Size(313, 28);
            GenderComboBox.Sorted = true;
            GenderComboBox.Source = null;
            GenderComboBox.TabIndex = 12;
            GenderComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // CountryComboBox
            // 
            CountryComboBox.BackColor = Color.Transparent;
            CountryComboBox.ComboBoxLeftMargin = 1;
            CountryComboBox.ComboBoxText = "";
            CountryComboBox.ComoboBoxFont = null;
            CountryComboBox.Editable = true;
            CountryComboBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CountryComboBox.HideLabel = false;
            CountryComboBox.LabelBottomMargin = 0;
            CountryComboBox.LabelColor = Color.LemonChiffon;
            CountryComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CountryComboBox.LabelText = "Country:";
            CountryComboBox.LabelTopMargin = 0;
            CountryComboBox.LabelWidth = 100;
            CountryComboBox.List = null;
            CountryComboBox.Location = new Point(539, 138);
            CountryComboBox.Name = "CountryComboBox";
            CountryComboBox.SelectedIndex = -1;
            CountryComboBox.SelectedIndexListener = null;
            CountryComboBox.Size = new Size(313, 28);
            CountryComboBox.Sorted = true;
            CountryComboBox.Source = null;
            CountryComboBox.TabIndex = 13;
            CountryComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // FilterPanel
            // 
            FilterPanel.BackColor = Color.Transparent;
            FilterPanel.BackgroundImage = Properties.Resources.Gray_40;
            FilterPanel.BackgroundImageLayout = ImageLayout.Stretch;
            FilterPanel.Controls.Add(FilterCountryComboBox);
            FilterPanel.Controls.Add(FilterGenderComboBox);
            FilterPanel.Controls.Add(FilterLabel);
            FilterPanel.Dock = DockStyle.Top;
            FilterPanel.Location = new Point(0, 0);
            FilterPanel.Name = "FilterPanel";
            FilterPanel.Size = new Size(893, 61);
            FilterPanel.TabIndex = 14;
            // 
            // FilterCountryComboBox
            // 
            FilterCountryComboBox.BackColor = Color.Transparent;
            FilterCountryComboBox.ComboBoxLeftMargin = 1;
            FilterCountryComboBox.ComboBoxText = "";
            FilterCountryComboBox.ComoboBoxFont = null;
            FilterCountryComboBox.Editable = true;
            FilterCountryComboBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FilterCountryComboBox.HideLabel = false;
            FilterCountryComboBox.LabelBottomMargin = 0;
            FilterCountryComboBox.LabelColor = Color.LemonChiffon;
            FilterCountryComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FilterCountryComboBox.LabelText = "Country:";
            FilterCountryComboBox.LabelTopMargin = 0;
            FilterCountryComboBox.LabelWidth = 100;
            FilterCountryComboBox.List = null;
            FilterCountryComboBox.Location = new Point(539, 17);
            FilterCountryComboBox.Name = "FilterCountryComboBox";
            FilterCountryComboBox.SelectedIndex = -1;
            FilterCountryComboBox.SelectedIndexListener = null;
            FilterCountryComboBox.Size = new Size(313, 28);
            FilterCountryComboBox.Sorted = true;
            FilterCountryComboBox.Source = null;
            FilterCountryComboBox.TabIndex = 14;
            FilterCountryComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // FilterGenderComboBox
            // 
            FilterGenderComboBox.BackColor = Color.Transparent;
            FilterGenderComboBox.ComboBoxLeftMargin = 1;
            FilterGenderComboBox.ComboBoxText = "";
            FilterGenderComboBox.ComoboBoxFont = null;
            FilterGenderComboBox.Editable = true;
            FilterGenderComboBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FilterGenderComboBox.HideLabel = false;
            FilterGenderComboBox.LabelBottomMargin = 0;
            FilterGenderComboBox.LabelColor = Color.LemonChiffon;
            FilterGenderComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FilterGenderComboBox.LabelText = "Gender:";
            FilterGenderComboBox.LabelTopMargin = 0;
            FilterGenderComboBox.LabelWidth = 100;
            FilterGenderComboBox.List = null;
            FilterGenderComboBox.Location = new Point(89, 17);
            FilterGenderComboBox.Name = "FilterGenderComboBox";
            FilterGenderComboBox.SelectedIndex = -1;
            FilterGenderComboBox.SelectedIndexListener = null;
            FilterGenderComboBox.Size = new Size(276, 28);
            FilterGenderComboBox.Sorted = true;
            FilterGenderComboBox.Source = null;
            FilterGenderComboBox.TabIndex = 13;
            FilterGenderComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // FilterLabel
            // 
            FilterLabel.ForeColor = Color.LemonChiffon;
            FilterLabel.Location = new Point(12, 8);
            FilterLabel.Name = "FilterLabel";
            FilterLabel.Size = new Size(56, 30);
            FilterLabel.TabIndex = 0;
            FilterLabel.Text = "Filter";
            // 
            // GitHubButton
            // 
            GitHubButton.BackgroundImage = Properties.Resources.GitHub;
            GitHubButton.BackgroundImageLayout = ImageLayout.Stretch;
            GitHubButton.Location = new Point(31, 566);
            GitHubButton.Name = "GitHubButton";
            GitHubButton.Size = new Size(150, 83);
            GitHubButton.TabIndex = 15;
            GitHubButton.TabStop = false;
            GitHubButton.Click += GitHubButton_Click;
            GitHubButton.MouseEnter += GitHubButton_MouseEnter;
            GitHubButton.MouseLeave += GitHubButton_MouseLeave;
            // 
            // YouTubeButton
            // 
            YouTubeButton.BackgroundImage = Properties.Resources.YouTubeBlue;
            YouTubeButton.BackgroundImageLayout = ImageLayout.Stretch;
            YouTubeButton.Location = new Point(702, 566);
            YouTubeButton.Name = "YouTubeButton";
            YouTubeButton.Size = new Size(150, 83);
            YouTubeButton.TabIndex = 16;
            YouTubeButton.TabStop = false;
            YouTubeButton.Click += YouTubeButton_Click;
            // 
            // LeaveAStarPleaseLabel
            // 
            LeaveAStarPleaseLabel.BackColor = Color.Transparent;
            LeaveAStarPleaseLabel.ForeColor = Color.LemonChiffon;
            LeaveAStarPleaseLabel.Location = new Point(18, 533);
            LeaveAStarPleaseLabel.Name = "LeaveAStarPleaseLabel";
            LeaveAStarPleaseLabel.Size = new Size(177, 30);
            LeaveAStarPleaseLabel.TabIndex = 17;
            LeaveAStarPleaseLabel.Text = "Leave a star please!";
            LeaveAStarPleaseLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SubscribeLabel
            // 
            SubscribeLabel.BackColor = Color.Transparent;
            SubscribeLabel.ForeColor = Color.LemonChiffon;
            SubscribeLabel.Location = new Point(696, 536);
            SubscribeLabel.Name = "SubscribeLabel";
            SubscribeLabel.Size = new Size(163, 30);
            SubscribeLabel.TabIndex = 18;
            SubscribeLabel.Text = "Subscribe Please!";
            SubscribeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StopButton
            // 
            StopButton.BackColor = Color.Transparent;
            StopButton.ButtonText = "Stop";
            StopButton.FlatStyle = FlatStyle.Flat;
            StopButton.ForeColor = Color.LemonChiffon;
            StopButton.Location = new Point(540, 580);
            StopButton.Margin = new Padding(5);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(127, 55);
            StopButton.TabIndex = 19;
            StopButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            StopButton.Click += StopButton_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BlackImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(893, 709);
            Controls.Add(StopButton);
            Controls.Add(SubscribeLabel);
            Controls.Add(LeaveAStarPleaseLabel);
            Controls.Add(YouTubeButton);
            Controls.Add(GitHubButton);
            Controls.Add(FilterPanel);
            Controls.Add(CountryComboBox);
            Controls.Add(GenderComboBox);
            Controls.Add(FullNameControl);
            Controls.Add(AppendVoiceNameCheckBox);
            Controls.Add(TryVoicesButton);
            Controls.Add(HiddenButton);
            Controls.Add(OutputFolderControl);
            Controls.Add(OutputFileControl);
            Controls.Add(WriteVoicesButton);
            Controls.Add(VoiceComboBox);
            Controls.Add(StatusLabel);
            Controls.Add(SpeakButton);
            Controls.Add(GetVoicesButton);
            Controls.Add(TextToSpeakTextBox);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simon 1.0.3";
            FilterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GitHubButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)YouTubeButton).EndInit();
            ResumeLayout(false);
        }
        #endregion

        #endregion

        private DataJuggler.Win.Controls.Button HiddenButton;
        private System.Windows.Forms.Timer VoicesTimer;
        private DataJuggler.Win.Controls.Button TryVoicesButton;
        private DataJuggler.Win.Controls.LabelCheckBoxControl AppendVoiceNameCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl FullNameControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl GenderComboBox;
        private DataJuggler.Win.Controls.LabelComboBoxControl CountryComboBox;
        private DataJuggler.Win.Controls.Objects.PanelExtender FilterPanel;
        private DataJuggler.Win.Controls.LabelComboBoxControl FilterCountryComboBox;
        private DataJuggler.Win.Controls.LabelComboBoxControl FilterGenderComboBox;
        private Label FilterLabel;
        private PictureBox GitHubButton;
        private PictureBox YouTubeButton;
        private Label LeaveAStarPleaseLabel;
        private Label SubscribeLabel;
        private DataJuggler.Win.Controls.Button StopButton;
    }
    #endregion

}
