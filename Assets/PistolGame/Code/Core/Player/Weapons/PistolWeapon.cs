using PistolGame.Code.Core.Player.Weapons.Bullets;
using UnityEngine;

namespace PistolGame.Code.Core.Player.Weapons
{
    public class PistolWeapon : Weapon
    {
        public override void Shoot(Vector2 direction)
        {
            WeaponBullet bullet = PrepareBullet();
            bullet.Release(direction);
        }
    }
}