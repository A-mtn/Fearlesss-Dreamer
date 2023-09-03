using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.MenuUI.Scripts
{
    public class HowToTutorialHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_Pages;
        [SerializeField] private GameObject m_GoNextButton;
        [SerializeField] private GameObject m_GoBackButton;
        
        private int m_CurrentPage = 0;

        public void goNext()
        {
            m_Pages[m_CurrentPage].SetActive(false);
            m_CurrentPage++;
            m_Pages[m_CurrentPage].SetActive(true);

            if (m_CurrentPage == m_Pages.Length-1)
            {
                m_GoNextButton.SetActive(false);
            }
            m_GoBackButton.SetActive(true);
        }

        public void goBack()
        {
            m_Pages[m_CurrentPage].SetActive(false);
            m_CurrentPage--;
            m_Pages[m_CurrentPage].SetActive(true);

            if (m_CurrentPage == 0)
            {
                m_GoBackButton.SetActive(false);
            }
            m_GoNextButton.SetActive(true);
        }

        public void closeUI()
        {
            gameObject.SetActive(false);
        }
    }
}