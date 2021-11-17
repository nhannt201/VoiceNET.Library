## Introduce
**VoiceNET Library** makes it easy and fast to create Voice Command Control functionality through Label Prediction.  It helps develop voice control in real-time on software or the web. It free supports online and offline use. This is a community development project to help people access voice recognition technology more easily.
 
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
- **Label:** lbResult
- **Timer:** tmGetResult (Interval=100)

In Form_Load
```cs
VBuilder.ModelPath("<your_model_path>");

if (VBuilder.loadModel())
    
{
	tmGetResult.Start();
	VSpeech.WFListener();
            
}
```

In tmGetResult
```cs
lbResult.Text = VSpeech.WFGetResult;
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

```
btnStop
```cs

VBuilder.Stop();

lbResult.Text = VBuilder.Result(true);

```

### WPF Real-time ###

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

        VSpeech.WPFListener();

    }
	
```

In void tmGetResult_Tick
```cs

lbResult.Content = VSpeech.WPFGetResult;

```

### WPF Recording ###

See the example in [VoiceNET.Lib.WPF.Record](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Record) for more how to use it.

### Web ASP.NET MVC ###

See the example in [VoiceNET.Lib.Web.AspNet](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet) for more how to use it.

## How to create a Model?
Use the included [MicBuilder](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.MicBuilder/README.MD) program to build an MLModel.zip file for your Dataset.
