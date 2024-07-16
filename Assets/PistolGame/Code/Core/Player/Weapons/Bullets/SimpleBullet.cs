using UnityEngine;

namespace PistolGame.Code.Core.Player.Weapons.Bullets
{
    public class SimpleBullet : WeaponBullet
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public override void Release(Vector2 direction) =>
            _rigidbody2D.velocity = direction * _bulletData.Speed;
    }
}