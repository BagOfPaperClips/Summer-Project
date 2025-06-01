using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    [SerializeField] private ShopManager shopManager;
    [SerializeField] private ShopInfo shopInfo;

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

    public void OnPointerEnter(PointerEventData eventData) // defines what happens when the mouse enters this object
    {
        // ensures the panel doesn't turn on if there's no item in the shop slot
        if (itemSO != null)
            shopInfo.ShowItemInfo(itemSO);
    }

    public void OnPointerExit(PointerEventData eventData) // defines what happens when the mouse exits this object
    {
        shopInfo.HideItemInfo();
    }

    public void OnPointerMove(PointerEventData eventData) // moves shop panel with mouse
    {
        // makes sure the item the panel doesn't follow the mouse around if there's no item in the shop slot
        if (itemSO != null)
            shopInfo.FollowMouse();
    }
}
