using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerB : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchedB;

    // Update is called once per frame
    void Update()
    {
        if (touchedB == true)
        {


            Destroy(gameObject, 5);

        }
    }
}
