using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingHook : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField] private GameObject hookProjectile;
    [SerializeField] private float grappleLength;
    [SerializeField] private LineRenderer rope;

    [Header("Dynamic")]
    [SerializeField] private GameObject grappleProjectile = null;
    [SerializeField] GrapplingProjectile gpScript = null;
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
            if (grappleProjectile == null) TryToGrapple();

            else if (gpScript.Rooted)
            {
                gpScript.ResetRoot();
            }
            
        }

        if (grappleProjectile == null && rope.enabled)
        {
            ResetGrapple();
        }
        
        if (rope.enabled)
        {
            rope.SetPosition(0, grappleProjectile.transform.position);
            rope.SetPosition(1, transform.position);
        }


        if (gpScript != null && gpScript.Rooted)
        {
            if (!joint.enabled)
            {
                ActivateGrapple();
            }
            
            float scroll = Mouse.current.scroll.ReadValue().y;

            // Scroll down - shorten the hook
            if (scroll < 0)
            {
                joint.distance -= 3f * Time.deltaTime;
            }

            // Scroll up - lengthen the hook
            if (scroll > 0)
            {
                joint.distance += 3f * Time.deltaTime;
            }

            joint.distance = Mathf.Clamp(joint.distance, grappleLength / 1.5f, grappleLength * 1.5f);
        }

        void TryToGrapple()
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            worldPos.z = 0f;

            grappleProjectile = Instantiate(hookProjectile, transform.position, Quaternion.identity);
            gpScript = grappleProjectile.GetComponent<GrapplingProjectile>();
            gpScript.SetTarget(target: worldPos, player: this.gameObject);

            rope.enabled = true;
        }

        void ActivateGrapple()
        {
            joint.connectedAnchor = grappleProjectile.transform.position;
            joint.enabled = true;
            joint.distance = grappleLength;
        }

        void ResetGrapple()
        {
            rope.enabled = false;
            joint.enabled = false;
        }
    }
}
