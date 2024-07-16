using PistolGame.Code.Core.Damage;
using UnityEngine;

namespace PistolGame.Code.Core.LevelEntities
{
    public abstract class LevelEntity : MonoBehaviour, IDamageble
    {
        [SerializeField] protected Collider2D _collider;
        protected IDamageble _damageBehaviour;

        public abstract void Construct();

        public virtual void TakeDamage(int damage)
        {
            _damageBehaviour.TakeDamage(damage);
            Debug.Log("Received damage: " + damage);
        }
    }
}