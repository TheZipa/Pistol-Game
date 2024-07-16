using UnityEngine;

namespace PistolGame.Code.Core.LevelEntities.Enemies
{
    public abstract class Enemy : LevelEntity
    {
        [SerializeField] protected SpriteRenderer _view;
    }
}