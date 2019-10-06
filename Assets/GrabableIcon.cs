using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableIcon : MonoBehaviour
{
    public GameObject iconPrefab;

    public Transform palete;
    public OVRGrabbable grabbable;

    private Vector3 origSize;

    private Pose startPose;

    public bool changeScale = true;

    private void Awake()
    {
        grabbable.OnGrabBegin += Grabbable_OnGrabBegin;
        grabbable.OnGrabEnd += Grabbable_OnGrabEnd;

        startPose = new Pose(transform.localPosition, transform.localRotation);

        origSize = transform.localScale;
    }

    private void Grabbable_OnGrabEnd()
    {
        var newInst = Instantiate(iconPrefab);
        newInst.transform.position = transform.position;
        newInst.transform.rotation = transform.rotation;

        if (changeScale)
        {
            newInst.transform.localScale = transform.lossyScale;
            LeanTween.scale(newInst, iconPrefab.transform.lossyScale, 1f).setEaseOutQuad();
        }

        newInst.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Reset Position
        transform.parent = palete;
        transform.localPosition = startPose.position;
        transform.localRotation = startPose.rotation;
        transform.localScale = origSize;
    }

    private void Grabbable_OnGrabBegin()
    {
        transform.parent = null;
    }
}
