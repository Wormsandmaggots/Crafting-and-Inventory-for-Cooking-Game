using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private InventorySlot inventorySlot;
    private Inventory inventoryLogic;
    private InventoryUI inventoryUI;
    public RectTransform inventory;
    private RectTransform imagePosition;
    private Vector3 startPosition;
    public GameObject itemsPrefab;
    public int index;


    void Start() {
        inventory = GameObject.Find("ItemsParent").GetComponent<RectTransform>();
        inventoryLogic = GameObject.Find("GameManager").GetComponent<Inventory>();
        inventoryUI = GameObject.Find("Inventory").GetComponent<InventoryUI>();

        inventorySlot = GetComponentInParent<InventorySlot>();
        imagePosition = GetComponent<RectTransform>();
        
        startPosition = imagePosition.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        inventorySlot.isBeingDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        imagePosition.anchoredPosition = startPosition;
        inventorySlot.isBeingDragged = false;
        
        Vector2 point = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        if(!IsPointInRT(point, inventory))
        {
            //Debug.Log("Dropping " + inventorySlot.item.name);
            itemsPrefab.GetComponent<ItemPickUp>().item = inventorySlot.item;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;
            Instantiate(itemsPrefab,mouseWorldPosition, new Quaternion(0,0,0,0));

            index = Array.IndexOf(inventoryUI.slots,inventorySlot);

            int amount = int.Parse(inventorySlot.amountText.text) - 1;
            if(amount > 0)
            {
                inventoryUI.slots[index].amountText.text = amount.ToString();
                inventoryLogic.itemsAmount[index] = amount;
            }
            else
            {
                inventoryLogic.Remove(index);
                inventoryLogic.itemsAmount.RemoveAt(index);
                inventoryUI.UpdateUI();
            }
        }
        else
            Debug.Log("Dropped on inventory");
    }

    bool IsPointInRT(Vector2 point, RectTransform rt)
    {
        Rect rect = rt.rect;

        float leftSide = rt.anchoredPosition.x - rect.width / 2;
        float rightSide = rt.anchoredPosition.x + rect.width / 2;
        float topSide = rt.anchoredPosition.y + rect.height / 2;
        float bottomSide = rt.anchoredPosition.y - rect.height / 2;

        if (point.x >= leftSide && point.x <= rightSide && point.y >= bottomSide && point.y <= topSide)
        {
            return true;
        }
        return false;
    }
}
