using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerB : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchedB;
    public int scoreValue = 1;      
    public float destroyDelay = 10f; 

    private bool hasScored = false;  

    void Update()
    {
        if (touchedB == true)
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
                Debug.Log("Tower B Destroyed");
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
