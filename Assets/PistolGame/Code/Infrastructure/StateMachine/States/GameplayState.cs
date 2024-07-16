using PistolGame.Code.Core.Player;
using PistolGame.Code.Core.UI.HUD;
using PistolGame.Code.Infrastructure.StateMachine.GameStateMachine;
using PistolGame.Code.Services.EntityContainer;
using PistolGame.Code.Services.LoadingCurtain;

namespace PistolGame.Code.Infrastructure.StateMachine.States
{
    public class GameplayState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IEntityContainer _entityContainer;
        private readonly ILoadingCurtain _loadingCurtain;

        private WeaponSwapPanel _weaponSwapPanel;
        private IPlayerInput _playerInput;
        private Player _player;

        public GameplayState(IGameStateMachine gameStateMachine, IEntityContainer entityContainer, ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _entityContainer = entityContainer;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            _loadingCurtain.Hide();
            CacheEntities();
            Subscribe();
            _playerInput.Enable();
        }

        public void Exit()
        {
            _playerInput.Disable();
            _weaponSwapPanel.OnWeaponSwap -= _player.SwapWeapon;
            _playerInput.OnShootClick.RemoveListener(_player.Shoot);
        }

        private void CacheEntities()
        {
            _weaponSwapPanel = _entityContainer.GetEntity<WeaponSwapPanel>();
            _playerInput = _entityContainer.GetEntity<IPlayerInput>();
            _player = _entityContainer.GetEntity<Player>();
        }

        private void Subscribe()
        {
            _weaponSwapPanel.OnWeaponSwap += _player.SwapWeapon;
            _playerInput.OnShootClick.AddListener(_player.Shoot);
        }
    }
}