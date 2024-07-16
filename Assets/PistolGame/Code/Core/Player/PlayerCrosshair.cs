using UnityEngine;

namespace PistolGame.Code.Core.Player
{
    public class PlayerCrosshair : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _crosshair;

        public void Aim(Transform target)
        {
            _crosshair.transform.SetParent(target);
            _crosshair.transform.position = target.transform.position;
        }
    }
}