using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Zenject;

public class ControllersInstaller : MonoInstaller
{
    [SerializeField] private PlayerView _playerView;
    public override void InstallBindings()
    {
        var healthModel =  new HealthModel(Resources.Load<PlayerInfo>("ShipInfo").Health);
        Container.Bind<HealthModel>().FromInstance(healthModel).AsCached();

        var pointModel = new PointModel(0);
        Container.Bind<PointModel>().FromInstance(pointModel).AsCached();
        
        var gameModel = new GameModel();
        Container.Bind<GameModel>().FromInstance(gameModel).AsCached();
        
        Container.Bind<PlayerView>().FromInstance(_playerView).AsCached();
        

    }
}