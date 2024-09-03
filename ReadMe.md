<img src =https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/Lips.png width=256 height=256>

Simon is a WinForms (desktop) application to create audio files using
Microsoft.CognitiveServices.Speech API. Microsoft gives you half a million 
spoken characters for free per month. This is probably roughly 10 - 15 hours of audio
per month.

# Updates
# 3.29.2024: Version 1.6.0
Simon has been updated to .NET 8, and new voices have been added, bringing the total to 84.

# 12.7.2023: Version 1.5 New Feature - Rate
You can now select extra slow, slow, medium, default, fast or extra fast. As far as I can tell, Medium and Default are the same.
You can also write [RateName], if you want to type 'I am speaking at the [RateName] rate. [RateName] will be
replaced with a text friendly version of the rate. I didn't use the default values of x-slow, slow, fast or x-fast, instead
I replace slow with "-10%", and replace extra slow with "-20%". The same is true for fast is "+10%", and x-fast is
"+20%". The Microsoft options of x-slow and slow were too slow, and the fast and x-fast options were too fast.

# 12.5.2023: Version 1.4 New Feature - Pitch
You can now select extra low, low, medium, default, high or extra high. As far as I can tell, Medium and Default are the same.
You can also write [PitchName], if you want to type 'I am speaking in a [PitchName] pitch. [PitchName] will be
replaced with a text friendly version of the pitch.

# 11.10.2023: Version 1.2 New Feature - Pause
You can now now add pauses to your text, by adding this to your script.

Example: The top story tonight is, [Pause3] Trump becomes the first President since Grover Cleveland in 1893 to
win a Presidential election after being voted out of office.

# 11.4.2023: New Video

In this video I show how to setup Simon, and show a 7 minute picture story narrated by one of Simon's female voices, Cara.
https://youtu.be/T_muhqFGEPQ?si=KHrQQNG7mXCYTfFM

# 10.22.2023 Important note about Upgrading
For now you must uninstall the previous version to install a new version.
I am working on making Upgrades available, and giving the app a way to notify you
when a new release is available.

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
9. When you run Simon, an output folder of c:\Temp will be selected by default. Either make
    sure this folder exists, or you may select another directory. If you check the 'Make Default'
    check box, this folder will be selected the next time your run Simon.
    

Download and install Simon from https://github.com/DataJuggler/Simon
Scroll down until you see Releases on the right. Once on the releases tab, scroll down until you see the Simon.msi. The latest release will be shown first.

Download Simon.msi, and run it, or save it somewhere on your PC and run it.
Once installed, you should see an icon on your desktop that looks like a set of lips.

# Running Simon
Double click on the icon on your desktop to start Simon.

Once Simon loads, you will need to select a voice. You can filter the voices by Gender and Country. Simon will save your last voice selected the next time you run it.

Enter the text you want to Simon to speak, and select an output folder and output file name.

Click the Speak button, and you should hear the result. You will also be shown a message of the current file name.

This video is an example of the Poetry Reading emotion.

A Halloween Love Poem
https://youtu.be/KFtBqTzw4c8

If you have any problems, create an issue on GitHub here:
https://github.com/DataJuggler/Simon/issues

# Update 10.30.2023 Version 1.1.0
Simon now has emotions you can choose! I will warn you not all voices work with all emotions, but this is a big improvement.
A few of my favorite emotions are Advertising Upbeat, Excited, Terrified and Whispering.

The emotions include a Degree textbox, and the values must be between .01 and 2.0. The value of .01 has almost no effect, and
the 2.0 will strongly emphasize the emotion.

# Update 10.22.2023 Version 1.0.5
This release was all about validation, and showing the right message for the problem.

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



    
 
   
