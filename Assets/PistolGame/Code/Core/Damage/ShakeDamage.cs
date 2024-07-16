using DG.Tweening;
using UnityEngine;

namespace PistolGame.Code.Core.Damage
{
    public class ShakeDamage : IDamageble
    {
        private readonly Transform _transform;
        private Tween _shakeTween;

        public ShakeDamage(Transform transform)
        {
            _transform = transform;
        }
        
        public void TakeDamage(int damage)
        {
            _shakeTween?.Kill();
            _shakeTween = _transform.DOShakePosition(0.5f, 0.25f);
        }
    }
}