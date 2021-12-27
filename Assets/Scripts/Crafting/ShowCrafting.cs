using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCrafting : MonoBehaviour
{
    [SerializeField] private GetTrigger isTriggerOn;
    public Canvas craftingCanvas;
    public Canvas UI;
    public InventoryUI inventory;
    void OnMouseDown() {
        if(isTriggerOn.isTriggerOn)
        {
            SetCrafting(true);
            inventory.UpdateUI();
        }
    }

    public bool IsCraftingCanvasActive()
    {
        return craftingCanvas.gameObject.activeSelf;
    }
    public void SetCrafting(bool value){
        craftingCanvas.gameObject.SetActive(value);
        UI.gameObject.SetActive(!value);
    }
}
