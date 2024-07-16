using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.UI;
using PistolGame.Code.Infrastructure.StateMachine.GameStateMachine;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.Factories.LevelEntityFactory;
using PistolGame.Code.Services.Factories.PlayerFactory;
using PistolGame.Code.Services.Factories.UIFactory;
using PistolGame.Code.Services.LoadingCurtain;
using PistolGame.Code.Services.SceneLoader;
using UnityEngine;

namespace PistolGame.Code.Infrastructure.StateMachine.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerFactory _playerFactory;
        private readonly ILevelEntityFactory _levelEntityFactory;
        private readonly IEntityContainer _entityContainer;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private const string GameScene = "Game";

        public LoadGameState(IGameStateMachine gameStateMachine, IUIFactory uiFactory, IPlayerFactory playerFactory,
            ILevelEntityFactory levelEntityFactory, IEntityContainer entityContainer, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _playerFactory = playerFactory;
            _levelEntityFactory = levelEntityFactory;
            _entityContainer = entityContainer;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(GameScene, CreateGame);
        }

        public void Exit()
        {
        }

        private async void CreateGame()
        {
            await InitializeUI();
            await InitializeGameplay();
            FinishLoad();
        }

        private async UniTask InitializeUI()
        {
            await _uiFactory.WarmUpGameplay();
            GameObject rootCanvas = await _uiFactory.CreateRootCanvas();
            await _uiFactory.CreatePlayerInput(rootCanvas.transform);
            await _uiFactory.CreateWeaponSwapPanel(rootCanvas.transform);
            _entityContainer.GetEntity<TopPanel>().ToggleBackButton(true);
        }

        private async UniTask InitializeGameplay()
        {
            await _levelEntityFactory.WarmUp();
            await _levelEntityFactory.CreateLevelEntities();
            await _playerFactory.WarmUp();
            await _playerFactory.CreatePlayer();
        }

        private void FinishLoad() => _gameStateMachine.Enter<GameplayState>();
    }
}