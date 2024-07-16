using PistolGame.Code.Data.StaticData.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace PistolGame.Code.Core.Player.Weapons.Bullets
{
    public abstract class WeaponBullet : MonoBehaviour
    {
        public UnityEvent OnLifetimeEnd;
        public UnityEvent<Transform> OnHit;
        protected WeaponBulletData _bulletData;
        private float _currentLifetime; 

        public void Construct(WeaponBulletData bulletData)
        {
            _bulletData = bulletData;
            Hide();
        }

        public abstract void Release(Vector2 direction);

        public void Show()
        {
            _currentLifetime = 0;
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);

        private void OnCollisionEnter2D(Collision2D other) => OnHit?.Invoke(other.transform);

        private void Update()
        {
            _currentLifetime += Time.deltaTime;
            if(_currentLifetime >= _bulletData.Lifetime) OnLifetimeEnd?.Invoke();
        }
    }
}