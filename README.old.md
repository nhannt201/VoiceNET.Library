# VoiceNET Library

[![Nuget](https://img.shields.io/nuget/v/VoiceNET.Library?label=NuGet&logo=nuget)](https://www.nuget.org/packages/VoiceNET.Library/)
[![NuGet](https://img.shields.io/nuget/dt/VoiceNET.Library.svg)](https://www.nuget.org/packages/VoiceNET.Library)

## Free Voice Command Control Library
## Introduce
**VoiceNET Library** makes it easy and fast to create Voice Command Control functionality through Label Prediction. It helps develop software or web voice control in real-time. It free supports online and offline use. This is a community development project to help people access voice recognition technology more easily.

It's a research project from the FPT Edu Research Festival 2021 contest.

<div align="center">

![](https://i.imgur.com/9FTHK3r.png)

***VoiceNET Library***

</div>

## How its work?
Using ML.NET and Spectrogram libraries, the **VoiceNET library** works by converting your voice into a spectrogram. From there, proceed to use the Image Classification function in the ML.NET library to mark the label.

<div align="center">

![](https://i.imgur.com/5VH73ri.png)

How the VoiceNET Library works

</div>

## Features

- Voice Command Control in real time.
- Voice Command Control based on recording.

## Advantage
- Easily integrate the library into your program.
- The code has been simple for every to use.
- It can be used both online and offline.
- It can be used for any communication language in the world.
- It's free.
## Disadvantage
- It takes a long time to create a Model for the library
- The time it takes to load the model into the program can be slow.
- There's still an error rate when labeling recognition.

## Installation

Once you have an app, you can install the VoiceNET Library NuGet package from the .NET Core CLI using:
```
dotnet add package VoiceNET.Library
```
or from the NuGet Package Manager:
```
Install-Package VoiceNET.Library
```
## Quickstart
### WinForm Real-time (This is full customization functionality, can use QuickStart in version 1.0.5.2) ###


#### Example ####

<div align="center">

![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__Demo_Product__Libum.gif)

***A real-time voice-controlled image gallery***

</div>

### How to make a demo in real-time? ###

Drag and drop into the Windows Forms interface:
- **Picturebox:** pbSpectrogram and picTake with Width=400
- **Combobox:** cbDevice
- **Label:** lbResult
- **Timer:** tmLisener (Interval 100, Enabled=True) and tmDisposeRam (Interval 1, Enabled=True)

In Form_Load
```cs

 VBuilder.getDevice(cbDevice);
 
 VBuilder.setVolume(80);
 
 VBuilder.ModelPath("<your_model_path>");
 
 if(VBuilder.loadModel())
 
    //do something after Load Model
	
 else
 
   //do something if fail
   
```
cbDevice_SelectedIndexChanged
```cs
StartListening();
```
Create two private void: StartListening() and DisposeImage().
 
StartListening()
```cs

DisposeImage();

VBuilder.StartListening( cbDevice );

```
DisposeImage()
```cs

pbSpectrogram.Image?.Dispose();

pbSpectrogram.Image = null;

```
tmDisposeRam_Tick
```cs

DisposeImage();

pbSpectrogram.Image = VBuilder.ListenTimer(pbSpectrogram.Width);

```
tmLisener_Tick
```cs

  if(VBuilder.requestDisposeListening)
  
            {
			
                picTake.Image = VBuilder.getImageTaken(pbSpectrogram);

                lbResult.Text = VBuilder.Result();

                StartListening(); //Renew Lisener

                VBuilder.requestDisposeListening = false;
				
            }
			
			else
			
            {
			
                VBuilder.reduceNoiseAndCapture(pbSpectrogram);
				
            }

```
### WinForm Recording ###
#### Example ####

<div align="center">

![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__Demo_Product__Recording.gif)

***Example of command label recognition by recording***

</div>

### How to make a demo in recording? ###

Drag and drop into the Windows Forms interface:
- **Button**: btnRecord, btnStop
- **Label**: lbResult

Form_Load
```cs

VBuilder.ModelPath("<your_model_path>");

 if(VBuilder.loadModel())
 
    //do something after Load Model
	
 else
 
   //do something if fail
   
```
btnRecord_Click
```cs

VBuilder.StartRecord();

btnStop.Enabled = true;

btnRecord.Enabled = false;

```
btnStop
```cs

VBuilder.StopRecord();

lbResult.Text = VBuilder.Result(true);

btnRecord.Enabled = true;

btnStop.Enabled = false;

```

### WPF Real-time - Support from v1.0.5

See the example in [VoiceNET.Lib.WPF.Realtime](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Realtime) for more how to use it.

### WPF Recording - Support from v1.0.5

See the example in [VoiceNET.Lib.WPF.Record](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Record) for more how to use it.

### Web ASP.NET MVC - Support from v1.0.2.4

See the example in [VoiceNET.Lib.Web.AspNet](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet) for more how to use it.

## How to create a Model?
Use the included [MicBuilder](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.MicBuilder/README.MD) program to build an MLModel.zip file for your Dataset.


<div align="center">

![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__MicBuilder__Create_a_Model.gif)

***MicBuilder Model Builder***

</div>

## Resources
* [FftSharp](https://www.nuget.org/packages/FftSharp/)
* [Microsoft.ML](https://www.nuget.org/packages/Microsoft.ML/)
* [Microsoft.ML.ImageAnalytics](https://www.nuget.org/packages/Microsoft.ML.ImageAnalytics/)
* [Microsoft.ML.Vision](https://www.nuget.org/packages/Microsoft.ML.Vision/)
* [NAudio](https://www.nuget.org/packages/NAudio/)
* [SciSharp.TensorFlow.Redist](https://www.nuget.org/packages/SciSharp.TensorFlow.Redist/)
## LICENSE
**MIT LICENSE**
* [Spectrogram](https://github.com/swharden/Spectrogram/) - is a .NET library for creating spectrograms from pre-recorded signals or live audio from the sound card.
* [ML.NET](https://github.com/dotnet/machinelearning) - is a cross-platform open-source machine learning (ML) framework for .NET.
* [VoiceNET Library](https://github.com/nhannt201/VoiceNET.Library/blob/main/LICENSE) - is a .NET Library makes it easy and fast to create Voice Command Control functionality.


