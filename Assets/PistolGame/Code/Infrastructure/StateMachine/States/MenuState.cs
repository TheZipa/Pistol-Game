using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.UI;
using PistolGame.Code.Core.UI.MainMenu;
using PistolGame.Code.Infrastructure.StateMachine.GameStateMachine;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.Factories.UIFactory;
using PistolGame.Code.Services.LoadingCurtain;
using PistolGame.Code.Services.SceneLoader;
using UnityEngine;

namespace PistolGame.Code.Infrastructure.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ISceneLoader _sceneLoader;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;

        private MainMenu _mainMenu;
        private TopPanel _topPanel;
        private const string MenuScene = "Menu";

        public MenuState(IGameStateMachine stateMachine, IUIFactory uiFactory,
            ISceneLoader sceneLoader, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter() => _sceneLoader.LoadScene(MenuScene, PrepareMenu);

        public void Exit()
        {
            _mainMenu.OnPlayClick.RemoveListener(LoadGame);
        }

        private async void PrepareMenu()
        {
            await CreateMenuElements();
            Subscribe();
            _loadingCurtain.Hide();
        }

        private async UniTask CreateMenuElements()
        {
            await _uiFactory.WarmUpMainMenu();
            GameObject rootCanvas = await _uiFactory.CreateRootCanvas();
            _topPanel = _entityContainer.GetEntity<TopPanel>();
            _topPanel.ToggleBackButton(false);
            _mainMenu =  await _uiFactory.InstantiateAsRegistered<MainMenu>(rootCanvas.transform);
        }

        private void Subscribe()
        {
            _mainMenu.OnPlayClick.AddListener(LoadGame);
        }

        private void LoadGame() => _stateMachine.Enter<LoadGameState>();
    }
}