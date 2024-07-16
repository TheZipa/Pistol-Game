using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.LevelEntities;
using PistolGame.Code.Data.StaticData;
using PistolGame.Code.Services.Assets;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.SpawnedEntitiesProvider;
using PistolGame.Code.Services.StaticData;
using UnityEngine;

namespace PistolGame.Code.Services.Factories.LevelEntityFactory
{
    public class LevelEntityFactory : BaseFactory.BaseFactory, ILevelEntityFactory
    {
        private readonly IStaticData _staticData;
        private readonly ISpawnedEntitiesProvider _spawnedEntitiesProvider;

        public LevelEntityFactory(IAssets assets, IEntityContainer entityContainer, 
            IStaticData staticData, ISpawnedEntitiesProvider spawnedEntitiesProvider) : base(assets, entityContainer)
        {
            _staticData = staticData;
            _spawnedEntitiesProvider = spawnedEntitiesProvider;
        }

        public async UniTask WarmUp()
        {
            _spawnedEntitiesProvider.Clear();
            foreach (string entityPrefab in _staticData.LevelSpawnConfiguration.PrefabsPool) 
                await _assets.Load<GameObject>(entityPrefab);
        }
        
        public async UniTask CreateLevelEntities()
        {
            LevelSpawnConfiguration levelSpawnConfig = _staticData.LevelSpawnConfiguration;
            int spawnQuantity = Random.Range(levelSpawnConfig.MinSpawnQuantity, levelSpawnConfig.MaxSpawnQuantity + 1);
            LevelEntity[] entities = new LevelEntity[spawnQuantity];

            for (int i = 0; i < spawnQuantity; i++) 
                entities[i] = await CreateRandomEntity(levelSpawnConfig.PrefabsPool);
        }

        private async UniTask<LevelEntity> CreateRandomEntity(string[] entitiesPrefabsPool)
        {
            string entityPrefab = entitiesPrefabsPool[Random.Range(0, entitiesPrefabsPool.Length)];
            LevelEntity entity = await Instantiate<LevelEntity>(entityPrefab);
            entity.Construct();
            entity.transform.position = GetRandomRadiusPosition();
            _spawnedEntitiesProvider.RegisteredSpawnedEntity(entity);
            return entity;
        }

        private Vector3 GetRandomRadiusPosition()
        {
            float minRadius = _staticData.LevelSpawnConfiguration.MinRadius;
            float maxRadius = _staticData.LevelSpawnConfiguration.MaxRadius;
            float angle = Random.Range(0f, Mathf.PI * 2);
            float radius = Random.Range(minRadius, maxRadius);
            return new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        }
    }
}