using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerH : MonoBehaviour
{
    public bool touchedH;
    public int scoreValue = 1;
    public float destroyDelay = 10f;

    private bool hasScored = false;

    void Update()
    {
        if (touchedH == true)
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
                Debug.Log("Tower H Destroyed");
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
