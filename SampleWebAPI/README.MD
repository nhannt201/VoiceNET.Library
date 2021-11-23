# VoiceNET Library

## Example Web API

Example of using Web API

This is an example using VoiceNET.Library to develop a WebAPI that implements Voice Command Control in real-time. This functionality depends on VoiceNET.Lib.ClientAPI to use. See the VoiceNET.Lib.Web.AspNet example reference to see how to build an API based on audio recordings that can be used for platforms other than .NET.

## VoiceNET.Lib.Extension

This is a stripped down version of the VoiceNET Library.

VoiceNET.Lib.Extension is an extension of VoiceNET.Library that supports Web API.
 
***VoiceNET.Lib.ClientAPI***: https://www.nuget.org/packages/VoiceNET.Lib.ClientAPI/

VoiceNET.Lib.ClientAPI is a shortened version using the Web API for users, stripped of unnecessary libraries. It can also work on WPF Application.
 
***VoiceNET.Lib.WebAPI***: https://www.nuget.org/packages/VoiceNET.Lib.WebAPI/

VoiceNET.Lib.WebAPI is dedicated to Web API development.

Refer to the following sample to use the recording via Web API for platforms other than .NET.

***ASP.NET MVC Recording***: https://github.com/nhannt201/VoiceNET.Library/tree/main/VoiceNET.Lib.Web.AspNet

## How to use it?

See the example in [SampleWebAPI](https://github.com/nhannt201/VoiceNET.Library/tree/main/SampleWebAPI) for more how to use it.

It includes example ***ASP.NET Core Web API*** and **WinForm App (WinForm Realtime+Recording)** using Web API.