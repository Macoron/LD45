﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitVelocity : MonoBehaviour
{
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = velocity;
    }

}
