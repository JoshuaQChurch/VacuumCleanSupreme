# VacuumCleanSupreme
Spring 2016 Semester Project

http://videogamedev.club

#####Try out the web version of the game: http://videogamedev.club/VacuumBuild/


### Getting Started on the Project

#### 1. Download Unity 5.3.1f1.
5.3.1f1 is the version being used for this project. Get it with these links.
 
- [Unity for Mac](https://unity3d.com/get-unity/download?thank-you=update&download_nid=24110&os=Mac)
 
- [Unity for Windows](https://unity3d.com/get-unity/download?thank-you=update&download_nid=24110&os=Win)

#### 2. Read or watch some Unity tutorials.

Unity can take a while to download, so pass the time by getting down the basics.

- [Getting Started with Unity](http://docs.unity3d.com/Manual/GettingStarted.html)

- [Introduction to Unity's UI](https://unity3d.com/learn/tutorials/topics/interface-essentials)

- [Scripting in C#](https://unity3d.com/learn/tutorials/topics/scripting)

- [More Unity Tutorials](https://unity3d.com/learn/tutorials)

#### 3. Familiarize yourself with the documentation and project standards.

- Project Documentation: 
  - [Mockup Object Model Diagram](http://videogamedev.club/?page=GamePlans)
- Project standards and programming conventions can be found at the end of this document.

#### 4. Learn how to use Git and GitHub.

- [GitHub Desktop](https://desktop.github.com) (Recommended App)

- [Set Up Git](https://help.github.com/articles/set-up-git/)

- [Make a Fork](https://guides.github.com/activities/forking/)

- [Different Ways of Contributing](https://guides.github.com/activities/contributing-to-open-source/#contributing)

- [More GitHub Tutorials](https://guides.github.com)

#### 5. Find out how to contribute.
There are many ways to contribute to the project, such as play-testing, contributing to the project’s source code, creating assets and art, and finding and reporting bugs. 

- To contribute to the project’s source code, [create a fork](http://imgur.com/a/D5Ee6), modify your fork, and [submit a pull request](https://help.github.com/articles/using-pull-requests/). Things currently being worked on or needing attention can be found in the [Issues section](https://github.com/VideoGameDevClub/VacuumCleanSupreme/issues).

- Creation of assets and art encompasses multiple things, including creation of 3D models, textures, sound effects, particle effects, interface elements, and animations. There are many free and paid utilities that may be used for producing each of these things. Below are some recommended apps that can be downloaded for free.
	- For 3D models, [SketchUp (Windows, Mac)](http://www.sketchup.com) or [Blender (Windows, Mac, GNU/Linux)](https://www.blender.org)
	- For creating textures, [Gimp (Windows, Mac, GNU/Linux)] (https://www.gimp.org/downloads/) or [Pixelmator (Mac)](http://www.pixelmator.com/mac/try/) (free for 30 days)
	- For sound effects, [Audacity (Windows, Mac, GNU/Linux)](http://audacityteam.org) or [GarageBand (Mac)](http://www.apple.com/mac/garageband/)
	- Particle effects, interface elements, and animations can be created within Unity on [Mac](http://unity3d.com/get-unity/download?thank-you=update&download_nid=24110&os=Mac) and [Windows](http://unity3d.com/get-unity/download?thank-you=update&download_nid=24110&os=Win).

- If you find a bug or problem, first go to the [Issues section](https://github.com/VideoGameDevClub/VacuumCleanSupreme/issues) of the repository to check if the bug or problem has already been reported. If it has not already been reported, [open a new issue](https://github.com/VideoGameDevClub/VacuumCleanSupreme/issues/new) and give a detailed explanation of the issue and any suggestions for a solution.

If you need any further assistance, contact ecd157@msstate.edu.


### Extra Stuff

#### Install ZenHub for integrated to-do lists on GitHub.
Zenhub changes the format of the Issues section for a new way of organizing your issues and tracking stats. This extension is not required to be able to work on this project. 

- Add ZenHub here: https://zenhub.io/

- After adding ZenHub, check out the new Issues and Boards page here: https://github.com/VideoGameDevClub/VacuumCleanSupreme/issues

#### Go through a Photon tutorial.
This project utilizes the networking features of a Unity plugin you can find on their asset store called Photon. This plugin/service allows us to keep things simple by not having to set up our own server for listening and sending calls. This plugin also makes writing network code *extremely* simple.  

I suggest creating an empty project on your machine and just going through their [Marco Polo tutorial](https://doc.photonengine.com/en/pun/current/tutorials/tutorial-marco-polo).  This tutorial takes no longer than an hour, and afterwords you'll have a good idea of what's going on whenever you see/write networking code.

### Project Standards
These are just a few standards that we would like contributions to follow for consistency throughout the project.  When you submit a PR we will make sure your changes follow these standards and, if needed, recommend appropriate changes so that they do.

* All code written will be under the Scripts folder.
* Folders, file names, enums, and enum constants should be done in camel case beggining in a capital letter
  * ex: ```DemoAssets```
  * ex: ```EnemyBehavior```
  * ex: ```enum EnemyState { Searching, Pursuing, Attacking, Fleeing }```
* Function names are declared camel case and with starting letter lower case
  * ex: ```killSelf()```
* If an enum is made public it should be put in its own file that is named the enum
  * ex: ```public enum EnemyState``` will be put in ```EnemyState.cs```, which only contains the enum decleration and using statements.
  * This is to make finding where the enum is declared easier, as well as an attempt at making merge conflicts easier.
* When you plan to have a class extend from monobehavior (such as a class meant for controlling camera movement), end the name of the class in ```Behavior```
  * ex: ```CameraControlBehavior.cs```
* Document every class and function!
  * To quickly add a summary to a class or function, move the cursor to above the declaration of a class slash function and enter '```///```'.  This in both Mono and VS start a nice body for the description of the class / function.
* **0 public variables.**  To get a variable's value or set it create the appropriate getter and setter methods (otherwise known as accessor and mutator methods).
* Namespace convention: Preface with VGDC, and every parent folder the script is contained in will come after. (Ignoring the Script folder)
  * Ex: If script x is under Scripts > GameManagement, then the script's namespace will be ```VGDC.GameManagement```
  * Ex. If script y is under Scripts > Characters > Player > Weapons, then the script's namespace will be ```VGDC.Characters.Player.Weapons```
  
### Programming Conventions
These are just suggestions that have made our time coding in Unity easier.
* When having a function being called inside of one of [MonoBehavior's messages](http://docs.unity3d.com/ScriptReference/MonoBehaviour.html) ( ex: ```Update()``` ), then that function should end in that message's name.
  * This makes programming state machine's easier.  The ```Update()``` contains a switch statement that calls the appropriate function based on the state.
  * ex: In ```Flee``` state, ```FleeUpdate()``` is a method that is called inside of [Update](http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html).  
  * ex: In ```Flee``` state, ```FleeOnCollisionEnter()``` is a method that is called inside of [OnCollisionEnter](http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter.html)
* Initialize ```Vector3``` variables to ```Vector3.zero;```
* If you want to edit a script's variable in monobehavior add the ```[SerializeField]``` line above the variable decleration.
* You should most likely be using a ```CharacterController``` rather than a rigid body for agent movement.
* Don't use ```Destroy( gameObject )``` for removing the gameobject in the scene.  If there comes a time that you need to remove a gameobject from the scene localize that ```Destroy()``` statement to its own method that can be called. Similar to destructors.
