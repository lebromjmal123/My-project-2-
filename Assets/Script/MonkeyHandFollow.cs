using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHandFollow : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public float followSpeed = 5.0f;

    private Camera mainCamera;

    void Start()
    {
       mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            MoveHandTowardsMouse(leftHand);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            MoveHandTowardsMouse(rightHand);
        }
    }

    void MoveHandTowardsMouse(Transform hand)
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z); // Set the Z distance from the camera
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Move the hand towards the mouse position
        hand.position = Vector3.Lerp(hand.position, worldMousePosition, followSpeed );
    }
    //* Time.deltaTime
}
