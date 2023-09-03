using System;
using StatSystem;
using StatSystem.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainMenu.UpgradeSystem.Scripts
{
    public class UpgradesUIHandler : MonoBehaviour
    {
        [SerializeField] private CharacterStats m_CharacterStats;
        public int money = 100;

        [SerializeField] private float m_CostMultiplier = 0.5f;
        [SerializeField] private TMP_Text m_CurrencyHolder;
        [SerializeField] private Button[] m_UpgradeButtons;

        
        private void Start()
        {
            m_CurrencyHolder.text = money.ToString(); //GameManager.Instance.Money.ToString();
            foreach (CharacterStats.StatItem stat in m_CharacterStats.stats)
            {
                m_UpgradeButtons[stat.ID].GetComponentInChildren<TMP_Text>().text = 
                    Mathf.RoundToInt(CalculateCost(stat.statLevel, stat.baseCost)).ToString();
                for (int i = 0; i < stat.statLevel; i++)
                {
                    m_UpgradeButtons[stat.ID].GetComponentInChildren<StarFiller>().AddStar(i+1);
                }
            }
            
            /*foreach (CharacterStats.StatItem stat in m_CharacterStats.stats)
            {

                if (stat.ID == 0)//health
                {
                    GameManager.Instance.MovementSpeed = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
                else if (stat.ID == 1)
                {
                    GameManager.Instance.Health = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
                else if (stat.ID == 2)
                {
                    GameManager.Instance.Damage = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
                else if (stat.ID == 3)
                {
                    GameManager.Instance.Throw = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
                else if (stat.ID == 4)
                {
                    GameManager.Instance.WeaponChargeSpeed = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
                else if (stat.ID == 5)
                {
                    GameManager.Instance.AbilityArea = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
                else if (stat.ID == 6)
                {
                    GameManager.Instance.AbilityDamage = calculateValue(stat.baseValue, stat.valueMultiplier);
                }
            }*/
        }

        /*private float calculateValue(int baseValue, float multiplier)
        {
            return baseValue + 2 * multiplier;
        }*/

        public void Test(int i)
        {
            foreach (CharacterStats.StatItem stat in m_CharacterStats.stats)
            {
                if (stat.ID != i) continue;

                var cost = Mathf.RoundToInt(CalculateCost(stat.statLevel, stat.baseCost));
                Debug.Log("cost of " + stat.statName + " is: " + cost);
                var left = money - cost;
                if (left < 0)
                {
                    Debug.LogWarning("You don't have enough money to buy this! Missing: " + (-1 * left));
                    return;
                }
            
                money -= cost;
                m_CurrencyHolder.text = money.ToString();//GameManager.Instance.Money.ToString();
                stat.statLevel++;
                var button = EventSystem.current.currentSelectedGameObject;
                //button.GetComponentInChildren<TMP_Text>().text = stat.statLevel.ToString();
                button.GetComponentInChildren<StarFiller>().AddStar(stat.statLevel);
            }
            
        }

        private float CalculateCost(int level, int baseCost)
        {
            return (baseCost * (level + 1)) + (m_CostMultiplier * level);
        }
        
        
    }
}