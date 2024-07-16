using PistolGame.Code.Core.Damage;

namespace PistolGame.Code.Core.LevelEntities.Obstacles
{
    public class BoxObstacle : Obstacle
    {
        public override void Construct()
        {
            _damageBehaviour = new ShakeDamage(transform);
        }
    }
}