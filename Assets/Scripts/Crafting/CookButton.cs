using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CookButton : MonoBehaviour, IComparer<Item>
{
    public CraftingUI crafting;
    public CookingBook recipes;
    public Item result;
    public InventoryUI inventory;
    public CraftingSlot additionalSlot;
    public GetTrigger trigger;

    public void FoundRecipe() 
    {
        Item[] tempList = new Item[crafting.crafting.craftingItems.Count];
        crafting.crafting.craftingItems.CopyTo(tempList);
        if(crafting.crafting.craftingItems.Count >= 1)
        {
            crafting.crafting.craftingItems.Sort(Compare);
            for (int i = 0; i < recipes.recipes.Count; i++)
            {
                recipes.recipes[i].recipe.Sort(Compare);
                if(Enumerable.SequenceEqual(crafting.crafting.craftingItems, recipes.recipes[i].recipe))
                {
                    Debug.Log("you have made " + recipes.recipes[i].result.name);
                    result = recipes.recipes[i].result;
                    crafting.crafting.craftingItems.Clear();
                    crafting.UpdateCrafting();
                    if(!inventory.inventory.Add(result))
                    {
                        additionalSlot.AddItem(result);
                    }
                    else
                    {
                        inventory.UpdateUI();
                    }
                    return;
                }
            }
            ResetList(tempList, crafting.crafting.craftingItems);
            result = null;
            Debug.Log("Cant find recipe");
        }
        else
        {
            Debug.Log("empty crafting");
        }
            
    }

    public int Compare(Item a, Item b)
    {
        return a.name.CompareTo(b.name);
    }

    private void ResetList(Item[] tempArray, List<Item> list)
    {
        for (int i = 0; i < tempArray.Length; i++)
        {
            list[i] = tempArray[i];
        }
    }

    
}
