using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public bool isMovingToTarget;

    [SerializeField] Transform target;


    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(isMovingToTarget)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }
}
