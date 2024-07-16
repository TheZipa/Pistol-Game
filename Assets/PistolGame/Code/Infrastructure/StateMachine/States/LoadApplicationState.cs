using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.UI;
using PistolGame.Code.Infrastructure.StateMachine.GameStateMachine;
using PistolGame.Code.Services.Factories.UIFactory;
using PistolGame.Code.Services.LoadingCurtain;
using UnityEngine;

namespace PistolGame.Code.Infrastructure.StateMachine.States
{
    public class LoadApplicationState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ILoadingCurtain _loadingCurtain;

        public LoadApplicationState(IGameStateMachine gameStateMachine,
            IUIFactory uiFactory, ILoadingCurtain loadingCurtain)
        {
            _uiFactory = uiFactory;
            _loadingCurtain = loadingCurtain;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void Enter()
        {
            await CreatePersistentEntities();
            _gameStateMachine.Enter<MenuState>();
            Application.targetFrameRate = 90;
        }

        public void Exit()
        {
        }

        private async UniTask CreatePersistentEntities()
        {
            await _uiFactory.WarmUpPersistent();
            GameObject persistentCanvas = await CreatePersistentCanvas();
            TopPanel topPanel = await _uiFactory.CreateTopPanel(persistentCanvas.transform);
            topPanel.SetBackAction(() =>
            {
                _loadingCurtain.Show();
                _gameStateMachine.Enter<MenuState>();
            });
        }

        private async UniTask<GameObject> CreatePersistentCanvas()
        {
            GameObject persistentCanvas = await _uiFactory.CreateRootCanvas();
            persistentCanvas.GetComponent<Canvas>().sortingOrder = 10;
            persistentCanvas.name = "PersistentCanvas";
            Object.DontDestroyOnLoad(persistentCanvas);
            return persistentCanvas;
        }
    }
}