

namespace Asteroids.Abstraction
{
    public interface IShellInfo : IModelInfo
    {
        float ShellLifeTime { get; }
        public string Type { get; }
        public bool Destroyable { get; }
        public BaseShellBehavior ShellBehavior { get; }
    }
}