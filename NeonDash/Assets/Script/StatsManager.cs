using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public TMP_Text healthText;

    [Header ("Combat Stats")]
    public int damage;
    public bool specialAttack;
    
    [Header("Movement Stats")]
    public int movementSpeed;
    public bool dashCooldown;

    [Header("Health Stats")]
    public int currentHealth;
    public int maxHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

        public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }

        public void UpdateMovementSpeed(int amount)
    {
        movementSpeed += amount;
    }

}
