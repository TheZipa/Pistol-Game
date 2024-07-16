using PistolGame.Code.Core.Player.Movement;
using PistolGame.Code.Core.Player.Weapons;
using PistolGame.Code.Services.EntityContainer;
using UnityEngine;

namespace PistolGame.Code.Core.Player
{
    public class Player : MonoBehaviour, IFactoryEntity
    {
        public SpriteRenderer View => _view;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public PlayerWeapon Weapon => _weapon;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _view;
        [SerializeField] private PlayerWeapon _weapon;
        [SerializeField] private PlayerCrosshair _crosshair;
        private PlayerMovement _movement;
        private Transform _lookEnemy;

        public void Construct(PlayerMovement movement, Weapon[] weapons)
        {
            _movement = movement;
            _weapon.Construct(weapons);
        }

        public void SwapWeapon(int weaponId) => _weapon.SwapWeapon(weaponId);

        public void Shoot() => _weapon.Shoot(GetTargetDirection());

        public void SetFocusEnemy(Transform lookEnemy)
        {
            _lookEnemy = lookEnemy;
            _crosshair.Aim(_lookEnemy);
        }

        private void FixedUpdate() => RotateToEnemy();

        private void RotateToEnemy()
        {
            if (_lookEnemy is null) return;
            Vector2 direction = GetTargetDirection();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }

        private Vector3 GetTargetDirection() => (_lookEnemy.position - transform.position).normalized;
    }
}