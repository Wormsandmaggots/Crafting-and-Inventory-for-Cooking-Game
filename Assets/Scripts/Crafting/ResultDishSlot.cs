using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDishSlot : MonoBehaviour
{
    public InventoryUI inventory;
    public CraftingSlot additionalSlot;
    public GameObject craftingParent;
    public GameObject cookButton;

    private void Start() {
        additionalSlot = GetComponentInParent<CraftingSlot>();
    }

    void OnEnable() {
        if(inventory.inventory.items.Count < inventory.inventory.space)
        {
            inventory.inventory.Add(additionalSlot.item);
            inventory.UpdateUI();
            additionalSlot.ClearSlot();
            additionalSlot.gameObject.SetActive(false);
            craftingParent.SetActive(true);
            cookButton.SetActive(true);
        }
    }
}
