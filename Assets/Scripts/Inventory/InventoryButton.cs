using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour
{
    public static InventoryButton button;
    public GameObject UI;
    new Animator animation;
    void Start()
    {
        animation = GetComponent<Animator>();
        button = this;
    }
    void Update() {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Open();
        }
        else
            Close();
    }
    // repair that animation controller to start animation, wait to animation end and open inventory 
    public void Open()
    {
        animation.ResetTrigger("hide");
        animation.SetTrigger("show");
    }

    public void Close()
    {
        animation.ResetTrigger("show");
        animation.SetTrigger("hide");
    }
    public IEnumerator Waiter(float seconds)
    {
        if(UI.activeSelf)
            Close();
        else
            Open();

        yield return new WaitForSecondsRealtime(seconds);
    }
}
