using UnityEngine;

namespace PistolGame.Code.Core.Player.Weapons
{
    public class PlayerWeapon : MonoBehaviour
    {
        public Transform WeaponLocation => _weaponLocation;
        [SerializeField] private Transform _weaponLocation;
        
        private Weapon[] _weapons;
        private int _currentWeaponId;
        
        public void Construct(Weapon[] weapons)
        {
            _weapons = weapons;
            _weapons[_currentWeaponId].Show();
        }

        public void Shoot(Vector2 direction)
        {
            _weapons[_currentWeaponId].Shoot(direction);
        }

        public void SwapWeapon(int weaponId)
        {
            _weapons[_currentWeaponId].Hide();
            _currentWeaponId = weaponId;
            _weapons[_currentWeaponId].Show();
        }
    }
}