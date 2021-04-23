# WolvenKit-Renderer

## Overview for coders

### Solution
A number of iterations have resulted in the current version of the renderer. The active version is WKEngine4 which is launched using ConsoleTestHarness4.  The WPFTestHarness is also configured to use version 4 but is not fully functional.  The other versions are the result of migrating the original Vulkan example project into the desired framework and testing different architectures.  I was really hoping that version 3 would be fast enough with the conditional rendering but it seems that the entire scene is still processed on the gpu except for the final draw so hiding parts of the scene doesn't improve the framerate.  It would be fine for single meshes but that might just make things too complicated for little gain.

### Integration
The api for the render library is simple.
* Set the path to the game assets (SetWitcherExePath)
* Load the asset (LoadAsset).  This is a path relative to the bundle such as *levels\\island_of_mist\\island_of_mist.w2w*.  W2W, W2L, and W2MESH files are supported.
* Run the engine (WKRun).  The module instance and window handle are the used to connect with an existings Windows app.  The last 2 parameters are the dimensions.
* FBX files can be added to the scene using the (ImportAsset) function.  Limited functionality but works for some geometry.
* Multiple search paths are planned to be supported so that additional game assets can be viewed.  The plan is for this call to add another path to a list.  The paths in the list would be searched for the asset to loaded and would move to the next item in the list if not found.  The final path to be checked would be the primary game path.  This is not implemented but the stack of paths exists.

### Architecture
The code is C++ and uses the Vulkan API.  The overall setup is based on a combination of [Vulkan Guide](https://vkguide.dev/docs/gpudriven/code_architecture/) and [Vulkan example](https://github.com/SaschaWillems/Vulkan).

#### Windows
All the Windows related code is in vk_engine_win32.  The message handler for input handling (mouse, keyboard), window resizing, closing etc. is all in here.  If you are integrating into the main WolvenKit app, you will likely need to poke around here to get the instance and Window handle issue working.

#### Runtime files
CreateTableOfContentsFromBundles in the bundledictionary.cpp file can be used to generate the **rawpathhashes.bin** file.  This file is our table of contents for every asset in the game.  The 

#### Game Bundles
The Witcher bundles are parsed with the code in the cr2w folder.  Each content and patch folder in the game path was loaded in order to generate a 