# Unity_StabilityAI_Plugin
A plugin to save images from Stability AI API to Application Persistent Path.

Create a new C# DLL project in visual studio and drop ImageGenerationApi.cs and Types.cs into the project.
Make sure to reference the dependant Unity engine DLLs in the project.

UnityEngine.dll
UnityEngine.CoreModule.dll
UnityEngine.JSONSerializeModule.dll
UnityEngine.UnityWebRequestModule.dll

See apiKey in ImageGeneration.cs, add your stability AI key to the script.

BUild and drag the DLL into your Unity project.
