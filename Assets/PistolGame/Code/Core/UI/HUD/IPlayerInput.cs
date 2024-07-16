using PistolGame.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.Events;

namespace PistolGame.Code.Core.UI.HUD
{
    public interface IPlayerInput : IFactoryEntity
    {
        Vector2 MoveDirection { get; }
        UnityEvent OnShootClick { get; }
        void Enable();
        void Disable();
    }
}