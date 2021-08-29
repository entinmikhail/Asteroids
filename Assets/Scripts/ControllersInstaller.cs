using Asteroids.Abstraction;
using Asteroids.Model;
using Asteroids.ScriptableObjects;
using Asteroids.View;
using UnityEngine;
using Zenject;


    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var healthModel =  new HealthModel(Resources.Load<ShipInfo>("ShipInfo").Health);
            Container.Bind<HealthModel>().FromInstance(healthModel).AsCached();

            var pointModel = new PointModel(0);
            Container.Bind<PointModel>().FromInstance(pointModel).AsCached();

            var gameModel = new GameModel();
            Container.Bind<GameModel>().FromInstance(gameModel).AsCached();
        }
    }

