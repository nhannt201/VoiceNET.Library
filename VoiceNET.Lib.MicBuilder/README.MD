# VoiceNET Library
## MicBuilder Model Generator
### Vietnamese video tutorial ###
<div align="center">

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/4YJ2BpDv_FI/0.jpg)](https://www.youtube.com/watch?v=4YJ2BpDv_FI)

MicBuilder Video Tutorial

</div>

## Introduce
This is a tool to help create a Model file for the ***VoiceNET library***
## Guide
### Step 1 - Settings
- Open ***MicBuilder*** Software
- Click ***"Settings"*** to select your dataset folder, create a new one if you don't have one.

Ambient noise reduction setting

- ***Min Value***: Adjust the minimum volume level to perform capturing. Input sound that is less than this portion will be considered noise.
- ***Continuous***: How long does the sound stay continuous when Sound Input > Min Volume. The default value is 250 milliseconds.

Click ***"Save & Close"***

### Step 2 - Monitor
- Click ***"Monitor"***
- Enter Label Name: Label names must be Latin alphabet characters, written  consecutively without spaces or special characters, and  have a maximum length of 255 characters.  Example: turnoffthecomputer, call119, closethewindows.

***Nota bene:*** In order to create a diverse dataset and reduce the rate of misidentification, you should say it 10 times at each microphone volume level from 10% or 20% to 90%. On the MicBuilder interface, adjust the Microphone Volume.

***Follow below table:***
![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/note.png)

- Start speaking content related to the entered label name until you see the captured image in the MicBuilder interface.  Then, click "Add Image Label". Continue doing this until you have the quantity you want. Add as much data as possible and each label should have an equal number of times.

When finished, click ***"x"*** to close the window

### Step 3 - Train Data
- Click ***"Train Data"***

Model creation will happen automatically, please wait until it's done. When the "Train Data" process ends, a window will be displayed for you to re-evaluate the Model by repeating the content you have labeled with the previous name. When the re-evaluation is still not good, continue to click "Monitor" to add data and re-train data.

### Final

The ***MLModel.zip*** file will be created inside your Dataset folder. Use it with the ***VoiceNET Library*** to build Voice Command Control for your software.
