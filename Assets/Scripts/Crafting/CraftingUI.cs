using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    public CraftingSlot[] craftingSlots;
    public Crafting crafting;
    void Awake() {
        craftingSlots = GetComponentsInChildren<CraftingSlot>();
        crafting = Crafting.instance;
    }

    public void UpdateCrafting()
    {
        for (int i = 0; i < craftingSlots.Length; i++)   {
            
            if(i < crafting.craftingItems.Count)
            {
                craftingSlots[i].AddItem(crafting.craftingItems[i]);
            }
            else
            {
                craftingSlots[i].ClearSlot();
            }
        }
    }
}
