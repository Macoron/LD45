using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StickObj : MonoBehaviour
{

    bool sticked = false;

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!sticked)
        {
            Object.Destroy(GetComponent<Rigidbody>());
            Object.Destroy(GetComponent<Collider>());
            Debug.Log("Collision");
            ContactPoint contact = collision.contacts[0];
            
            Transform collisionObj = collision.transform;
            SphereCollider collisionCollider = collisionObj.GetComponent<SphereCollider>();
            //Vector3 directionVect = contact.point - transform.position;
            //  directionVect = Vector3.ClampMagnitude()
            transform.up = contact.normal;
            transform.parent = collisionObj;
            

            sticked = true;

        }
    }
}

