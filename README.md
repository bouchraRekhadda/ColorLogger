This repository is intended to reproduce NullReferenceException using MSBuild 17 (17.1.0) with a custom Logger while using Maximum CPU count (`/m`).
Build the solution using MSBuild 17 from your Visual Studio 2022 install

`"C:\Program Files\Microsoft Visual Studio\2022\Professional\Msbuild\Current\Bin\msbuild.exe" /m /v:m /t:Build /noconsolelogger /logger:bin\Debug\net48\ColorLogger.dll`

### Expected behavior

>Microsoft (R) Build Engine version 17.1.0+ae57d105c for .NET Framework
<br>Copyright (C) Microsoft Corporation. All rights reserved.
<br>ColorLogger -> C:\Users\bouchraREKHADDA\source\repos\ColorLogger\bin\Debug\net48\ColorLogger.dll
<br>Full log available in C:\Users\bouchraREKHADDA\AppData\Local\Temp\ColorLogger\msbuild_20220404-112128.log

### Actual behavior
>MSBUILD : error MSB4017: The build stopped unexpectedly because of an unexpected logger failure.
<br>Microsoft.Build.Exceptions.InternalLoggerException: The build stopped unexpectedly because of an unexpected logger failure. --->  System.NullReferenceException: Object reference not set to an instance of an object.
<br>   at Microsoft.Build.BackEnd.Logging.ParallelConsoleLogger.WriteMessageAligned(String message, Boolean prefixAlreadyWritten, Int32 prefixAdjustment)
<br>   at Microsoft.Build.BackEnd.Logging.ParallelConsoleLogger.PrintTargetNamePerMessage(BuildMessageEventArgs e, Boolean lightenText)
<br>   at Microsoft.Build.BackEnd.Logging.ParallelConsoleLogger.PrintMessage(BuildMessageEventArgs e, Boolean lightenText)
<br>   at Microsoft.Build.BackEnd.Logging.ParallelConsoleLogger.MessageHandler(Object sender, BuildMessageEventArgs e)
<br>   at Microsoft.Build.Logging.ConsoleLogger.MessageHandler(Object sender, BuildMessageEventArgs e)
<br>   at ColorLogger.ColorLogger.MessageHandler(Object sender, BuildMessageEventArgs e) in C:\Users\bouchraREKHADDA\source\repos\ColorLogger\ColorLogger.cs:line 140
<br>   at Microsoft.Build.Evaluation.ProjectCollection.ReusableLogger.MessageRaisedHandler(Object sender, BuildMessageEventArgs e)
<br>   at Microsoft.Build.BackEnd.Logging.EventSourceSink.RaiseMessageEvent(Object sender, BuildMessageEventArgs buildEvent)
<br>   --- End of inner exception stack trace ---
<br>   at Microsoft.Build.Exceptions.InternalLoggerException.Throw(Exception innerException, BuildEventArgs e, String messageResourceName, Boolean initializationException, String[] messageArgs)
<br>   at Microsoft.Build.BackEnd.Logging.EventSourceSink.RaiseMessageEvent(Object sender, BuildMessageEventArgs buildEvent)
<br>   at Microsoft.Build.BackEnd.Logging.EventSourceSink.Consume(BuildEventArgs buildEvent)
<br>   at Microsoft.Build.BackEnd.Logging.EventSourceSink.Consume(BuildEventArgs buildEvent, Int32 sinkId)
<br>   at Microsoft.Build.BackEnd.Logging.EventRedirectorToSink.Microsoft.Build.Framework.IEventRedirector.ForwardEvent(BuildEventArgs buildEvent)
<br>   at Microsoft.Build.BackEnd.Logging.CentralForwardingLogger.EventSource_AnyEventRaised(Object sender, BuildEventArgs buildEvent)
<br>   at Microsoft.Build.BackEnd.Logging.EventSourceSink.RaiseAnyEvent(Object sender, BuildEventArgs buildEvent)