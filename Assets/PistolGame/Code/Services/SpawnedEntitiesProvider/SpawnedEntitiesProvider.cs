using System.Collections.Generic;
using System.Linq;
using PistolGame.Code.Core.LevelEntities;
using UnityEngine;

namespace PistolGame.Code.Services.SpawnedEntitiesProvider
{
    public class SpawnedEntitiesProvider : ISpawnedEntitiesProvider
    {
        private readonly Dictionary<Transform, LevelEntity> _spawnedEntities = new(50);

        public void RegisteredSpawnedEntity(LevelEntity entity) => 
            _spawnedEntities.Add(entity.transform, entity);

        public T GetEntityFromTransform<T>(Transform entityTransform) where T : class
        {
            if (!_spawnedEntities.TryGetValue(entityTransform, out LevelEntity levelEntity)) return null;
            if (levelEntity is T entity) return entity;
            return null;
        }

        public Dictionary<Transform, LevelEntity> GetEntitiesByLayer(LayerMask layerMask) =>
            _spawnedEntities
                .Where(s => ((1 << s.Value.gameObject.layer) & layerMask) != 0)
                .ToDictionary(t => t.Key, e => e.Value);

        public void Clear() => _spawnedEntities.Clear();
    }
}