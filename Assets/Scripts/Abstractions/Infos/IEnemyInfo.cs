namespace Asteroids.Abstraction
{
    public interface IEnemyInfo : IModelInfo
    {
        public string ViewId { get; }
        int PointsForKill { get; }
        public string Type { get; }
        public BaseEnemyBehavior EnemyBehavior { get; }
    }
}