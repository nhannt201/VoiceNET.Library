## Introduce
**VoiceNET Library** makes it easy and fast to create Voice Command Control functionality through Label Prediction.  It helps develop voice control in real-time on software or the web. It free supports online and offline use. This is a community development project to help people access voice recognition technology more easily.
 
It's a research project from the FPT Edu Research Festival 2021 contest. 
 
This is the full library, including the functions of ***VoiceNET.Lib.WebAPI*** and ***VoiceNET.Lib.ClientAPI***.

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

Use the following code if you want to stop listening
```cs
VBuilder.WFStopListener();
```

### WinForm Recording
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

```
btnStop
```cs

VBuilder.StopRecord();

lbResult.Text = VBuilder.Result(true);

```

## WPF Real-time - Support from v1.0.5

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

Use the following code if you want to stop listening
```cs
VBuilder.WPFStopListener();
```

## WPF Recording - Support from v1.0.5

See the example in [VoiceNET.Lib.WPF.Record](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Record) for more how to use it.

## ASP.NET MVC - Support from v1.0.2.4

See the example in [VoiceNET.Lib.Web.AspNet](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet) for more how to use it.

## ASP.NET Core Web API - Support from v1.0.6.8

See the example in [SampleWebAPI](https://github.com/nhannt201/VoiceNET.Library/tree/main/SampleWebAPI) for more how to use it.

It includes example ***ASP.NET Core Web API*** and **WinForm App (WinForm Realtime)** using Web API.

## How to create a Model?
Use the included [MicBuilder](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.MicBuilder/README.MD) program to build an MLModel.zip file for your Dataset.
