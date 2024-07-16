using Cysharp.Threading.Tasks;
using PistolGame.Code.Core.Player.Weapons;
using PistolGame.Code.Services.Factories.BaseFactory;
using UnityEngine;

namespace PistolGame.Code.Services.Factories.WeaponsFactory
{
    public interface IWeaponsFactory : IBaseFactory, IGlobalService
    {
        UniTask WarmUp();
        UniTask<Weapon[]> CreateWeapons(Transform weaponLocation);
    }
}