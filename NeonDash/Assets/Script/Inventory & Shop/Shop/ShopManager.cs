using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    // allows everything shop-related to work, including populating the shop slots with items and running the buying and selling
    public static event Action<ShopManager, bool> OnShopStateChanged; // shop manager sends out a message to any listeners so that it knows which shop has been opened or closed

    [SerializeField] private List<ShopItems> shopItems; // list is dynamic, can add and remove items while the game is running

    [SerializeField] private ShopSlot[] shopSlots; // arrays can't have the number of items in it changed at runtime, but it's easy to use for groups that will stay the same size and editing in the inspector 

    [SerializeField] private InventoryManager inventoryManager;

    private void Start()
    {
        PopulateShopItems();
        OnShopStateChanged?.Invoke(this, true); // ?.Invoke checks if there are listeners before sending out the message
    }

    public void PopulateShopItems()
    {
        for (int i = 0; i < shopItems.Count && i < shopSlots.Length; i++)
        {
            ShopItems shopItem = shopItems[i]; // the current item being loaded into the shop
            shopSlots[i].Initialize(shopItem.itemSO, shopItem.price);
            shopSlots[i].gameObject.SetActive(true);
        }

        // turn of shop slots that are not being used
        for (int i = shopItems.Count; i < shopSlots.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(false);
        }
    }

    public void TryBuyItem(ItemSO itemSO, int price)
    {
        if (itemSO != null && inventoryManager.currency >= price) // makes sure an item scriptable object was actually passed in and if the player has enough money to buy the item
        {
            if (HasSpaceForItem(itemSO)) // checks if inventory manager has enough space for the item being purchased
            {
                inventoryManager.currency -= price;
                inventoryManager.currencyText.text = inventoryManager.currency.ToString();
                inventoryManager.AddItem(itemSO, 1);
            }
        }
    }

    private bool HasSpaceForItem(ItemSO itemSO)
    {
        foreach (var slot in inventoryManager.itemSlots) // loops through every slot in the inventory manager 
        {
            if (slot.itemSO == itemSO && slot.quantity < itemSO.stackSize) // checks if a slot already contains the same item and if that slot's quantity is less than the max stack size of the item
                return true;
            else if (slot.itemSO == null) // if there are no slots that already contain the same item but still have room for more new items to be added to an empty slot
                return true;
        }
        return false; // don't have any inventory slot with the same item that still have room and don't have any other empty slot for a new item to be added
    }
}

[System.Serializable] // gives access to system namespace, same thing as adding "using System" at the top of the script
public class ShopItems
{
    public ItemSO itemSO;
    public int price;
}