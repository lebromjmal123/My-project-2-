using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QandEcontrol : MonoBehaviour
{
    [Header("Arm Transforms")]
    public Transform leftArmSegment1;
    public Transform leftArmSegment2;
    public Transform leftHand;
    public Transform rightArmSegment1;
    public Transform rightArmSegment2;
    public Transform rightHand;

    [Header("Holding Points")]
    public Transform leftHandHoldPoint;
    public Transform rightHandHoldPoint;

    [Header("Arm Settings")]
    public float armFollowSpeed = 5f;
    public float segmentFollowSpeed = 10f;
    public float maxArmDistance = 2f;

    private GameObject leftHeldObject;
    private GameObject rightHeldObject;

   

    [Header("Body Settings")]
    public Transform body;
    public float bodyFollowSpeed = 5f;
    // Start is called before the first frame update
    void Update()
    {
        // Update the arms to follow the mouse
        UpdateArmPositions();

        UpdateBodyPosition();
        // Check for holding or releasing objects
        HandleArmActions();
    }

    private void UpdateArmPositions()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Move the left arm towards the mouse
        if (mousePosition.x < body.position.x)
        {
            // Move the left hand towards the mouse if not holding an object
            if (leftHeldObject == null)
            {
                leftHand.position = Vector3.Lerp(leftHand.position, mousePosition, Time.deltaTime * armFollowSpeed);
                UpdateSegmentPositions(leftArmSegment1, leftArmSegment2, leftHand);
            }
        }
        else
        {
            // Move the right hand towards the mouse if not holding an object
            if (rightHeldObject == null)
            {
                rightHand.position = Vector3.Lerp(rightHand.position, mousePosition, Time.deltaTime * armFollowSpeed);
                UpdateSegmentPositions(rightArmSegment1, rightArmSegment2, rightHand);
            }
        }
    }
    private void UpdateBodyPosition()
    {
        // Calculate the midpoint between the base segments of the arms
        Vector3 midpoint = (leftArmSegment1.position + rightArmSegment1.position) / 2f;

        // Move the body towards the midpoint
        //body.position = Vector3.Lerp(body.position, midpoint, Time.deltaTime * bodyFollowSpeed);
    }
    private void UpdateSegmentPositions(Transform segment1, Transform segment2, Transform hand)
    {
        // Move segment 2 towards the hand
        segment2.position = Vector3.Lerp(segment2.position, hand.position, Time.deltaTime * segmentFollowSpeed);

        // Move segment 1 towards segment 2
        segment1.position = Vector3.Lerp(segment1.position, segment2.position, Time.deltaTime * segmentFollowSpeed);
    }


    private void HandleArmActions()
    {
        // Left arm holding or releasing
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (leftHeldObject == null)
            {
                TryHoldObject(leftHand, ref leftHeldObject, leftHandHoldPoint);
            }
            else
            {
                ReleaseObject(ref leftHeldObject);
            }
        }

        // Right arm holding or releasing
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rightHeldObject == null)
            {
                TryHoldObject(rightHand, ref rightHeldObject, rightHandHoldPoint);
            }
            else
            {
                ReleaseObject(ref rightHeldObject);
            }
        }
    }

    private void TryHoldObject(Transform hand, ref GameObject heldObject, Transform handHoldPoint)
    {
        // Perform a raycast to detect objects
        RaycastHit2D hit = Physics2D.Raycast(hand.position, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Holdable"))
        {
            heldObject = hit.collider.gameObject;
            heldObject.transform.SetParent(handHoldPoint);
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    private void ReleaseObject(ref GameObject heldObject)
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody2D>().isKinematic = false;
            heldObject = null;
        }
    }
}
