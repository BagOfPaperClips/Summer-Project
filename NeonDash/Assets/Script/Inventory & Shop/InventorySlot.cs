using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public int quantity;
    public bool activeShop;

    public Image itemImage;
    public TMP_Text quantityText;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GetComponentInParent<InventoryManager>();
    }

    private void OnEnable()
    {
        ShopKeeper.OnShopStateChanged += HandleShopStateChanged;
    }

    private void OnDisable()
    {
        ShopKeeper.OnShopStateChanged -= HandleShopStateChanged;
    }

    private void HandleShopStateChanged(ShopManager shopManager, bool isOpen)
    {
        activeShop = isOpen ? shopManager : null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (quantity > 0)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                inventoryManager.UseItem(this);
            }

            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                inventoryManager.DropItem(this);
            }
        }
    }

    public void UpdateUI()
    {
        if (itemSO != null)
        {
            itemImage.sprite = itemSO.icon;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
}
