using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RemoveButton : MonoBehaviour
{
    private InventoryUI inventory;
    private CraftingUI crafting;
    private CraftingSlot slot;

    void Start() {
        slot = GetComponentInParent<CraftingSlot>();

        crafting = GameObject.Find("Crafting").GetComponent<CraftingUI>();
        inventory = GameObject.Find("Inventory").GetComponent<InventoryUI>();
    }

    public void RemoveItemFromCrafting()
    {
        int index = Array.IndexOf(crafting.craftingSlots, slot);
        inventory.inventory.Add(slot.item);
        crafting.crafting.RemoveItemFromCrafting(index);
        crafting.UpdateCrafting();
        inventory.UpdateUI();
    }
}
