using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerD : MonoBehaviour
{
    public bool touchedD;
    public int scoreValue = 1;
    public float destroyDelay = 10f;

    private bool hasScored = false;

    void Update()
    {
        if (touchedD == true)
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
                Debug.Log("Tower D Destroyed");
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
