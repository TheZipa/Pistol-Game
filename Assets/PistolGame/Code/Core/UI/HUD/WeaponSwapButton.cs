using System;
using UnityEngine;
using UnityEngine.UI;

namespace PistolGame.Code.Core.UI.HUD
{
    public class WeaponSwapButton : MonoBehaviour
    {
        public event Action<int> OnSwapClick;
        [SerializeField] private Button _swapButton;
        [SerializeField] private Image _weaponIcon;

        public void Construct(Sprite weaponView, int weaponId)
        {
            _weaponIcon.sprite = weaponView;
            _swapButton.onClick.AddListener(() => OnSwapClick?.Invoke(weaponId));
        }
    }
}