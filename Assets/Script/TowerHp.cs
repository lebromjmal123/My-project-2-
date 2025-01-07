using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    public float towerHealth;
    void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.CompareTag("Player"))
       // {
        //    towerHealth = -1;
            
        //}
   
       if (collision.gameObject.CompareTag("Item"))
        {
            towerHealth = -2;
            
        }
    }


    void Update()
    {
        if (towerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
