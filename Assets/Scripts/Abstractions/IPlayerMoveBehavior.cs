namespace Asteroids.Abstraction
{
    public interface IPlayerMoveBehavior
    {
        void Init (ILevelObjectView view, IPlayerView playerView, params object[] additionalParams);
        void DiedBehaviour (ILevelModel levelModel, params object[] additionalParams);
        void Move(float inputValue);
        void Rotate(float inputValue);
        void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed);
    }
}