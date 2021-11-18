## Introduce
**VoiceNET Library** makes it easy and fast to create Voice Command Control functionality through Label Prediction. It helps develop voice control in real-time on software or the web. It free supports online and offline use. This is a community development project to help people access voice recognition technology more easily.
 
This is a research project from the FPT Edu Research Festival 2021 contest. 

<div align="center">

<img src="https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/logo.png" alt="VoiceNET Library" />
 
</div>

## How its work?

Using ML.NET and Spectrogram libraries, the **VoiceNET library** works by converting your voice into a spectrogram. From there, proceed to use the Image Classification function in the ML.NET library to mark the label.

<div align="center">


 <img src="https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/howitworks.png" alt="How the VoiceNET Library works" />


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
## WinForm Real-time


#### Example - A real-time voice-controlled image gallery

<div align="center">

<img src="https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__Demo_Product__Libum.gif" alt="A real-time voice-controlled image gallery" />

</div>

### How to make a demo in real-time?

Drag and drop into the Windows Forms interface:
- **Label:** lbResult
- **Timer:** tmGetResult (Interval=1)

In Form_Load
```cs
VBuilder.ModelPath("<your_model_path>");
if (VBuilder.loadModel())
    
{
	tmGetResult.Start();
	VBuilder.WFListener();
            
}
```

In tmGetResult
```cs
lbResult.Text = VBuilder.WFGetResult;
```

## WinForm Recording
#### Example - Example of command label recognition by recording

<div align="center">
	
<img src="https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__Demo_Product__Recording.gif" alt="Example of command label recognition by recording" />

</div>

### How to make a demo in recording?

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
VBuilder.Record();
btnStop.Enabled = true;
btnRecord.Enabled = false;
```
btnStop
```cs
VBuilder.Stop();
lbResult.Text = VBuilder.Result(true);
btnRecord.Enabled = true;
btnStop.Enabled = false;
```

## WPF Real-time

Drag and drop into the WPF Application interface:

- **Label**: lbResult

Before MainWindow()

```cs
public DispatcherTimer tmGetResult = new DispatcherTimer();
```

In MainWindow()
```cs
tmGetResult.Interval = TimeSpan.FromSeconds(1);
tmGetResult.Tick += tmGetResult_Tick;
VBuilder.ModelPath("<your_model_path>");
    if (VBuilder.loadModel())
            
	{
        tmGetResult.Start();
        VBuilder.WPFListener();
    }
	
```

In void tmGetResult_Tick
```cs
lbResult.Content = VBuilder.WPFGetResult;
```

## WPF Recording

See the example in [VoiceNET.Lib.WPF.Record](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Record) for more how to use it.

## Web ASP.NET MVC

See the example in [VoiceNET.Lib.Web.AspNet](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet) for more how to use it.
# How to create a Model?
Use the included [MicBuilder](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.MicBuilder/README.MD) program to build an MLModel.zip file for your Dataset.


<div align="center">
	
<img src="https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__MicBuilder__Create_a_Model.gif" alt="MicBuilder Model Builder" />


<br>
	<center>***MicBuilder Model Builder***</center>

</div>

# Setting

**Microphone volume adjustment**:

```cs
VBuilder.setVolume(80);
```

Ambient noise reduction setting

- ***Min Value***:  Adjust the minimum volume level to perform capturing. Input sound that is less than this portion will be considered noise. The default value is 10%.
```cs
VBuilder.setMinVolume(10); 
```
- ***Continuous***: How long does the sound stay continuous when Sound Input > Min Volume. The default value is 250 milliseconds.
```cs
VBuilder.setMicTime(250);
```

# Resources

* [FftSharp](https://www.nuget.org/packages/FftSharp/)
* [Microsoft.ML](https://www.nuget.org/packages/Microsoft.ML/)
* [Microsoft.ML.ImageAnalytics](https://www.nuget.org/packages/Microsoft.ML.ImageAnalytics/)
* [Microsoft.ML.Vision](https://www.nuget.org/packages/Microsoft.ML.Vision/)
* [NAudio](https://www.nuget.org/packages/NAudio/)
* [SciSharp.TensorFlow.Redist](https://www.nuget.org/packages/SciSharp.TensorFlow.Redist/)

# License

**MIT LICENSE**

* [Spectrogram](https://github.com/swharden/Spectrogram/) - is a .NET library for creating spectrograms from pre-recorded signals or live audio from the sound card.
* [ML.NET](https://github.com/dotnet/machinelearning) - is a cross-platform open-source machine learning (ML) framework for .NET.
* [VoiceNET Library](https://github.com/nhannt201/VoiceNET.Library/blob/main/LICENSE) - is a .NET Library makes it easy and fast to create Voice Command Control functionality.
