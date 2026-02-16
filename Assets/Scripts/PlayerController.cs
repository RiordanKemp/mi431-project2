using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Inscribed")]
    public Rigidbody2D rigid;
    public int movementSpeed = 3;
    public int jumpHeight = 7;
    public float raycastDist = 0.5f;
    public Vector2 boxSize = new Vector2(0.9f, 0.2f);
    public LayerMask groundLayer;

    [Header("Dynamic")]
    [SerializeField] int hAxis = 0;

    public void FixedUpdate()
    {
        hAxis = HorizontalInput();

        float velocityY = rigid.velocity.y;
        
        if (Keyboard.current.spaceKey.isPressed && IsGrounded())
        {
            Debug.Log("Player jump triggered");
            velocityY += jumpHeight;
        }

        rigid.velocity = new Vector2(hAxis * movementSpeed, velocityY);


    }

    int HorizontalInput()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            return 1;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            return -1;
        }
        return 0;
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
        transform.position,
        boxSize,
        0f,
        Vector2.down,
        raycastDist,
        groundLayer
        );

        return hit.collider != null;
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position+Vector3.down * raycastDist, boxSize);
    }
}
