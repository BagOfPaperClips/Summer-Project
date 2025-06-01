using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    [TextArea] public string itemDescription;
    public Sprite icon;

    public bool isCurrency;
    public int stackSize = 3;

    [Header("Stats")]
    public int currentHealth;
    public int maxHealth;
    public int movementSpeed;
    public int damage;
    public int lootDrops;

    [Header("For Temporary Items")]
    public float duration;
    public int dashCooldown;
    public int specialAttack;
    
}
