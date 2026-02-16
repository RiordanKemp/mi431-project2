using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingHook : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            worldPos.z = 0f;

            RaycastHit2D hit = Physics2D.Raycast(
                origin: worldPos,
                direction: Vector2.zero,
                distance: Mathf.Infinity,
                layerMask: grappleLayer
            );

            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                joint.distance = grappleLength;
                rope.enabled = true;
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            joint.enabled = false;
            rope.enabled = false;
        }

        if (rope.enabled)
        {
            rope.SetPosition(0, grapplePoint);
            rope.SetPosition(1, transform.position);
        }
    }
}
