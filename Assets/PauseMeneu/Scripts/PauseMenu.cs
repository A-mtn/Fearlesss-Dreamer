namespace PauseMeneu.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject m_PauseMenu;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        
        }
        public void Resume()
        {
            m_PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}