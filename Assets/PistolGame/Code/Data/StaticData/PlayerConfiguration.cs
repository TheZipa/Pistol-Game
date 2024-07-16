using PistolGame.Code.Data.StaticData.Weapons;
using UnityEngine;

namespace PistolGame.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "StaticData/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        public float MovementSpeed;
        public LayerMask TargetsMask;
        [Header("Weapons")] 
        public WeaponData[] Weapons;
    }
}