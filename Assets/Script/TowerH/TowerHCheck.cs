using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHCheck : MonoBehaviour
{
    public DestroyTowerH destroyTowerH;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroyTowerH.touchedH = true;
        }
    }
}
