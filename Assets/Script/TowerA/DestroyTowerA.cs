using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerA : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchedA;
    public int scoreValue = 1;      // Points awarded when Tower A is destroyed
    public float destroyDelay = 10f; // Time (in seconds) before destruction

    private bool hasScored = false;  // Prevents scoring multiple times

    void Update()
    {
        if (touchedA == true)
        {
            Invoke("DestroyTower", destroyDelay);
        }
    }
  
    private void DestroyTower()
    {
        if (!hasScored)
        {
            hasScored = true;

            // Add score via TowerManager
            if (TowerManager.Instance != null)
            {
                Debug.Log("Tower A Destroyed");
                TowerManager.Instance.AddScore(scoreValue);
            }
            else
            {
                Debug.LogError("TowerManager is NULL!");
            }

            // Destroy Tower A after scoring
            Destroy(this.gameObject);
        }
    }




}
