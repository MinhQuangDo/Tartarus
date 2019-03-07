using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemBox : MonoBehaviour
{
    // Super simple script to change the sprite for the item boxes
    [SerializeField] private Image imageRenderer;

    public void ChangeItemBox(SpriteRenderer itemSprite)
    {
        imageRenderer.sprite = itemSprite.sprite;
        imageRenderer.color = itemSprite.color;
    }

}
