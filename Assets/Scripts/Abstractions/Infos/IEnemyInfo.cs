namespace Asteroids.Abstraction
{
    public interface IEnemyInfo : IModelInfo 
    {
        int PointsForKill { get; }
        public string Type { get; }
        public BaseBehavior CreateEnemyBehavior();
    }
}