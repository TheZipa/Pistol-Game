using DG.Tweening;
using UnityEngine;

namespace PistolGame.Code.Core.Damage
{
    public class ColorDamage : Damage
    {
        [SerializeField] private SpriteRenderer _view;
        [SerializeField] private Color _damageColor;
        [SerializeField] private float _fadeDuration;
        private Color _initialColor;
        private Tween _damageTween;

        private void Awake()
        {
            _initialColor = _view.color;
        }

        public override void TakeDamage(int damage)
        {
            _damageTween?.Kill();
            _view.color = _damageColor;
            _damageTween = _view.DOColor(_initialColor, _fadeDuration);
        }
    }
}