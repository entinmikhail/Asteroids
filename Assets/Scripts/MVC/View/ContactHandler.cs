using Asteroids.Abstraction;

namespace Asteroids.View
{
    public class LevelObjectContactHandler
    {
        public event ContactHandler OnLevelObjectContact;

        public void OnContact(ILevelObjectView self, ILevelObjectView contact)
        {
            OnLevelObjectContact?.Invoke(self, contact);
        }
    }
}