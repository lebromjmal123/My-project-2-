using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler1 : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public SpringJoint2D springJoint;
    public float ropeLength = 5f;

    private Vector2 ropeAnchorPoint;
    private Rigidbody2D playerRigidbody;
    public AudioSource websoundL;

    void Start()
    {
        springJoint.enabled = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateRope();
            websoundL.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            ReleaseRope();
        }

        if (springJoint.enabled)
        {
            UpdateRope();
        }
    }

    private void CreateRope()
    {

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);


        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;


        ropeAnchorPoint = (Vector2)transform.position + direction * ropeLength;


        springJoint.connectedAnchor = ropeAnchorPoint;
        springJoint.distance = ropeLength;
        springJoint.enabled = true;


        lineRenderer.SetPosition(0, ropeAnchorPoint);
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.enabled = true;
    }

    private void ReleaseRope()
    {

        springJoint.enabled = false;
        lineRenderer.enabled = false;
    }

    private void UpdateRope()
    {

        lineRenderer.SetPosition(0, ropeAnchorPoint);
        lineRenderer.SetPosition(1, transform.position);
    }

    private void FixedUpdate()
    {
        if (springJoint.enabled)
        {

            float currentDistance = Vector2.Distance(transform.position, ropeAnchorPoint);


            if (currentDistance > ropeLength)
            {
                Vector2 direction = ((Vector2)transform.position - ropeAnchorPoint).normalized;
                Vector2 newPosition = ropeAnchorPoint + direction * ropeLength;
                playerRigidbody.MovePosition(newPosition);
            }
        }
    }
}
