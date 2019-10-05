using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableIcon : MonoBehaviour
{
    public GameObject iconPrefab;

    public Transform palete;
    public OVRGrabbable grabbable;

    private Pose startPose;

    private void Awake()
    {
        grabbable.OnGrabBegin += Grabbable_OnGrabBegin;
        grabbable.OnGrabEnd += Grabbable_OnGrabEnd;

        startPose = new Pose(transform.localPosition, transform.localRotation);
    }

    private void Grabbable_OnGrabEnd()
    {
        var newInst = Instantiate(iconPrefab);
        newInst.transform.position = transform.position;
        newInst.transform.rotation = transform.rotation;

        newInst.transform.localScale = transform.lossyScale;
        LeanTween.scale(newInst, iconPrefab.transform.lossyScale, 1f).setEaseOutQuad();

        // Reset Position
        transform.parent = palete;
        transform.localPosition = startPose.position;
        transform.localRotation = startPose.rotation;
    }

    private void Grabbable_OnGrabBegin()
    {
        transform.parent = null;
    }
}
