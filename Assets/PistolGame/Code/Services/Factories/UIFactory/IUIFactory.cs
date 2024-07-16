using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.UI;
using PistolGame.Code.Core.UI.HUD;
using PistolGame.Code.Services.Factories.BaseFactory;
using UnityEngine;

namespace PistolGame.Code.Services.Factories.UIFactory
{
    public interface IUIFactory : IBaseFactory, IGlobalService
    {
        UniTask<GameObject> CreateRootCanvas();
        UniTask WarmUpMainMenu();
        UniTask<TopPanel> CreateTopPanel(Transform rootCanvas);
        UniTask WarmUpGameplay();
        UniTask WarmUpPersistent();
        UniTask<IPlayerInput> CreatePlayerInput(Transform rootCanvas);
        UniTask<WeaponSwapPanel> CreateWeaponSwapPanel(Transform rootCanvas);
    }
}