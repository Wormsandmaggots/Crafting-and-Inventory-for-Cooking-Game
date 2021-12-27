using UnityEngine;

public class MosueOverCrafting : MonoBehaviour 
{
    public Vector2 point;
    [SerializeField]private Vector2 center;
    float leftside;    
    float rightside;    
    float topside;  
    float bottomside;

    private Vector2 downLeft;
    private Vector2 upRight;

    

    void Start() {
        center = this.transform.position;
    }
    public bool IsPoiterOverCrafting()
    {
        Vector3 pointx = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point = new Vector2(pointx.x, pointx.y);
        bool bol = IsPointInRT(point);
        return bol;
    }
    
    bool IsPointInRT(Vector2 point)
    {
        // Never look at this ever again
        //it works but at what prive
        
        leftside = center.x - this.GetComponent<RectTransform>().rect.width / 2;
        rightside = center.x + this.GetComponent<RectTransform>().rect.width / 2;
        topside = center.y + this.GetComponent<RectTransform>().rect.height / 3;
        bottomside = center.y - this.GetComponent<RectTransform>().rect.height / 3;

        downLeft = new Vector2(leftside, bottomside);
        downLeft = Camera.main.ScreenToWorldPoint(downLeft);

        upRight = new Vector2(rightside, topside);
        upRight = Camera.main.ScreenToWorldPoint(upRight);

        if (point.x >= downLeft.x && point.x <= upRight.x && point.y >= downLeft.y && point.y <= upRight.y)
        {
            return true;
        }
        return false;
    }
}
