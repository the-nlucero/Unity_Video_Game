# About Build Report Inspector


Build Report Inspector is an Editor script which implements an inspector for the BuildReport class added in Unity 18.1.  
The BuildReport class lets you access information about your last build, and helps you profile the time spent building your project and the builds disk size footprint. This information may help you improving your build times and build sizes.  
This script allows you to inspect this information graphically in the Editor UI, making it more easily accessible than the script APIs would.

## Preview package
This package is available as a preview, so it is not ready for production use. The features and documentation in this package might change before it is verified for release.

We plan to add a built-in and supported UI for the BuildReport feature in a future version of Unity, but until then, this package serves as a demonstration on how you can access the BuildReport information today.

In particular, this package gets the information it can from the BuildReport Scripting API (https://docs.unity3d.com/ScriptReference/Build.Reporting.BuildReport.html), but some information in the BuildReport object is not yet exposed through public APIs.  
This package uses the SerializedObject class to access some of those internals through Unity's serialization system. Since internal data structures are subject to change, this package may stop working in future versions of Unity.


## Package contents

The following table describes the package folder structure:

|**Location**|**Description**|
|---|---|
|*Editor/BuildReportInspector*|Contains the script implementing the inspector.|
|*Editor/BuildReportInspector/BuildReportInspector.cs*|Contains implementation for the inspector.|

<a name="Installation"></a>

## Installation

To install this package, follow the instructions in the [Package Manager documentation](https://docs.unity3d.com/Manual/upm-ui-install.html).

You can obtain a BuildReport object as the return value of the BuildPlayer API (https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildPlayer.html) when making a build, or by selecting a file containing BuildReport data.  
Unity's default build setup will write such a file to **Library/LastBuild.buildreport** (this may change in the future) when making a build.  
This script adds a convenient menu shortcut (_Window/Open Last Build Report_), to copy that file to the **Assets** folder and select it, so you can inspect it using the Build Report Inspector.

Once open in the inspector, you can chose what data to view using the popup menu at the top of the window. The Build Report Inspector can show the following data:



## Requirements

This version of Build Report Inspector is compatible with the following versions of the Unity Editor:

* 2018.1 and later (recommended)

---

<a name="UsingBuildReportInspector"></a>

# Using Build Report Inspector

In UnityEditor, select a BuildReport object created after a project build.

You can obtain a BuildReport object as the return value of the BuildPlayer API (https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildPlayer.html) when making a build, or by selecting a file containing BuildReport data.  
Unity's default build setup will write such a file to **Library/LastBuild.buildreport** (this may change in the future) when making a build.  
This script adds a convenient menu shortcut (_Window/Open Last Build Report_), to copy that file to the **Assets** folder and select it, so you can inspect it using the Build Report Inspector.

Once open in the inspector, you can chose what data to view using the popup menu at the top of the window. The Build Report Inspector can show the following data:


<a name="BuildSteps"></a>
### Build steps
The different steps involved in making you build, how long they took, and what messages were printed during those steps (if any).  

<img src="images/BuildSteps.png" width="600">

<a name="SourceAssets"></a>
### Source assets
A list of all assets which are used in the build, and how much they contribute to your build size  

![SourceAssets](images/SourceAssets.png)

<a name="OutputFiles"></a>
### Output files
A list of all files written by the build  

![OutputFiles](images/OutputFiles.png)

<a name="Stripping"></a>
### Stripping
For platforms which support engine code stripping, a list of all engine modules added to the build, and what caused them to be included in the build.  

![Stripping](images/Stripping.png)

<a name="ScenesUsingAssets"></a>
### Scenes using Assets
[Available from Unity 2020.1.0a6]  
When BuildOption.DetailedBuildReport is passed to [BuildPipeline.BuildPlayer](https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildPlayer.html), a list describing which scenes are using each asset of the build, is provided in the BuildReport.

<img src="images/ScenesUsingAssets.png" width="400">

---

# Contributing

The source for Build Report Inspector package is available at https://github.com/Unity-Technologies/BuildReportInspector  
For contributions, please refer to the repository's [CONTRIBUTING.md](https://github.com/Unity-Technologies/BuildReportInspector/blob/master/com.unity.build-report-inspector/CONTRIBUTING.md) file.
