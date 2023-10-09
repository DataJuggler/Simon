

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TextToSpeakTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            GetVoicesButton = new DataJuggler.Win.Controls.Button();
            SpeakButton = new DataJuggler.Win.Controls.Button();
            StatusLabel = new Label();
            VoiceComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            WriteVoicesButton = new DataJuggler.Win.Controls.Button();
            OutputFileControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            OutputFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
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
            TextToSpeakTextBox.Location = new Point(31, 86);
            TextToSpeakTextBox.MultiLine = true;
            TextToSpeakTextBox.Name = "TextToSpeakTextBox";
            TextToSpeakTextBox.OnTextChangedListener = null;
            TextToSpeakTextBox.PasswordMode = false;
            TextToSpeakTextBox.ScrollBars = ScrollBars.None;
            TextToSpeakTextBox.Size = new Size(686, 264);
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
            GetVoicesButton.Location = new Point(31, 551);
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
            SpeakButton.Location = new Point(542, 465);
            SpeakButton.Margin = new Padding(5);
            SpeakButton.Name = "SpeakButton";
            SpeakButton.Size = new Size(175, 55);
            SpeakButton.TabIndex = 2;
            SpeakButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            SpeakButton.Click += SpeakButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Dock = DockStyle.Bottom;
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(0, 624);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(800, 33);
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
            VoiceComboBox.Location = new Point(31, 41);
            VoiceComboBox.Name = "VoiceComboBox";
            VoiceComboBox.SelectedIndex = -1;
            VoiceComboBox.SelectedIndexListener = null;
            VoiceComboBox.Size = new Size(686, 28);
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
            WriteVoicesButton.Location = new Point(274, 551);
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
            OutputFileControl.Location = new Point(31, 416);
            OutputFileControl.MultiLine = false;
            OutputFileControl.Name = "OutputFileControl";
            OutputFileControl.OnTextChangedListener = null;
            OutputFileControl.PasswordMode = false;
            OutputFileControl.ScrollBars = ScrollBars.None;
            OutputFileControl.Size = new Size(686, 32);
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
            OutputFolderControl.Location = new Point(31, 367);
            OutputFolderControl.Name = "OutputFolderControl";
            OutputFolderControl.OnTextChangedListener = null;
            OutputFolderControl.OpenCallback = null;
            OutputFolderControl.ScrollBars = ScrollBars.None;
            OutputFolderControl.SelectedPath = null;
            OutputFolderControl.Size = new Size(686, 32);
            OutputFolderControl.StartPath = null;
            OutputFolderControl.TabIndex = 7;
            OutputFolderControl.TextBoxBottomMargin = 0;
            OutputFolderControl.TextBoxDisabledColor = Color.Empty;
            OutputFolderControl.TextBoxEditableColor = Color.Empty;
            OutputFolderControl.TextBoxFont = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OutputFolderControl.TextBoxTopMargin = 0;
            OutputFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BlackImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 657);
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
            Text = "Simon";
            ResumeLayout(false);
        }
        #endregion

        #endregion

    }
    #endregion

}
