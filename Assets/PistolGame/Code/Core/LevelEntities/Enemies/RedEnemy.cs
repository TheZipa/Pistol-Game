using PistolGame.Code.Core.Damage;
using UnityEngine;

namespace PistolGame.Code.Core.LevelEntities.Enemies
{
    public class RedEnemy : Enemy
    {
        public override void Construct()
        {
            _damageBehaviour = new ColorDamage(_view, Color.white);
        }
    }
}