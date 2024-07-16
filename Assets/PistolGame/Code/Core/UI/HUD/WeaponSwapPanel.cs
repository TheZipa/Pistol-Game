using System;
using PistolGame.Code.Services.EntityContainer;
using UnityEngine;

namespace PistolGame.Code.Core.UI.HUD
{
    public class WeaponSwapPanel : MonoBehaviour, IFactoryEntity
    {
        public event Action<int> OnWeaponSwap; 
        public Transform Layout;

        public void Construct(WeaponSwapButton[] swapButtons)
        {
            foreach (WeaponSwapButton swapButton in swapButtons) 
                swapButton.OnSwapClick += weaponId => OnWeaponSwap?.Invoke(weaponId);
        }
    }
}