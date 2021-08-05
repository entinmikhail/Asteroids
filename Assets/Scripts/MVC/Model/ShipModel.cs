using Asteroids.Abstraction;
using Asteroids.ScriptableObjects;
using UnityEngine;

namespace Asteroids.Model
{
    public class ShipModel : IShip
    {
        public IWeapon FirstWeapon { get; }
        public IWeapon SecondWeapon { get; }
        
        private ShipInfo _shipInfo;

        public ShipModel(ShipInfo shipInfo, IWeapon firstWeapon, IWeapon secondWeapon)
        {
            _shipInfo = shipInfo;
            FirstWeapon = firstWeapon;
            SecondWeapon = secondWeapon;
        }
        
        
    }
}