using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Mineable
{
    Rigidbody rb;
    bool colliding;
    bool harvested;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        harvested = false;
    }

    void Update()
    {
        
    }

    override public void harvest()
    {
        if(!harvested)
        {
            Debug.Log("Harvesting Wood");
            fall();
            harvested = true;
        }
    }

    private void fall()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = false;
        rb.AddForce(randomDirection() * 50f);
        Invoke("stopFallAnimation", 2f);
    }

    private void stopFallAnimation()
    {
        if(colliding)
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    private Vector3 randomDirection()
    {
        float rand = Random.Range(0, 1f);
        if (rand <= 0.25f)
        {
            return transform.forward;
        }
        else if (rand > 0.25f && rand <= 0.5f)
        {
            return transform.right;
        }
        else if (rand > 0.5f && rand <= 0.75f)
        {
            return -transform.forward;
        }
        else
        {
            return -transform.right;
        }
    }
}
