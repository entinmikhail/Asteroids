using Asteroids.Abstraction;

namespace Asteroids.Model
{
    public class Player : ModelBase<IPlayerInfo>, IPlayer
    {
        public Player(IPlayerInfo info) : base(info)
        {
        }

        public override IPlayerInfo GetInfo()
        {
            return _info;
        }
    }
}