using DG.Tweening;
using UnityEngine;

namespace PistolGame.Code.Core.Damage
{
    public class ShakeDamage : Damage
    {
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;
        private Tween _shakeTween;
        
        public override void TakeDamage(int damage)
        {
            _shakeTween?.Kill();
            _shakeTween = transform.DOShakePosition(_shakeDuration, _shakeStrength);
        }
    }
}