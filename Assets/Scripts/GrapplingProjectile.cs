using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingProjectile : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField] private float grappleSpeed = 5;
    [SerializeField] private float returnSpeed = 15;
    [SerializeField] private float grappleRange = 4;
    [Header("Dynamic")]
    [SerializeField] private Vector3 _target = Vector3.zero;
    [SerializeField] private GameObject playerGO;
    [SerializeField] private bool returningToPlayer = false;
    [SerializeField] private Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if (!returningToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, grappleSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x + transform.position.y - startingPos.x - startingPos.y) > grappleRange)
            {
                returningToPlayer = true;
                Collider2D collider = this.gameObject.GetComponent<Collider2D>();
                collider.enabled = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, playerGO.transform.position, returnSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x + transform.position.y - playerGO.transform.position.x - playerGO.transform.position.y) < 3)
            {
                ResetGrapple();
            }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    
    public void SetTarget(Vector3 target, GameObject player)
    {
        _target = target;
        playerGO = player;
    }

    void ResetGrapple()
    {
        Destroy(this.gameObject);
    }
}
