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

    public void OnPauseGame()
    {
        savedVelocity = rigidbody.velocity;
        savedAngularVelocity = rigidbody.angularVelocity;
        rigidbody.isKinematic = true;
    }

    public void OnResumeGame()
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(savedVelocity, ForceMode.VelocityChange);
        rigidbody.AddTorque(savedAngularVelocity, ForceMode.VelocityChange);
    }
}
