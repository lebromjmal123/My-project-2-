using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDCheck : MonoBehaviour
{
    public DestroyTowerD destroyTowerD;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroyTowerD.touchedD = true;
        }
    }
}
