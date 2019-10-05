using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectionPlane : MonoBehaviour
{
    public Transform handAnchor;
    public GameObject panelGraphics;

    public float difAngle = 0.6f;

    public float animationTime = 0.5f;

    private bool isHide = false;

    private void Update()
    {
        if (!Application.isEditor)
        {
            transform.position = handAnchor.position;
            transform.rotation = handAnchor.rotation;
        }



        var paletUp = -panelGraphics.transform.forward;
        var worldUp = Vector3.up;

        float dif = Vector3.Dot(paletUp, worldUp);
        if (dif > difAngle)
            Show();
        else
            Hide();
    }

    private void Show()
    {
        if (!isHide)
            return;
        isHide = false;

        panelGraphics.SetActive(true);
        //panelGraphics.transform.localScale = Vector3.zero;
        LeanTween.cancel(panelGraphics);
        LeanTween.scale(panelGraphics, Vector3.one, animationTime)
            .setEaseOutCubic();
    }

    private void Hide()
    {
        if (isHide)
            return;
        isHide = true;

        LeanTween.cancel(panelGraphics);
        //panelGraphics.transform.localScale = Vector3.one;
        LeanTween.scale(panelGraphics, Vector3.zero, animationTime)
            .setEaseOutCubic()
            .setOnComplete(() => panelGraphics.SetActive(false));
    }
}
