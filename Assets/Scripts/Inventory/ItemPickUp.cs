using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    //private SpriteRenderer itemSprite;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            PickUp();
        }
    }
    private void PickUp()
    {
        
        bool wasPickedUP = Inventory.instance.Add(item);

        if(wasPickedUP)
        {
            //Debug.Log("pick up");
            Destroy(gameObject);
        }
            
    }
}
