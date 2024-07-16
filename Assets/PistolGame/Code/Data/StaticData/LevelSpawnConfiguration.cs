using UnityEngine;

namespace PistolGame.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "LevelSpawnConfiguration", menuName = "StaticData/LevelSpawnConfiguration")]
    public class LevelSpawnConfiguration : ScriptableObject
    {
        public string[] PrefabsPool;
        [Space(10)]
        public int MinSpawnQuantity;
        public int MaxSpawnQuantity;
        [Space(10)]
        public float MinRadius;
        public float MaxRadius;
    }
}