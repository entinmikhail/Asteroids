namespace Asteroids.Abstraction
{
    public interface IPlayerInfo : IModelInfo
    {
        float MaxMovementSpeed { get; }
        IPlayerMoveBehavior CreatePlayerMoveBehavior(bool isCurView3d);

    }
}