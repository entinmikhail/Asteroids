namespace Asteroids.Abstraction
{
    public interface IBaseBehavior
    {
        void OnUpdate(ILevelObjectView view, IPlayerView playerView, float speed);
        void Init(ILevelObjectView view, IPlayerView playerView, params object[] additionalParams);
        void DiedBehaviour(ILevelModel levelModel, params object[] additionalParams);
    }
}