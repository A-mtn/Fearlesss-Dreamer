using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu.MenuUI.Scripts
{
    public class MenuUIHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_mainLookCamera;
        [SerializeField] private CinemachineVirtualCamera m_upgradesUICamera;
        [SerializeField] private Button m_HowToPlayButton;
        [SerializeField] private GameObject m_HowToPlayUI;
        
        private Transform m_OriginalHTPBTransform;
        private Tween m_Tween;
        
        private void Start()
        { 
            m_OriginalHTPBTransform = m_HowToPlayButton.transform;
            m_Tween = m_HowToPlayButton.transform.DOScale(1.6f, .5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetAutoKill(false);
        }

        public void ShowHowToPlayUI()
        {
            Debug.Log("finish it!");
            m_Tween.Kill(true);
            m_HowToPlayButton.transform.localScale = Vector3.one;
            m_HowToPlayUI.SetActive(true);
        }

        public void CloseHowToPlayUI()
        {
            m_HowToPlayUI.SetActive(false);
        }

        public void SwitchToUpgradesUI()
        {
            m_upgradesUICamera.Priority += 5;
        }

        public void SwitchToMainLook()
        {
            m_upgradesUICamera.Priority -= 5;
        }
    
        public void Sleep()
        {
            SceneManager.LoadScene("Game");
        }

        public void CloseGame()
        {
            Application.Quit();
        }
        
    }
}