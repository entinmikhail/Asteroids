namespace Asteroids.Abstraction
{
    public interface IUpdateSystem<T>
    {
        void Add(T item);
        void Remove(T item);
        void Pause(bool pause);
        void Update(double deltaTime);
        void Clear();
    }
}