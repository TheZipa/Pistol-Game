using UnityEngine;

namespace PistolGame.Code.Core.LevelEntities
{
    public abstract class LevelEntity : MonoBehaviour
    {
        [SerializeField] protected Collider2D _collider;
        [SerializeField] protected Damage.Damage _damageBehaviour;

        public abstract void Construct();

        public virtual void TakeDamage(int damage)
        {
            _damageBehaviour.TakeDamage(damage);
            Debug.Log("Received damage: " + damage);
        }
    }
}