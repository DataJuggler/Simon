<img src =https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/Lips.png width=256 height=256>

Simon is a WinForms (desktop) application to create audio files using
Microsoft.CognitiveServices.Speech API. Microsoft gives you half a million 
spoken characters for free per month. This is probably roughly 10 - 15 hours of audio
per month.

Simon comes with 74 English voices. There are other languages, but I only speak 
English, so this is all I imported. When I first wrote this app, I saved the voices in
SQL Server, however I figured most people are not SQL Server developers, so I switched
to a text file in the Voices folder called Voices.txt. This file is loaded at startup.

# Installation Instructions

To use this app you will need to follow these setup instructions.

1. If you don't already have one, create a free Microsoft Azure account at
    https://azure.microsoft.com/ . You will need to sign in with a Microsoft Account.
2. Once you have an Azure account, visit portal.azure.com, and click on All Services.
3. Next, in the search box type in Speech Services.
4. You will need to create a resource for your account, and set the pricing tier. I set mine
    to the free tier, but if you need more than half a million characters per month, select
   Standard tier. You will also need to select a region. I am in Texas, so I chose central us,
   but you can select a region that is closest to you.
5. Once your Resource group is created, and your speech service is created, click on
    Manage Keys. You will be shown two keys, and your region. Save your two keys somewhere, 
    as you will need one in the next step. Also save your region.
6. Next, you need to create two Environment Variables for Windows. To create Environment
    variables, in Windows task bar type in 'Edit The System Enivornment Variables'. Before
    you finish typing Edit the System, you should be shown the result. When the box pops up
    click Environment Variables.
7. In the System Environment Variables (the bottom section), click New and type in the
    Name: SpeechKey. Paste in one of your keys from step 5, then Hit 'OK'.
8. Create a second Environment Variable in the same System variables.
    Name: SpeechRegion and paste or type in the region you selected in step 5, then Hit 'OK'.

Download and install Simon from https://github.com/DataJuggler/Simon
Scroll down until you see Releases on the right. The latest release will be shown first.

Download SimonSetup.msi, and run it, or save it somewhere on your PC and run it.
Once installed, you should see an icon on your desktop that looks like a setup of lips.

# Running Simon
Double click on the icon on your desktop to start Simon.

Once Simon loads, you will need to select a voice. I pre-select Tony, as this voice sounds
pretty natural to me. In a future version I may save your last voice, but I have not created
this feature yet.

Enter the text you want to Simon to speak, and select an output folder and output file name.
When the app loads, I preselect Temp as the Output folder and Audio.wav as the Output File Name.

Click the Speak button, and you should hear the result. You will also be shown a message of the current file name.

If you have any problems, create an issue on GitHub here:
https://github.com/DataJuggler/Simon/issues

# Update 10.10.2023
I added 4 new features

1. You can now filter the voices by Gender and / or Country.
2. There is a new button called Try Voices, and all the voices will speak the text prompt based on the current filter.
3. I added a feature where you can add [VoiceName] to the Text to Speak, and [VoiceName] will be replaced
    with the name of the character speaking it.
4. I added a checkbox for Append Voice Name, and the file will be saved with the voice name.
    Example: File Name: 'Audio.wav', will be saved as 'Audio_Roger.(partial guid).wav', if Roger is the current speaker.

* A partial guid is a series of random digits to ensure a filename is unique in a folder.
Example: Audio_Wayne.92fe27c7-08b.wav



    
 
   
