# unity-explosion
A small script behavior for Unity3D. It uses damage falloff curves and explosion forces.

## Usage in Unity3D
To use this MonoBehaviour, simply attach it to a GameObject that you want to be exploding. The explosion is triggered through the `Explode();` method. The destructible mask is a mask of all the layers that are effected by the explosion. These GameObjects will take damage and have a force applied to them (given that they're rigidbodies).
![Image of script usage](https://i.imgur.com/cSbiZdt.png)
