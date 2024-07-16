using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.Player;
using PistolGame.Code.Services.Factories.BaseFactory;

namespace PistolGame.Code.Services.Factories.PlayerFactory
{
    public interface IPlayerFactory : IBaseFactory, IGlobalService
    {
        UniTask WarmUp();
        UniTask<Player> CreatePlayer();
    }
}