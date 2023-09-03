using UnityEngine;

namespace StatSystem.Scripts
{
    [CreateAssetMenu(fileName = "CharacterStats", menuName = "StatSystem/Character Stats")]
    public class CharacterStats : ScriptableObject
    {
        [System.Serializable]
        public class StatItem
        {
            public string statName;
            public int ID;
            public int statLevel;
            public int baseCost;
            public int costMultiplier;
            public int baseValue;
            public float valueMultiplier;
        }
    
        public StatItem[] stats;
    }
}