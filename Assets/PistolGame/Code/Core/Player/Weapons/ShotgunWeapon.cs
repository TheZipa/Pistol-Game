using PistolGame.Code.Core.Player.Weapons.Bullets;
using PistolGame.Code.Data.StaticData.Weapons;
using PistolGame.Code.Services.SpawnedEntitiesProvider;
using UnityEngine;
using UnityEngine.Pool;

namespace PistolGame.Code.Core.Player.Weapons
{
    public class ShotgunWeapon : Weapon
    {
        private ShotgunWeaponData _shotgunWeaponData;
        
        public override void Construct(ISpawnedEntitiesProvider spawnedEntitiesProvider, IObjectPool<WeaponBullet> bulletsPool, WeaponData weaponData)
        {
            base.Construct(spawnedEntitiesProvider, bulletsPool, weaponData);
            _shotgunWeaponData = (ShotgunWeaponData)weaponData;
        }

        public override void Shoot(Vector2 direction)
        {
            float angleStep = _shotgunWeaponData.SpreadAngle / (_shotgunWeaponData.BulletsPerShoot - 1);
            float startAngle = -_shotgunWeaponData.SpreadAngle / 2;

            for (int i = 0; i < _shotgunWeaponData.BulletsPerShoot; i++) 
                StartBullet(direction, startAngle, angleStep, i);
        }

        private void StartBullet(Vector2 direction, float startAngle, float angleStep, int i)
        {
            float currentAngle = startAngle + angleStep * i;
            Vector2 bulletDirection = Quaternion.Euler(0, 0, currentAngle) * direction;
            WeaponBullet bullet = PrepareBullet();
            bullet.Release(bulletDirection);
        }
    }
}