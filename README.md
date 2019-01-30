# unity-explosion
A small script behavior for Unity3D. It uses damage falloff curves and explosion forces.

## Usage in Unity3D
To use this MonoBehaviour, simply attach it to a GameObject that you want to be exploding. The explosion is triggered through the `Explode();` method. The destructible mask is a mask of all the layers that are effected by the explosion. These GameObjects will take damage and have a force applied to them (given that they're rigidbodies). The damage is defined by the damage value, which is the maximum amount of damage dealt to objects within range, and the damage falloff curve. The blast radius is the maxmimum range of effect.

The obstacle mask is the layers that block the effects of the explosion. These layers could be applied to walls, floors, and other objects that should be able to stop an explosive force going through them.

![Image of script usage](https://i.imgur.com/cSbiZdt.png)

The death GameObjects are the GameObbjects to be instantiated after the explosion, e.g. a prefab of an explosion effect.
