using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StickMan : MonoBehaviour
{
    public float speed = 0.01f;
    bool sticked = false;

    // Update is called once per frame
    void Update()
    {
        if (sticked)
        {
           
            transform.parent.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
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
            GameObject pivot = Instantiate(new GameObject(), collisionObj);
            transform.parent = pivot.transform;
            transform.localPosition = new Vector3(0, collisionCollider.radius, 0);
            transform.parent.Rotate(new Vector3(0, Random.Range(0, 360), 0));
            sticked = true;

        }
    }
}

