using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.UI;
using PistolGame.Code.Core.UI.HUD;
using PistolGame.Code.Core.UI.MainMenu;
using PistolGame.Code.Data.StaticData.Weapons;
using PistolGame.Code.Services.Assets;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.StaticData;
using UnityEngine;

namespace PistolGame.Code.Services.Factories.UIFactory
{
    public class UIFactory : BaseFactory.BaseFactory, IUIFactory
    {
        private readonly IStaticData _staticData;
        private const string RootCanvasKey = "RootCanvas";

        public UIFactory(IStaticData staticData, IAssets assets, IEntityContainer entityContainer)
        : base(assets, entityContainer)
        {
            _staticData = staticData;
        }

        public async UniTask WarmUpPersistent()
        {
            await _assets.LoadPersistent<GameObject>(RootCanvasKey);
            await _assets.LoadPersistent<GameObject>(nameof(TopPanel));
        }

        public async UniTask WarmUpMainMenu()
        {
            await _assets.Load<GameObject>(nameof(MainMenu));
        }

        public async UniTask WarmUpGameplay()
        {
            await _assets.Load<GameObject>(nameof(PlayerInput));
            await _assets.Load<GameObject>(nameof(WeaponSwapPanel));
            await _assets.Load<GameObject>(nameof(WeaponSwapButton));
        }

        public async UniTask<GameObject> CreateRootCanvas() => await _assets.Instantiate<GameObject>(RootCanvasKey);

        public async UniTask<TopPanel> CreateTopPanel(Transform rootCanvas) => await InstantiateAsRegistered<TopPanel>(rootCanvas);

        public async UniTask<IPlayerInput> CreatePlayerInput(Transform rootCanvas)
        {
            IPlayerInput playerInput = await Instantiate<PlayerInput>(rootCanvas);
            _entityContainer.RegisterEntity<IPlayerInput>(playerInput);
            return playerInput;
        }

        public async UniTask<WeaponSwapPanel> CreateWeaponSwapPanel(Transform rootCanvas)
        {
            WeaponSwapPanel weaponSwapPanel = await InstantiateAsRegistered<WeaponSwapPanel>(rootCanvas);
            weaponSwapPanel.Construct(await CreateWeaponSwapButtons(weaponSwapPanel.Layout));
            return weaponSwapPanel;
        }

        private async UniTask<WeaponSwapButton[]> CreateWeaponSwapButtons(Transform layout)
        {
            WeaponData[] weapons = _staticData.PlayerConfiguration.Weapons;
            WeaponSwapButton[] swapButtons = new WeaponSwapButton[weapons.Length];

            for (int i = 0; i < weapons.Length; i++)
            {
                WeaponSwapButton swapButton = await Instantiate<WeaponSwapButton>(layout);
                swapButton.Construct(weapons[i].ButtonView, i);
                swapButtons[i] = swapButton;
            }

            return swapButtons;
        }
    }
}