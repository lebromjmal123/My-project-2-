using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Sprite[] sprites;  
    private Image imageComponent;  
    private int currentIndex = 0;  
    public BulletChecked bulletChecked;

    void Start()
    {
        
        imageComponent = GetComponent<Image>();

        
        if (sprites.Length > 0)
        {
            imageComponent.sprite = sprites[currentIndex];
        }
    }

    void FixedUpdate()
    {
        if (bulletChecked.hpTrigger == true)
        {
            
            currentIndex++;
            if (currentIndex >= sprites.Length)
            {
                currentIndex = 0;
            }

            
            imageComponent.sprite = sprites[currentIndex];
            bulletChecked.hpTrigger = false;
        }
    }
}
