using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownPot : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite OnMouseOverSprite;
    public Sprite baseSprite;
    private void Start() {
        baseSprite = spriteRenderer.sprite;
    }

    void OnMouseEnter() {
        spriteRenderer.sprite = OnMouseOverSprite;
    }

    void OnMouseExit() {
        spriteRenderer.sprite = baseSprite;
    }
}
