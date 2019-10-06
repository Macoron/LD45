using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityIgnore : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<OVRGrabbable>().OnGrabEnd += GrabEnd;
    }

    private void GrabEnd()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }
}
