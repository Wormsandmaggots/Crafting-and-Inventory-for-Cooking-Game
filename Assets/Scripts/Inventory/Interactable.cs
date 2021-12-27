using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public CircleCollider2D triggerRadius;
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object " + transform.name + " collided with " + other.transform.name);
    }
}
