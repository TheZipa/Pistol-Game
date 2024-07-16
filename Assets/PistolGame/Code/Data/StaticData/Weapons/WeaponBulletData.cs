using System;

namespace PistolGame.Code.Data.StaticData.Weapons
{
    [Serializable]
    public class WeaponBulletData
    {
        public float Speed;
        public float Lifetime;
        public string BulletPrefabName;
    }
}