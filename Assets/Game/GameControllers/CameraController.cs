﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
