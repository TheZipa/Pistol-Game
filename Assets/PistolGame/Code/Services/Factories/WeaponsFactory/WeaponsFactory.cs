using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.Player.Weapons;
using PistolGame.Code.Core.Player.Weapons.Bullets;
using PistolGame.Code.Data.StaticData.Weapons;
using PistolGame.Code.Services.Assets;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.SpawnedEntitiesProvider;
using PistolGame.Code.Services.StaticData;
using UnityEngine;
using UnityEngine.Pool;

namespace PistolGame.Code.Services.Factories.WeaponsFactory
{
    public class WeaponsFactory : BaseFactory.BaseFactory, IWeaponsFactory
    {
        private readonly IStaticData _staticData;
        private readonly ISpawnedEntitiesProvider _spawnedEntitiesProvider;

        public WeaponsFactory(IAssets assets, IEntityContainer entityContainer, 
            IStaticData staticData, ISpawnedEntitiesProvider spawnedEntitiesProvider) : base(assets, entityContainer)
        {
            _staticData = staticData;
            _spawnedEntitiesProvider = spawnedEntitiesProvider;
        }

        public async UniTask WarmUp()
        {
            await _assets.Load<GameObject>(nameof(SimpleBullet));
            foreach (WeaponData weaponData in _staticData.PlayerConfiguration.Weapons) 
                await _assets.Load<GameObject>(weaponData.PrefabName);
        }
        
        public async UniTask<Weapon[]> CreateWeapons(Transform weaponLocation)
        {
            WeaponData[] weaponsData = _staticData.PlayerConfiguration.Weapons;
            Weapon[] playerWeapons = new Weapon[weaponsData.Length];

            for (int i = 0; i < weaponsData.Length; i++)
            {
                Weapon weapon = await Instantiate<Weapon>(weaponsData[i].PrefabName, weaponLocation);
                weapon.Construct(_spawnedEntitiesProvider, CreateBulletsPool(weaponsData[i].BulletData), weaponsData[i]);
                weapon.Hide();
                playerWeapons[i] = weapon;
            }

            return playerWeapons;
        }

        private IObjectPool<WeaponBullet> CreateBulletsPool(WeaponBulletData weaponBulletData) =>
            new ObjectPool<WeaponBullet>(() => CreateBullet(weaponBulletData),
                bullet => bullet.Show(), bullet => bullet.Hide(), 
                Object.Destroy, false, 25);

        private WeaponBullet CreateBullet(WeaponBulletData weaponBulletData)
        {
            WeaponBullet weaponBullet = Instantiate<WeaponBullet>(weaponBulletData.BulletPrefabName).GetAwaiter().GetResult();
            weaponBullet.Construct(weaponBulletData);
            return weaponBullet;
        }
    }
}