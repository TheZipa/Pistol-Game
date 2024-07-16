using PistolGame.Code.Core.UI.HUD;
using UnityEngine;

namespace PistolGame.Code.Core.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private Player _player;
        private IPlayerInput _playerInput;
        private Vector2 _moveDirection;
        private Vector2 _smoothedMovementInput;
        private Vector2 _movementInputSmoothVelocity;
        private float _speed;
        
        public void Construct(Player player, IPlayerInput playerInput, float speed)
        {
            _playerInput = playerInput;
            _player = player;
            _speed = speed;
        }

        private void Update()
        {
            _moveDirection = _playerInput.MoveDirection;
        }

        private void FixedUpdate()
        {
            _smoothedMovementInput = GetSmoothInput();
            _player.Rigidbody2D.velocity = _smoothedMovementInput * (_speed * Time.fixedDeltaTime);
        }

        private Vector2 GetSmoothInput() => Vector2.SmoothDamp(
            _smoothedMovementInput,
            _moveDirection,
            ref _movementInputSmoothVelocity,
            0.1f);
    }
}