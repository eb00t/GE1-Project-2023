# Space-ketball

### Name: 
Eoghan O'Reilly
### Student Number: 
C21430996

### Class Group: 
TU984 - Game Design
### Video:

[![YouTube](https://img.youtube.com/vi/kdJjiUo1By8/maxresdefault.jpg)](https://www.youtube.com/embed/kdJjiUo1By8?si=oNldZk88Hu-xFD-4)

### Description of the Project
This is a game in which the player must throw different coloured balls into hoops. The game is set in space, in between a planet that has been split in half. The player starts within a mysterious structure and must throw the ball into the hoop to proceed.

### Instructions For Use
The game is quite simple. It is played in VR. The player can move around with the left thumbstick, turn with the right and use the grip buttons to pick up and throw certain objects. That is all the player needs to play.

### How It Works
The game makes heavy use of the Unity XR Interaction Toolkit. It mainly uses colliders to function. Each hoop has a collider within it, and its tag corresponds to an ID within an attached script. This script is used within the GameManager script to start coroutines, such as the falling and disappearing of planets, or the spawning of platforms. The eye at the end is related to a script that causes the platforms to fall. It contains a counter, whcih counts up for each set of platforms that falls. Once all platforms have fallen, the eye awakens. It uses a combination of animations and a lerping script to create the effect.

### List of Classes/Assets in the Project
 	
| Class/Asset | Source |
|---|---|
| GameManager.cs | Self written |
| TColl.cs | Self written |
| ParticleHandler.cs |	Self written |	
| Starfield Skybox | [PULSAR BYTES - Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717) |
| Outline Shader | [Digvijaysinh Gohil - Youtube](https://www.youtube.com/watch?v=JCXYR_5vhNc) |
| PositionResetter.cs | Self written |
| BSpawn.cs | Self written |
| DropTrig.cs | Self written |
| SoundManager.cs | Self written |
| SceneManagement.cs | Self written |


### List of Sound Effects

| Sound Effect | Source |
|---|---|
| Thumps | [egomassive - Freesound](https://freesound.org/s/536789/) |
| Basketball Hits Pack | [zmobie - Freesound](https://freesound.org/p/17904/) |
| Ambient Space Noise 1 | [THe_TooTHPaSTe_VaMPiReS - Freesound](https://freesound.org/s/511493/) |

### References

* [Unity Reference](https://docs.unity3d.com/ScriptReference/index.html)
* [Unity Forums](https://forum.unity.com/)
* [Unity Discussions](https://discussions.unity.com/)

### What I Am Most Proud Of:
I am very proud of the aesthetic and feel of the project. It is very surreal and strange-looking, which was my goal. I am a big fan of weird games, which was hopefully shown off well in this project. It was also satisifying to get lerping to work properly.

### What I Learned:
I learned that organisation and a clear plan of what I am to do is necessary in order to avoid rushing near the end. During this project, I feel I was quite disorganised, and many of the ideas I wished to implement into the game would have taken far too much time to do so.
In addition to this, I also managed to get Lerp working and used particle systems for the first time in Unity. These will prove useful to me in the future.
I also learned how to use a basic outline shader, which I plan to use in a great many projects going forward.

### Proposal:
Space-ketball - A VR game that involves throwing planets around. The planets are all out of whack! Using the rings as your hoop, you must throw each planet into the correct set of rings. The game gets progressively harder the farther along you go.
