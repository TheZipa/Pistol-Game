using UnityEngine;

namespace PistolGame.Code.Data.StaticData.Weapons
{
    public class WeaponData : ScriptableObject
    {
        public Sprite ButtonView;
        public Sprite WorldView;
        public string PrefabName;
        [Space(12)]
        public int Damage;
        [Space(12)] 
        public WeaponBulletData BulletData;
    }
}