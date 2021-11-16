## Introduce
**VoiceNET Library** makes it easy and fast to create Voice Command Control functionality through Label Prediction. It helps develop software voice control in real-time. It free supports online and offline use. This is a community development project to help people access voice recognition technology more easily.
 
It's a research project from the FPT Edu Research Festival 2021 contest. 

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
### WinForm Real-time ###
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

### WPF Real-time ###

See the example in [VoiceNET.Lib.WPF.Realtime](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Realtime) for more how to use it.

### WPF Recording ###

See the example in [VoiceNET.Lib.WPF.Record](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Record) for more how to use it.

### Web ASP.NET MVC ###

See the example in [VoiceNET.Lib.Web.AspNet](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet) for more how to use it.

## How to create a Model?
Use the included [MicBuilder](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.MicBuilder/README.MD) program to build an MLModel.zip file for your Dataset.
