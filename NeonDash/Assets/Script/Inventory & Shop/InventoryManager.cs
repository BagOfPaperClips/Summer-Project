using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public int currency;
    public TMP_Text currencyText;
    public GameObject lootPrefab;
    public Transform player;

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

        foreach (var slot in itemSlots) // It is the SAME item AND there is ROOM left
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.stackSize)
            {
                int availableSpace = itemSO.stackSize - slot.quantity;
                int amountToAdd = Mathf.Min(availableSpace, quantity);

                slot.quantity += amountToAdd;
                quantity -= amountToAdd;

                slot.UpdateUI();

                if (quantity <= 0)
                    return;
            }
        }

        foreach (var slot in itemSlots) // If items remain we will now look at the empty slots
        {
            if (slot.itemSO == null)
            {
                int amountToAdd = Mathf.Min(itemSO.stackSize, quantity);
                slot.itemSO = itemSO;
                slot.quantity = quantity;
                slot.UpdateUI();
                return;
            }
        }

        if (quantity > 0)
            DropLoot(itemSO, quantity);
    }

    public void DropItem(InventorySlot slot)
    {
        DropLoot(slot.itemSO, 1);
        slot.quantity--;
        if(slot.quantity <=0)
        {
            slot.itemSO = null;
        }
        slot.UpdateUI();
    }

    private void DropLoot(ItemSO itemSO, int quantity)
    {
        Loot loot = Instantiate(lootPrefab, player.position, Quaternion.identity).GetComponent<Loot>();
        loot.Initialize(itemSO, quantity);
    }

    public void UseItem(InventorySlot slot)
    {
        if (slot.itemSO != null && slot.quantity >= 0)
        {
            Debug.Log("Trying to use item: " + slot.itemSO.itemName);
        }
    }
}
