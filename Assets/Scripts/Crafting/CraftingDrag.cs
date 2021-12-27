using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CraftingDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private InventorySlot slot;
    private RectTransform imagePosition;
    private Vector3 startPosition;
    private RectTransform crafting;
    private CraftingUI craftingUI;
    private InventoryUI inventory;

    private MosueOverCrafting mouseOver;

    public GameObject additionalSlot;

    void Start() {
        slot = GetComponentInParent<InventorySlot>();
        inventory = GetComponentInParent<InventoryUI>();
        imagePosition = GetComponent<RectTransform>();

        startPosition = imagePosition.anchoredPosition;

        craftingUI = GameObject.Find("Crafting").GetComponent<CraftingUI>();
        crafting = GameObject.Find("Crafting").GetComponent<RectTransform>();
        mouseOver = GameObject.Find("OnMouseOver").GetComponent<MosueOverCrafting>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        imagePosition.anchoredPosition = startPosition;

        
        if (mouseOver.IsPoiterOverCrafting() && craftingUI.crafting.craftingItems.Count < 4 && !additionalSlot.activeSelf)
        {
            craftingUI.crafting.AddItemToCrafting(slot.item);
            int index = Array.IndexOf(inventory.slots, slot);
            inventory.inventory.itemsAmount[index] -= 1;
            if(inventory.inventory.itemsAmount[index] <= 0)
            {
                inventory.inventory.itemsAmount.RemoveAt(index);
                inventory.inventory.items.RemoveAt(index);
            }
            inventory.UpdateUI();
            craftingUI.UpdateCrafting();
        }
        else
            Debug.Log("item wasnt dropped on inventory or inventory was full");
    }

    
}
