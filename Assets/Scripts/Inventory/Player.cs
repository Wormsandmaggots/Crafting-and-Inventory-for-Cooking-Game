using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ySpeed = 0.75f;
    public float xSpeed = 1f;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Move(new Vector3(x, y, 0));
        MoveToPoint();
    }

    private void Move(Vector3 vector)
    {
        transform.position += new Vector3(vector.x * xSpeed, vector.y * ySpeed, 0);
    }

    //repair to on click go to item
    #region GoToItem
    private void MoveToPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("HIT");
                CurrentClickedGameObject(hit.transform.gameObject);
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.transform.tag == "Item")
        {
            transform.position = gameObject.transform.position;
        }
    }
    #endregion
}
