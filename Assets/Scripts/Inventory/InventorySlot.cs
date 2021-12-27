using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Text amountText;
    public bool isBeingDragged = false;

    public void AddItem(Item newItem, int amount)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        amountText.enabled = true;
        amountText.text = amount.ToString();
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        amountText.enabled = false;
        amountText.text = "0";
    }
    
}
