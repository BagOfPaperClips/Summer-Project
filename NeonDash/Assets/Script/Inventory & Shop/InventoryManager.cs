using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public int currency;
    public TMP_Text currencyText;

    private void Start()
    {
        foreach (var slot in itemSlots)
            {
                slot.UpdateUI();
            }
    }

    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }

    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }

    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isCurrency)
        {
            currency += quantity;
            currencyText.text = currency.ToString();
            return;
        }
        else 
        {
            foreach (var slot in itemSlots)
            {
                if (slot.itemSO == null)
                {
                    slot.itemSO = itemSO;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
                
            }
        }
    }

    public void UseItem(InventorySlot slot)
    {
        if (slot.itemSO != null && slot.quantity >= 0)
        {
            Debug.Log("Trying to use item: " + slot.itemSO.itemName);
        }
    }
}
