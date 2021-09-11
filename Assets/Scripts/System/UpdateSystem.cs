using System.Collections.Generic;
using Asteroids.Abstraction;

namespace Asteroids.System
{
    public abstract class UpdateSystem<T> : IUpdateSystem<T> 
    {
        private bool _paused;
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Pause(bool pause)
        {
            _paused = pause;
        }

        public void Update(double deltaTime)
        {
            if (_paused) return;

            for (var index = 0; index < _items.Count; index++)
            {
                Update(_items[index], deltaTime);
            }
        }

        protected abstract void Update(T item, double deltaTime);
        
        public void Clear()
        {
            _items.Clear();
        }
    }
}