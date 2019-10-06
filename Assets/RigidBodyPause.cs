using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyPause : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    Vector3 savedVelocity;
    Vector3 savedAngularVelocity;

    public bool isPause = false;

    private void Start()
    {
        if (PauseSystem.isPause)
            OnPauseGame();
    }

    private void FixedUpdate()
    {
        if (isPause)
        {
            if (rigidbody.velocity != Vector3.zero)
                savedVelocity = rigidbody.velocity;
            if (rigidbody.angularVelocity != Vector3.zero)
                savedAngularVelocity = rigidbody.angularVelocity;

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    public void OnPauseGame()
    {
        savedVelocity = rigidbody.velocity;
        savedAngularVelocity = rigidbody.angularVelocity;
        rigidbody.isKinematic = true;

        isPause = true;
    }

    public void OnResumeGame()
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(savedVelocity, ForceMode.VelocityChange);
        rigidbody.AddTorque(savedAngularVelocity, ForceMode.VelocityChange);

        isPause = false;
    }
}
