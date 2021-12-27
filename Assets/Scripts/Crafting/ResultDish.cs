using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDish : MonoBehaviour
{
    public CraftingSlot slot;
    public GameObject craftingParent;

    public void WhenCraftingIsFull()
    {
        if(slot.item != null)
        {
            slot.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            craftingParent.SetActive(false);
        }
        else
        {
            slot.gameObject.SetActive(false);
            craftingParent.SetActive(true);
            this.gameObject.SetActive(true);
        }
    }
}
