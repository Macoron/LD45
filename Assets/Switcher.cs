using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switcher : MonoBehaviour
{
    public Transform handler;
    public AudioSource source;

    private Vector3 comfortLevel;

    public event System.Action<bool> onHandlerDown;
    private bool isDown = false;

    public bool isOn;
    public float dif = 0.1f;

    private void Awake()
    {
        comfortLevel = handler.position;
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => (Vector3.Distance(comfortLevel, handler.position) > dif));

            Activate();

            yield return new WaitUntil(() => (Vector3.Distance(comfortLevel, handler.position) < dif));
        }
    }

    private void Activate()
    {
        isOn = !isOn;
        onHandlerDown?.Invoke(isOn);


        source?.Play();
    }
}
