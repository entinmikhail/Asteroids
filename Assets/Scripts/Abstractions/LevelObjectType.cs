using System;

namespace Asteroids.Abstraction
{
    [Serializable]
    public enum LevelObjectType
    {
        Ship,
        Asteroid,
        MiniAsteroid,   
        UFO,
        Laser,
        Bullet
    }
}