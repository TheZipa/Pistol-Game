using PistolGame.Code.Core.UI.HUD;
using UnityEngine;

namespace PistolGame.Code.Core.Player.Movement
{
    public abstract class PlayerMovement : MonoBehaviour
    {
        protected IPlayerInput _playerInput;
        protected Player _player;
        protected float _speed;
        
        public void Construct(Player player, IPlayerInput playerInput, float speed)
        {
            _playerInput = playerInput;
            _player = player;
            _speed = speed;
        }
    }
}