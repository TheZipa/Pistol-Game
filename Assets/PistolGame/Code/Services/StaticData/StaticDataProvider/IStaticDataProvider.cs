using PistolGame.Code.Data.StaticData;

namespace PistolGame.Code.Services.StaticData.StaticDataProvider
{
    public interface IStaticDataProvider : IGlobalService
    {
        PlayerConfiguration LoadPlayerConfiguration();
        LevelSpawnConfiguration LoadSpawnConfiguration();
    }
}