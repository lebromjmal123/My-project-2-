using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler1 : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distancejoint;
    // Start is called before the first frame update
    void Start()
    {
        distancejoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);
            distancejoint.connectedAnchor = mousePos;
            distancejoint.enabled = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            distancejoint.enabled = false;
            lineRenderer.enabled = false;
        }
        if (distancejoint.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}
