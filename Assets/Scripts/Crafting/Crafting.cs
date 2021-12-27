using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    #region  CraftingInstance
    public static Crafting instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory");
            return;
        }

        instance = this;
    }
    #endregion
    public List<Item> craftingItems = new List<Item>();

    public int space = 4;

    public void AddItemToCrafting(Item item)
    {
        if(craftingItems.Count >= space)
            return;

        craftingItems.Add(item);
    }

    public void RemoveItemFromCrafting(int index)
    {
        craftingItems.Remove(craftingItems[index]);
    }
}
