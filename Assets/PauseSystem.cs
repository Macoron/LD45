using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public Switcher switcher;

    public static bool isPause = false;

    private void Awake()
    {
        switcher.onHandlerDown += SetPause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SetPause(!isPause);

    }

    public void SetPause(bool isPause)
    {
        PauseSystem.isPause = isPause;

        var rigidBodies = FindObjectsOfType<RigidBodyPause>();
        foreach (var rb in rigidBodies)
        {
            if (isPause)
                rb.OnPauseGame();
            else
                rb.OnResumeGame();
        }
    }
}
