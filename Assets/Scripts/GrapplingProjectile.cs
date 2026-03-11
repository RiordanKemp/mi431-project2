using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingProjectile : MonoBehaviour
{
    [Header("Inscribed")]
    [SerializeField] private float grappleSpeed = 5;
    [SerializeField] private float returnSpeed = 15;
    [SerializeField] private float grappleRange = 4;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LayerMask stopGrappleLayer;
    [SerializeField] private LayerMask grabItemLayer;
    [Header("Dynamic")]
    [SerializeField] private Vector3 _target = Vector3.zero;
    [SerializeField] private GameObject playerGO;
    [SerializeField] public bool returningToPlayer = false;
    [SerializeField] private Vector3 startingPos;
    [SerializeField] private bool rooted = false;
    public bool Rooted => rooted;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        // Projectile is moving towards the cursor target
        if (!returningToPlayer && !rooted)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, grappleSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            if (Mathf.Abs(transform.position.x - startingPos.x) > grappleRange || 
            Mathf.Abs(transform.position.y - startingPos.y) > grappleRange)
            {
                ReturnToPlayer();
            }
        }

        // Projectile is returning to the player
        else if (returningToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerGO.transform.position, returnSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            if (Mathf.Abs(transform.position.x - playerGO.transform.position.x) < 0.05f && Mathf.Abs(transform.position.y - playerGO.transform.position.y) < 0.05f )
            {
                Destroy(this.gameObject);
            }
        }


    }

    void LateUpdate()
    {
        if (transform.position == _target && !returningToPlayer)
        {
            ReturnToPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (returningToPlayer || rooted) return;

        if ((grappleLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            rooted = true;
        }

        else if ((stopGrappleLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            ReturnToPlayer();
        }

        else if ((grabItemLayer.value & (1 << col.gameObject.layer)) != 0)
        {
            ReturnToPlayer();
            col.gameObject.transform.parent = this.transform;   
        }
    }


    public void ResetRoot()
    {
        rooted = false;
        ReturnToPlayer();
        // effects reset
    }

    
    public void SetTarget(Vector3 target, GameObject player)
    {
        _target = target;
        playerGO = player;
    }

    void ReturnToPlayer()
    {
        returningToPlayer = true;
        Collider2D collider = this.gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
    }

}
