# Noise

This is a WPF application and was coded with C# initially for Unity3D and then adapted for C#.net due to low dependency on Unity. 
It can be compiled with .net sdk 5 using ``dotnet build`` or ``dotnet run`` in the my-app folder through the command line.

Its main use is to test the results from different noise calculations and see what kind of heightmap it can create. New noise calculations ideas are added to the available noise options so that if needed it can also be revisited later on.

---------------------------------------------------------------------------
This is one module of a series used on Unity3D to generate island meshes. Other modules adapted for C#.net can be seen in the following links:
* [Island Shape](https://github.com/brunorc93/islandShapeGen.net)  
* [Biome Growth - previous](https://github.com/brunorc93/BiomeGrowth.net)    
* [HQ2nxNoAA - next](https://github.com/brunorc93/HQnx-noAA.net)  

The following modules use Unity  
* [Generator preview - minimap](https://github.com/brunorc93/minimap)

> (more links will be added as soon as the modules are ported onto C#.net or made presentable in Unity).  

The full Unity Project can be followed [here](https://github.com/brunorc93/procgen) 

------------------------------------------------------------------------------

Running it opens a Window where you can choose which Noise to generate, click to generate it and when generated you can save it as a bitmap and view it in 3D. This can be seen below:

* Main Window (ComboBox selects generation method):

<div style="display: inline-block">
  <img style="float: left;" src="examples/SS/01.png?raw=true" width="250" alt="noise example">
</div>

* Generated Noise in Window (Save and 3D buttons appear)

<div style="display: inline-block">
  <img style="float: left;" src="examples/SS/02.png?raw=true" width="250" alt="noise example">
</div>

* Main Window and 3D showcase window

<div style="display: inline-block">
  <img style="float: left;" src="examples/SS/03.png?raw=true" width="365" alt="noise example">
</div>

* 3D object in 3D Window can be rotated using the available sliders

<div style="display: inline-block">
  <img style="float: left;" src="examples/SS/04.gif?raw=true" width="600" alt="noise example">
</div>

-------------------------------------------------------------------

The generated noise uses Open Simplex (Open Simplex code extracted from [here](https://gist.github.com/digitalshadow/134a3a02b67cecd72181)). Some of the possible results can be seen in the following images:

1. Basic Noise:
<div style="display: inline-block">
  <img style="float: left;" src="examples/000_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/001_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/002_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/003_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/030_.png?raw=true" width="100" height="100" alt="noise example">
</div>

2. Clamped Noise:
<div style="display: inline-block">
  <img style="float: left;" src="examples/004_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/005_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/006_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/007_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/029_.png?raw=true" width="100" height="100" alt="noise example">
</div>

3. Fractal Noise:
<div style="display: inline-block">
  <img style="float: left;" src="examples/008_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/009_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/010_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/011_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/028_.png?raw=true" width="100" height="100" alt="noise example">
</div>

4. Clamped Fractal Noise:
<div style="display: inline-block">
  <img style="float: left;" src="examples/012_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/014_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/013_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/015_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/027_.png?raw=true" width="100" height="100" alt="noise example">
</div>

5. Ridged Noise:
<div style="display: inline-block">
  <img style="float: left;" src="examples/016_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/017_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/018_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/019_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/025_.png?raw=true" width="100" height="100" alt="noise example">
</div>

6. Combined Noise:
<div style="display: inline-block">
  <img style="float: left;" src="examples/020_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/021_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/022_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/023_.png?raw=true" width="100" height="100" alt="noise example">
  <img style="float: left;" src="examples/024_.png?raw=true" width="100" height="100" alt="noise example">
</div>
