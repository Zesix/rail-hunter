![Rail Hunter gameplay screenshot](https://i.imgur.com/SqjsoDw.jpg)

## Rail Hunter ##

This project is released to the public domain under [The Unlicense](https://github.com/Zesix/rail-hunter/blob/master/LICENSE) EXCEPT for the following files:
 * Files in the Packages/ folder are bound by the Unity Asset Store EULA and are free assets users can use within those terms.
 * Audio track "Gold Coast" is by Machinima Sound and is licensed under [CC-BY 4.0](https://creativecommons.org/licenses/by/4.0/).
 * Audio track "Aduro" is by Machinima Sound and is licensed under [CC-BY 4.0](https://creativecommons.org/licenses/by/4.0/).
 
### Features ###
 * Title, options, game over screens.
 * Music player.
 * Timeline-driven rails gameplay.
 * Local space player ship movement with aileron roll mechanic.
 * Enemies fire homing missiles randomly within min/max firing range.
 * Enemies flash red emission on hit.
 * Top score and options screen settings saved using PlayerPrefs.
 
### Project Architecture ###

This project is built using the [Impulse Framework](https://github.com/Zesix/Impulse).

 - Zenject is used for DI, binding, memory pool, and event system (signals). To see how the scene is wired, look at the GameInstaller component attached to SceneContext.
 - Input handling is done by InputListener. It listens to input from the CrossPlatformInput manager and fires events accordingly.
 - Player is set up using a Model-View-Controller pattern (MVC), where the model and controller are in Scripts/Player and the views are in Ships/PlayableShips. PlayableShip is the abstract class for player-controllable ship views.
Note that there is only one playable ship, but the structure allows for adding more views easily - just extend PlayableShip and put the new script on a new ship object.
 - Weapons implement IWeapon and must have an impact damage property. See MissileWeapon, ScoutShipView, and PlayerController for how the impact damage amount is passed via event.
 - Rails gameplay is driven by Timeline. The player path runs at 0.8 speed since I originally made it too fast. Each 'wave' of enemy ships also runs at a different speed for a more tuning gameplay experience.
