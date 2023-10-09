Simon is a WinForms (desktop) application to create audio files using
Microsoft.CognitiveServices.Speech API. Microsoft gives you half a million 
spoken characters for free per month. This is probably roughly 10 - 15 hours of audio
per month.

Simon comes with 74 English voices. There are other languages, but I only speak 
English, so this is all I imported. When I first wrote this app, I saved the voices in
SQL Server, however I figured most people are not SQL Server developers, so I switched
to a text file in the Voices folder called Voices.txt. This file is loaded at startup.

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

Download and install Simon from 

    
 
   