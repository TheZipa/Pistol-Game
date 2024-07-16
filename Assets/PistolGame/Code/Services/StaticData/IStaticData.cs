using PistolGame.Code.Data.StaticData;

namespace PistolGame.Code.Services.StaticData
{
    public interface IStaticData : IGlobalService
    {
        PlayerConfiguration PlayerConfiguration { get; }
        LevelSpawnConfiguration LevelSpawnConfiguration { get; }
        void LoadStaticData();
    }
}