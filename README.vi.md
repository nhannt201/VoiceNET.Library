# VoiceNET Library

[![Nuget](https://img.shields.io/nuget/v/VoiceNET.Library?label=NuGet&logo=nuget)](https://www.nuget.org/packages/VoiceNET.Library/)
## Thư viện điều khiển lệnh bằng giọng nói miễn phí
## Giới thiệu
**VoiceNET Library** giúp bạn dễ dàng và nhanh chóng tạo chức năng Điều khiển lệnh bằng giọng nói thông qua Dự đoán nhãn. Nó giúp phát triển phần mềm điều khiển bằng giọng nói trong thời gian thực. Nó miễn phí hỗ trợ sử dụng trực tuyến và ngoại tuyến. Đây là dự án phát triển cộng đồng nhằm giúp mọi người tiếp cận công nghệ nhận dạng giọng nói dễ dàng hơn.

Đây là một dự án nghiên cứu từ cuộc thi FPT Edu Research Festival 2021.

<div align="center">

![](https://i.imgur.com/9FTHK3r.png)

***VoiceNET Library***

</div>

## Nó hoạt động thế nào?

Sử dụng các thư viện ML.NET và Spectrogram, **VoiceNET library** hoạt động bằng cách chuyển giọng nói của bạn thành một biểu đồ quang phổ. Từ đó, tiến hành sử dụng chức năng Phân loại ảnh trong thư viện ML.NET để đánh dấu nhãn.

<div align="center">

![](https://i.imgur.com/5VH73ri.png)

Cách hoạt động của Thư viện VoiceNET

</div>

## Tính năng

- Điều khiển lệnh bằng giọng nói trong thời gian thực.
- Điều khiển lệnh bằng giọng nói dựa trên bản ghi âm.

## Ưu điểm
- Dễ dàng tích hợp thư viện vào chương trình của bạn.
- Mã rất đơn giản cho mọi người sử dụng.
- Nó có thể được sử dụng cả trực tuyến và ngoại tuyến.
- Nó có thể được sử dụng cho bất kỳ ngôn ngữ giao tiếp nào trên thế giới.
- Nó miễn phí.
## Nhược điểm
- Mất nhiều thời gian để tạo Model cho thư viện.
- Thời gian tải mô hình vào chương trình có thể chậm.
- Vẫn có tỷ lệ lỗi khi nhận dạng nhãn.

## Cài đặt

Sau khi có ứng dụng, bạn có thể cài đặt gói VoiceNET Library NuGet từ .NET Core CLI bằng cách sử dụng:
```
dotnet add package VoiceNET.Library
```
hoặc từ NuGet Package Manager:
```
Install-Package VoiceNET.Library
```
## Bắt đầu nhanh
### Sử dụng trong thời gian thực trên WinForm ###


#### Ví dụ ####

<div align="center">

![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__Demo_Product__Libum.gif)

***Thư viện hình ảnh được điều khiển bằng giọng nói trong thời gian thực***

</div>

### Làm thế nào để tạo bản demo trong thời gian thực? ###

Kéo và thả vào giao diện Windows Forms:
- **Label:** lbResult
- **Timer:** tmGetResult (Interval=1)

Trong Form_Load
```cs
VBuilder.ModelPath("<your_model_path>");

if (VBuilder.loadModel())
    
{
	tmGetResult.Start();
	VSpeech.WFListener();
            
}
```

Trong tmGetResult
```cs
lbResult.Text = VSpeech.WFGetResult;
```
### Dựa trên bản ghi âm trên WinForm ###
#### Ví dụ ####

<div align="center">

![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__Demo_Product__Recording.gif)

***Ví dụ về nhận dạng nhãn lệnh bằng cách ghi âm***

</div>

### Làm thế nào để thực hiện một bản demo trong ghi âm? ###

Kéo và thả vào giao diện Windows Forms:
- **Button**: btnRecord, btnStop
- **Label**: lbResult

Trong Form_Load
```cs

VBuilder.ModelPath("<your_model_path>");

 if(VBuilder.loadModel())
 
    //làm gì đó khi đã Load Model thành công
	
 else
 
   //làm gì đó nếu load model thất bại
   
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

Kéo thả vào giao diện WPF Application:

- **Label**: lbResult

Trước MainWindow()

```cs

public DispatcherTimer tmGetResult = new DispatcherTimer();

```

Trong MainWindow()
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

Trong void tmGetResult_Tick
```cs

lbResult.Content = VSpeech.WPFGetResult;

```

### WPF Recording ###

Xem thêm ví dụ [VoiceNET.Lib.WPF.Record](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.WPF.Record) để biết cách sử dụng trên WPF.

### Web ASP.NET MVC

Xem thêm ví dụ [VoiceNET.Lib.Web.AspNet](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet) để biết cách sử dụng trên ASP.NET MVC.

## Làm thế nào để tạo một Model?
Dùng phần mềm [MicBuilder](https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.MicBuilder/README.MD) để xây dựng tệp MLModel.zip cho tập dữ liệu của bạn.


<div align="center">

![](https://raw.githubusercontent.com/nhannt201/VoiceNET.Library/gh-pages/VoiceNET_Library__MicBuilder__Create_a_Model.gif)

***MicBuilder Model Builder***

</div>

## Tài nguyên
* [FftSharp](https://www.nuget.org/packages/FftSharp/)
* [Microsoft.ML](https://www.nuget.org/packages/Microsoft.ML/)
* [Microsoft.ML.ImageAnalytics](https://www.nuget.org/packages/Microsoft.ML.ImageAnalytics/)
* [Microsoft.ML.Vision](https://www.nuget.org/packages/Microsoft.ML.Vision/)
* [NAudio](https://www.nuget.org/packages/NAudio/)
* [SciSharp.TensorFlow.Redist](https://www.nuget.org/packages/SciSharp.TensorFlow.Redist/)
## Giấy phép
**MIT LICENSE**
* [Spectrogram](https://github.com/swharden/Spectrogram/) - is a .NET library for creating spectrograms from pre-recorded signals or live audio from the sound card.
* [ML.NET](https://github.com/dotnet/machinelearning) - is a cross-platform open-source machine learning (ML) framework for .NET.
* [VoiceNET Library](https://github.com/nhannt201/VoiceNET.Library/blob/main/LICENSE) - is a .NET Library makes it easy and fast to create Voice Command Control functionality.


