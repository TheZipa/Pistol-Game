using PistolGame.Code.Data.StaticData;
using PistolGame.Code.Services.StaticData.StaticDataProvider;

namespace PistolGame.Code.Services.StaticData
{
    public class StaticData : IStaticData
    {
        public PlayerConfiguration PlayerConfiguration { get; private set; }
        public LevelSpawnConfiguration LevelSpawnConfiguration { get; private set; }

        private readonly IStaticDataProvider _staticDataProvider;

        public StaticData(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
            LoadStaticData();
        }

        public void LoadStaticData()
        {
            PlayerConfiguration = _staticDataProvider.LoadPlayerConfiguration();
            LevelSpawnConfiguration = _staticDataProvider.LoadSpawnConfiguration();
        }
    }
}