using PistolGame.Code.Data.StaticData;
using UnityEngine;

namespace PistolGame.Code.Services.StaticData.StaticDataProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private const string PlayerConfigurationPath = "StaticData/PlayerConfiguration";
        private const string LevelSpawnConfigurationPath = "StaticData/LevelSpawnConfiguration";
        
        public PlayerConfiguration LoadPlayerConfiguration() =>
            Resources.Load<PlayerConfiguration>(PlayerConfigurationPath);

        public LevelSpawnConfiguration LoadSpawnConfiguration() =>
            Resources.Load<LevelSpawnConfiguration>(LevelSpawnConfigurationPath);
    }
}