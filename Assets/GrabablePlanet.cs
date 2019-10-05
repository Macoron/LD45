using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabablePlanet : MonoBehaviour
{
    private OVRGrabbable grabbable;
    private Attractor attractor;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        attractor = GetComponent<Attractor>();

        grabbable.OnGrabBegin += Grabbable_OnGrabBegin;
        grabbable.OnGrabEnd += Grabbable_OnGrabEnd;
    }

    private void Grabbable_OnGrabEnd()
    {
        attractor.enabled = true;
    }

    private void Grabbable_OnGrabBegin()
    {
        attractor.enabled = false;
    }
}
