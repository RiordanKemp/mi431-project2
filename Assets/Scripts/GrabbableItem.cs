using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject grabParticles;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMask.LayerToName(col.gameObject.layer) == "Player")
        {
            Instantiate<GameObject>(grabParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        
    }
}
