using PistolGame.Code.Core.Damage;
using PistolGame.Code.Core.Player.Weapons.Bullets;
using PistolGame.Code.Data.StaticData.Weapons;
using PistolGame.Code.Services.SpawnedEntitiesProvider;
using UnityEngine;
using UnityEngine.Pool;

namespace PistolGame.Code.Core.Player.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform _releasePosition;
        [SerializeField] protected SpriteRenderer _view;
        protected ISpawnedEntitiesProvider _spawnedEntitiesProvider;
        protected IObjectPool<WeaponBullet> _bulletsPool;
        protected WeaponData _weaponData;

        public virtual void Construct(ISpawnedEntitiesProvider spawnedEntitiesProvider, 
            IObjectPool<WeaponBullet> bulletsPool, WeaponData weaponData)
        {
            _spawnedEntitiesProvider = spawnedEntitiesProvider;
            _view.sprite = weaponData.WorldView;
            _bulletsPool = bulletsPool;
            _weaponData = weaponData;
        }
        
        public abstract void Shoot(Vector2 direction);

        public virtual void Show() => _view.enabled = true;
        
        public virtual void Hide() => _view.enabled = false;

        protected WeaponBullet PrepareBullet()
        {
            WeaponBullet bullet = _bulletsPool.Get();
            SubscribeBullet(bullet);
            bullet.transform.position = _releasePosition.position;
            return bullet;
        }

        private void SubscribeBullet(WeaponBullet bullet)
        {
            bullet.OnLifetimeEnd.AddListener(() => ReturnBulletToPool(bullet));
            bullet.OnHit.AddListener(hitEntity =>
            {
                ApplyHit(hitEntity);
                ReturnBulletToPool(bullet);
            });
        }

        private void ApplyHit(Transform hitEntity)
        {
            IDamageble damageble = _spawnedEntitiesProvider.GetEntityFromTransform<IDamageble>(hitEntity);
            damageble?.TakeDamage(_weaponData.Damage);
        }

        private void ReturnBulletToPool(WeaponBullet bullet)
        {
            _bulletsPool.Release(bullet);
            bullet.OnHit.RemoveAllListeners();
            bullet.OnLifetimeEnd.RemoveAllListeners();
        }
    }
}