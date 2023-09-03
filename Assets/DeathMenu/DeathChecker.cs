using System;
using System.Collections;
using System.Collections.Generic;
using EnemySystem.Scripts;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private GameObject m_DeathMenu;
    private PlayerHealth m_PlayerHealth;
    private IDamageable playerDamageable;
    private void Start()
    {
        m_PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        m_PlayerHealth.healthChanged += HealthChanged;
    }

    private void HealthChanged()
    {
        if (m_PlayerHealth.health <= 0)
        {
            m_DeathMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
