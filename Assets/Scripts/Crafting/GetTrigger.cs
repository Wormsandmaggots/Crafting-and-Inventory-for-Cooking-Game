using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrigger : MonoBehaviour
{
    public bool isTriggerOn = false;
    public ShowCrafting showCrafting;
    public CraftingUI crafting;
    public Inventory inventory;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
            isTriggerOn = true;
    }
    void OnTriggerExit2D(Collider2D other) {

        if(other.tag == "Player")
            isTriggerOn = false;
        if(showCrafting.IsCraftingCanvasActive())
        {
            showCrafting.SetCrafting(false);
        }

        ClearCrafting();
    }
    public void ClearCrafting()
    {
        if(crafting == null || crafting.crafting == null)
            return;

        if (crafting.crafting.craftingItems.Count > 0)
        {
            for (int i = 0; i < crafting.crafting.craftingItems.Count; i++)
            {
                inventory.Add(crafting.crafting.craftingItems[i]);
            }
            crafting.crafting.craftingItems.Clear();
            crafting.UpdateCrafting();
        }
    }
}
