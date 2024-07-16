using UnityEngine;

namespace PistolGame.Code.Data.StaticData.Weapons
{
    [CreateAssetMenu(fileName = "ShotgunWeaponData", menuName = "StaticData/Weapons/ShotgunWeaponData")]
    public class ShotgunWeaponData : WeaponData
    {
        public float SpreadAngle;
        public int BulletsPerShoot;
    }
}