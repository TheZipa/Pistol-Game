using PistolGame.Code.Core.Damage;

namespace PistolGame.Code.Core.LevelEntities.Enemies
{
    public class OrangeEnemy : Enemy
    {
        public override void Construct()
        {
            _damageBehaviour = new NoDamage();
        }
    }
}