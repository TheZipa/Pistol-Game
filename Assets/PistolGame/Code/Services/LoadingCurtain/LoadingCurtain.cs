using System.Collections;
using UnityEngine;

namespace PistolGame.Code.Services.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _curtain;

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }
        
        public void Hide()
        {
            if(gameObject.activeSelf) StartCoroutine(DoFadeIn());
        }

        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= Time.deltaTime * 3;
                yield return null;
            }
      
            gameObject.SetActive(false);
        }
    }
}