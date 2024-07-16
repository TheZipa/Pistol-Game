using PistolGame.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PistolGame.Code.Core.UI.MainMenu
{
    public class MainMenu : MonoBehaviour, IFactoryEntity
    {
        public UnityEvent OnPlayClick => _playButton.onClick;

        [SerializeField] private Button _playButton;
    }
}