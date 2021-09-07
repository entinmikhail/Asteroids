namespace Asteroids.Abstraction
{
    public interface IPlayerMoveBehavior
    {
        void Init(IPlayerView playerView, IPlayerInfo playerInfo);
        void Move(float inputValue);
        
        void Rotate(float inputValue);
    }
}