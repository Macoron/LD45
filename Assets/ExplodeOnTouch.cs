using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Planets"))
            Boom();
    }

    private void Boom()
    {
        var boomFX = Instantiate(explosionPrefab);
        boomFX.transform.SetPositionAndRotation(transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
