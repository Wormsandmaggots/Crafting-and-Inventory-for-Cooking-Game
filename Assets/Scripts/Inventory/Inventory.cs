using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    #region Instance
    
    public static Inventory instance;
    void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one inventory");
            return;
        }

        instance = this;
    }
    #endregion

    public GameObject backpack;
    public GameObject UI;

    public InventoryUI inventoryUI;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 12;
    public List<Item> items = new List<Item>();
    public List<int> itemsAmount = new List<int>();
    
    void Update()
    {
        EscInventory();
    }

    public bool Add(Item item)
    {
        bool isInInventory = false;
        if(!item.isDefaultItem)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(item == items[i] && itemsAmount[i] < item.maxAmountInInventory)
                {
                    itemsAmount[i]++;
                    isInInventory = true;
                    break;
                }
            }

            if(items.Count >= space && !isInInventory)
            {
                Debug.Log("Not enough space");
                return false;
            }

            if(!isInInventory)
            {
                items.Add(item);
                itemsAmount.Add(1);
            }
                

            if(onItemChangedCallback != null) 
                onItemChangedCallback.Invoke();

        }
        return true;
    }

    public void Remove(int index)
    {
        items.RemoveAt(index);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public int SortInventory(int index)
    {
        int lastIndex = items.LastIndexOf(items[index]);

        if(lastIndex == index)
            return -1;

        return lastIndex;
    }

    #region AnimationInventory
    //turn on inventory turn off UI
    public void SetInventory()
    {
        if (Time.timeScale == 1 && !backpack.activeSelf)
        {
            UI.SetActive(false);
            backpack.SetActive(true);
        }
    }

    //turn off inventory turn on UI using Esc key
    private void EscInventory()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    //close inventory using exit button
    public void CloseInventory()
    {
        if (backpack.activeSelf)
        {
            backpack.SetActive(false);
            UI.SetActive(true);
            Time.timeScale = 1;
        }
    }
    #endregion
}
