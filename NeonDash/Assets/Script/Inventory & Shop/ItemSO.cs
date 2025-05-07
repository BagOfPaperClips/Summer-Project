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

    [Header("Stats")]
    public int currentHealth;
    public int movementSpeed;
    public int damage;
    public int dashCooldown;
    public int lootDrops;
    public int specialAttack;

    [Header("For Temporary Items")]
    public float duration;
    
}
