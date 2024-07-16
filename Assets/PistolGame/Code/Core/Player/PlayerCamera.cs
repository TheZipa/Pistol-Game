using Cinemachine;
using PistolGame.Code.Services.EntityContainer;
using UnityEngine;

namespace PistolGame.Code.Core.Player
{
    public class PlayerCamera : MonoBehaviour, IFactoryEntity
    {
        [SerializeField] private CinemachineVirtualCamera _playerCamera;

        public void Construct(Transform player) => _playerCamera.Follow = _playerCamera.LookAt = player;
    }
}