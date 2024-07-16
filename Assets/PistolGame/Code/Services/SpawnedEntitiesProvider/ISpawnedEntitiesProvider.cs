using System.Collections.Generic;
using PistolGame.Code.Core.LevelEntities;
using UnityEngine;

namespace PistolGame.Code.Services.SpawnedEntitiesProvider
{
    public interface ISpawnedEntitiesProvider : IGlobalService
    {
        void RegisteredSpawnedEntity(LevelEntity entity);
        T GetEntityFromTransform<T>(Transform entityTransform) where T : class;
        Dictionary<Transform, LevelEntity> GetEntitiesByLayer(LayerMask layerMask);
    }
}