using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerA : MonoBehaviour
{
    // Start is called before the first frame update
    public bool touchedA;

    // Update is called once per frame
    void Update()
    {
        if (touchedA == true)
        {


            Destroy(gameObject, 5);

        }
    }
}
