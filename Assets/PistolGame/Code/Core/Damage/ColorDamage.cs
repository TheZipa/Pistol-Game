using DG.Tweening;
using UnityEngine;

namespace PistolGame.Code.Core.Damage
{
    public class ColorDamage : IDamageble
    {
        private readonly SpriteRenderer _view;
        private readonly Color _damageColor;
        private readonly Color _initialColor;
        private Tween _damageTween;
        
        public ColorDamage(SpriteRenderer view, Color damageColor)
        {
            _view = view;
            _damageColor = damageColor;
            _initialColor = _view.color;
        }

        public void TakeDamage(int damage)
        {
            _damageTween?.Kill();
            _view.color = _damageColor;
            _damageTween = _view.DOColor(_initialColor, 0.75f);
        }
    }
}