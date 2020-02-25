﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RodentController : MonoBehaviour
{
    public IRodent rodent { get; set; }

    private Queue<string> actionQueue;

    public Camera rodentCamera;

    public LayerMask groundLayer;

    public NavMeshAgent rodentAgent;

    void Awake()
    {
        rodentCamera = Camera.main;
        groundLayer = LayerMask.GetMask("Ground");
        rodentAgent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        rodentAgent.speed = rodent.GetMovement();

        if (Input.GetMouseButtonDown(1))
        {
            rodentAgent.SetDestination(GetPointUnderCursor());
        }

        var action = actionQueue.Dequeue();
    }

    private Vector3 GetPointUnderCursor()
    {
        Vector3 mouseWorldPosition = rodentCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40));
        RaycastHit hitPosition;
        Physics.Raycast(mouseWorldPosition, rodentCamera.transform.forward, out hitPosition, 100, groundLayer);

        return hitPosition.point;
    }
}
