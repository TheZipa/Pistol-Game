using UnityEngine;

namespace PistolGame.Code.Core.LevelEntities.Obstacles
{
    public abstract class Obstacle : LevelEntity
    {
        [SerializeField] protected Rigidbody2D _rigidbody2D;
    }
}