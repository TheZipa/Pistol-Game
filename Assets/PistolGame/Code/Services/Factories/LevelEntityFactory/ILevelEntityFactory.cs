using Cysharp.Threading.Tasks;
using PistolGame.Code.Services.Factories.BaseFactory;

namespace PistolGame.Code.Services.Factories.LevelEntityFactory
{
    public interface ILevelEntityFactory : IBaseFactory, IGlobalService
    {
        UniTask WarmUp();
        UniTask CreateLevelEntities();
    }
}