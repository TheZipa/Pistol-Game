using UnityEngine;

namespace PistolGame.Code.Core.Damage
{
    public abstract class Damage : MonoBehaviour
    {
        public abstract void TakeDamage(int damage);
    }
}