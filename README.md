# VacuumCleanSupreme
Spring 2016 Semester Project

#####**Try out the web version of our game**: http://videogamedev.club/VacuumBuild/

### Getting Started on the Project

#### 1. Download Unity 5.3.1f1.
5.3.1f1 is the version being used for this project.
 
- Unity for Mac: https://unity3d.com/get-unity/download?thank-you=update&download_nid=24110&os=Mac
 
- Unity for Windows: https://unity3d.com/get-unity/download?thank-you=update&download_nid=24110&os=Win

#### 2. Do a few Unity tutorials (if you're new).

- Introduction to Unity: https://unity3d.com/learn/tutorials/topics/interface-essentials

- Using C# Scripting: https://unity3d.com/learn/tutorials/topics/scripting

- More Unity Tutorials: https://unity3d.com/learn/tutorials

#### 3. Check out our site.
 
http://videogamedev.club 

We'll be giving club and project updates, useful information, and project game builds.

#### 4. Familiarize yourself with the documentation and project programming standards.

- Project Documentation: [Mockup Object Model Diagram](http://videogamedev.club/?page=GamePlans)

- Programming Standards: (At the end of this document)

#### 5. Learn how to use Git and Github.

- (Recommended App) GitHub Desktop: https://desktop.github.com

- Set Up Git: https://help.github.com/articles/set-up-git/

- Make a Fork: https://guides.github.com/activities/forking/

- Different Ways of Contributing: https://guides.github.com/activities/contributing-to-open-source/#contributing

- More GitHub Tutorials: https://guides.github.com

#### 6. [Create a fork](http://imgur.com/a/D5Ee6) and make some contributions.
Now that you've downloaded Unity and become familiar with the basics, it's time to jump in and make something great. Just clone the project, open it, and start on a task. Below are things we're currently working on.

**Task list**: https://github.com/VideoGameDevClub/VacuumCleanSupreme/issues

### Extra Stuff

#### Install ZenHub for integrated to-do lists on GitHub.
Zenhub changes the format of the Issues tab for a new way of organizing your issues and tracking stats. This extension is not required to be able to work on this project. 

- Add ZenHub here: https://zenhub.io/

- After adding ZenHub, check out the new Issues and Boards page here: https://github.com/VideoGameDevClub/VacuumCleanSupreme/issues

#### Go through a Photon tutorial.
This project utilizes the networking features of a Unity plugin you can find on their asset store called Photon. This plugin/service allows us to keep things simple by not having to set up our own server for listening and sending calls. This plugin also makes writing network code *extremely* simple.  

I suggest creating an empty project on your machine and just going through their [Marco Polo tutorial](https://doc.photonengine.com/en/pun/current/tutorials/tutorial-marco-polo).  This tutorial takes no longer than an hour, and afterwords you'll have a good idea of what's going on whenever you see/write networking code.

### Project Standards
These are just a few standards that we would like the repository to follow for consistency's sake.  When you submit a PR we will make sure your changes follow these standards, and, if not, we will ask you to make the appropriate changes so that they do.

* All code written will be under the Scripts folder!
* Folders, file names, enums, and enum constants should be done in camel case beggining in a capital letter
  * ex: DemoAssets
  * ex: EnemyBehavior
  * ex: enum EnemyState { Searching, Persuing, Attacking, Fleeing }
* Function names are declared camel case and with starting letter lower case
  * ex: killSelf()
* If an enum is made public it should be put in it's own file that is named the enum
  * ex: public enum EnemyState will be put in EnemyState.cs, which only contains the enum decleration and using statements.
  * This is to make finding where the enum is declared easier, as well as an attempt at making merge conflicts easier.
* When you plan to have a class extend from monobehavior (such as a class meant for controlling camera movement), end the name of the class in Behavior
  * ex: CameraControlBehavior.cs
* Document every class and function!
  * To quickly add a summary to a class or function, move the cursor to above the declaration of a class slash function and enter '///'.  This in both Mono and VS start a nice body for the description of the class / function.
* **0 public variables.**  To get a variable's value or set it create the appropriate getter and setter methods.
* Namespace convention: Preface with VGDC, and every parent folder the script is contained in will come after. (Ignoring the Script folder)
  * Ex: If script x is under Scripts > GameManagement, then the script's namespace will be VGDC.GameManagement
  * Ex. If script y is under Scripts > Characters > Player > Weapons, then the script's namespace will be VGDC.Characters.Player.Weapons
  
### Programming Suggestions
These are just suggestions that have made our time coding in Unity easier.
* When having a function being called inside of one of [MonoBehavior's messages](http://docs.unity3d.com/ScriptReference/MonoBehaviour.html) ( ex: Update() ), then that function should end in that message's name.
  * This makes programming state machine's easier.  The Update() contains a switch statement that calls the appropriate function based on the state.
  * ex: In Flee state, FleeUpdate() is a method that is called inside of [Update](http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html).  
  * ex: In Flee state, FleeOnCollisionEnter() is a method that is called inside of [OnCollisionEnter](http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter.html)
* Initialize Vector3 variables to Vector3.zero;
* If you want to edit a script's variable in monobehavior add the *[SerializeField]* line above the variable decleration.
* You should most likely be using a CharacterController rather than a rigid body for agent movement.
* Don't use Destroy( gameObject ) for removing the gameobject in the scene.  If it comes a time that you need to remove a gameobject from the scene localize that Destroy() statement to it's own method that can be called. Similar to destructors.
