using System;
using PistolGame.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.UI;

namespace PistolGame.Code.Core.UI
{
    public class TopPanel : MonoBehaviour, IFactoryEntity
    {
        [SerializeField] private Button _backButton;
        private Action _backClickAction;

        private void Awake() => _backButton.onClick.AddListener(() => _backClickAction?.Invoke());
        
        public void SetBackAction(Action backClickAction) => _backClickAction = backClickAction;
        
        public void ToggleBackButton(bool isEnabled) => _backButton.gameObject.SetActive(isEnabled);
    }
}