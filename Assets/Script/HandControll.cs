using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControll : MonoBehaviour
{
    int speed = 1000;
    public Rigidbody2D rb;
    public Camera cam;
    public KeyCode KeyBoard;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 difference = playerpos - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        if (Input.GetKey(KeyBoard))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.fixedDeltaTime));

        }
    }
}
