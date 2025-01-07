using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapHand : MonoBehaviour
{
    public Transform floatingSurface; // Reference to the floating surface
    public Rigidbody2D handRigidbody; // Reference to the Rigidbody2D of the hand
    public KeyCode activateKey = KeyCode.E; // Key to activate sturdy grip

    private bool isHandTouchingSurface = false;
    private bool isHandSturdy = false;
    private HingeJoint2D handHingeJoint;

    void Update()
    {
        if (isHandTouchingSurface && Input.GetKeyDown(activateKey))
        {
            MakeHandSturdy();
        }

        if (isHandSturdy && Input.GetKey(KeyCode.W))
        {
            SwingBody(Vector2.up);
        }
        else if (isHandSturdy && Input.GetKey(KeyCode.S))
        {
            SwingBody(Vector2.down);
        }
        else if (isHandSturdy && Input.GetKey(KeyCode.A))
        {
            SwingBody(Vector2.left);
        }
        else if (isHandSturdy && Input.GetKey(KeyCode.D))
        {
            SwingBody(Vector2.right);
        }
    }

    private void MakeHandSturdy()
    {
        isHandSturdy = true;

        if (handHingeJoint == null)
        {
            // Add a HingeJoint2D to the hand and connect it to the floating surface
            handHingeJoint = handRigidbody.gameObject.AddComponent<HingeJoint2D>();
            handHingeJoint.connectedBody = floatingSurface.GetComponent<Rigidbody2D>();
            handHingeJoint.anchor = handRigidbody.transform.InverseTransformPoint(handRigidbody.position);

            // Optional: Adjust hinge settings if needed
            handHingeJoint.useLimits = true;
            JointAngleLimits2D limits = new JointAngleLimits2D { min = -90, max = 90 };
            handHingeJoint.limits = limits;
        }

        Debug.Log("Hand is now sturdy.");
    }

    private void SwingBody(Vector2 direction)
    {
        // Apply torque to the chest to rotate and swing the body
        Rigidbody2D chestRigidbody = GetRagdollPart("Chest");
        if (chestRigidbody != null)
        {
            float torque = direction.x * 50f - direction.y * 50f; // Adjust torque strength
            chestRigidbody.AddTorque(torque);
            Debug.Log($"Applying torque: {torque}");
        }
    }

    private Rigidbody2D GetRagdollPart(string partName)
    {
        // Find a specific part of the ragdoll by name
        Transform part = transform.Find(partName);
        if (part != null)
        {
            return part.GetComponent<Rigidbody2D>();
        }

        Debug.LogError($"Ragdoll part {partName} not found!");
        return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect when the hand touches the floating surface
        if (collision.collider.transform == floatingSurface)
        {
            isHandTouchingSurface = true;
            Debug.Log("Hand is touching the surface.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Detect when the hand stops touching the floating surface
        if (collision.collider.transform == floatingSurface)
        {
            isHandTouchingSurface = false;
            isHandSturdy = false;

            // Remove the HingeJoint2D if it exists
            if (handHingeJoint != null)
            {
                Destroy(handHingeJoint);
                handHingeJoint = null;
            }

            Debug.Log("Hand is no longer touching the surface.");
        }
    }
}

