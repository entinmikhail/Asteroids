

namespace Asteroids.Abstraction
{
    public interface IShellInfo
    {
        float MovementSpeed { get; }

        float ShellLifeTime { get; }
        public string Type { get; }
        
        public string ViewId { get; }
        
        public bool Destroyable { get; }
        
        public BaseShellBehavior ShellBehavior { get; }
    }
}