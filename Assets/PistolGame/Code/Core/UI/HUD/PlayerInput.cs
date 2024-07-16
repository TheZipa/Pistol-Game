using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PistolGame.Code.Core.UI.HUD
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        public UnityEvent OnShootClick => _shootButton.onClick;
        public Vector2 MoveDirection => _joystick.Direction;
        
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _shootButton;
        
        public void Enable()
        {
            _joystick.Enable();
            _shootButton.interactable = true;
        }

        public void Disable()
        {
            _joystick.Disable();
            _shootButton.interactable = false;
        }
    }
}