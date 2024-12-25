using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    GameObject grabbedObj;
    public Rigidbody2D rb;
    public int isLeftorRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(isLeftorRight))
        {
            FixedJoint2D fj = grabbedObj.AddComponent<FixedJoint2D>();
            fj.connectedBody = rb;
            fj.breakForce = 9001;

        }
        else if (Input.GetMouseButtonDown(isLeftorRight))
        {
            if(grabbedObj != null)
            {
                Destroy(grabbedObj.GetComponent<FixedJoint2D>());

            }
            grabbedObj = null;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            grabbedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grabbedObj = null;
    }
}
