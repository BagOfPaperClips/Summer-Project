using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    [SerializeField] private ShopManager shopManager;

    private int price;

    public void Initialize(ItemSO newItemSO, int price) // accessing data in ItemSO scriptable object
    {
        // fill the slot with information
        itemSO = newItemSO;
        itemImage.sprite = itemSO.icon;
        itemNameText.text = itemSO.itemName;
        this.price = price; // this price is equal to the price we're passing in
        priceText.text = price.ToString(); // converts integer into a string

    }

    public void OnBuyButtonClicked()
    {
        shopManager.TryBuyItem(itemSO, price); // when this button is clicked, tells the shop manager which item they're trying to buy and its price
    }
}
