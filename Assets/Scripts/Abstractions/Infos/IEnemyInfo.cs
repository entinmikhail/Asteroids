namespace Asteroids.Abstraction
{
    public interface IEnemyInfo
    {
        float MovementSpeed { get; }
        public float RotationSpeed  { get; }
        public string Type { get; }
        public string ViewId { get; }
        public int MaxHealth  { get; }
        public int Health  { get; }
        int PointsForKill { get; }
        public BaseEnemyBehavior EnemyBehavior { get; }
    }
}