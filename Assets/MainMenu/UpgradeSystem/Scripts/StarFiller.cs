using UnityEngine;

namespace MainMenu.UpgradeSystem.Scripts
{
    public class StarFiller : MonoBehaviour
    {
        [SerializeField] private GameObject m_starImage;
        private float m_offSet = 25f;
        public void AddStar(int level)
        {
            GameObject newStar = Instantiate(m_starImage, transform);
            newStar.GetComponent<RectTransform>().anchoredPosition = new Vector3(m_offSet * (level - 1) + 8.6f, -55f, 0);
        }
    }
}