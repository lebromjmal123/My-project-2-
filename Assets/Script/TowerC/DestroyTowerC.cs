using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerC : MonoBehaviour
{
    public bool touchedC;
    public int scoreValue = 1;      
    public float destroyDelay = 10f; 

    private bool hasScored = false;  

    void Update()
    {
        if (touchedC == true)
        {
            Invoke("DestroyTower", destroyDelay);
        }
    }

    private void DestroyTower()
    {
        if (!hasScored)
        {
            hasScored = true;

            
            if (TowerManager.Instance != null)
            {
                Debug.Log("Tower C Destroyed");
                TowerManager.Instance.AddScore(scoreValue);
            }
            else
            {
                Debug.LogError("TowerManager is NULL!");
            }

            
            Destroy(this.gameObject);
        }
    }
}
