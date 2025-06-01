using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    public CanvasGroup infoPanel; // reference to canvas group in infopopup gameobject within shop canvas

    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    [Header("Stat Fields")]
    public TMP_Text[] statTexts; // easier stat line customization

    private RectTransform infoPanelRect; // controls position, size and other aspects of UI elements

    private void Awake()
    {
        infoPanelRect = GetComponent<RectTransform>();
    }

    public void ShowItemInfo(ItemSO itemSO) // displays item info
    {
        infoPanel.alpha = 1;

        itemNameText.text = itemSO.itemName;
        itemDescriptionText.text = itemSO.itemDescription;

        List<string> stats = new List<string>();
        if (itemSO.currentHealth > 0) stats.Add("Health: " + itemSO.currentHealth.ToString());
        if (itemSO.dashCooldown > 0) stats.Add("Dash Cooldown: " + itemSO.dashCooldown.ToString());

        if (stats.Count <= 0)
            return;

        for (int i = 0; i < statTexts.Length; i++)
        {
            if (i < stats.Count)
            {
                statTexts[i].text = stats[i];
                statTexts[i].gameObject.SetActive(true);
            }
            else
            {
                statTexts[i].gameObject.SetActive(false);
            }
        }
    }

    public void HideItemInfo() // hides the panel
    {
        infoPanel.alpha = 0;

        itemNameText.text = "";
        itemDescriptionText.text = "";
    }

    public void FollowMouse() // makes the panel follow the mouse
    {
        Vector3 mousePosition = Input.mousePosition; // finds current position of mouse
        Vector3 offset = new Vector3(10, -10, 0); // offsets position of panel to not be at the mouse's exact position

        infoPanelRect.position = mousePosition + offset;
    }
}
