using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chasseRange = 15f;

    [SerializeField] Transform target;

    public UnityEvent onTargetReached;

    float distance;
    bool isProvoked;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if (distance <= chasseRange)
            Provoke();
        RespondToProvokation();
    }

    private void RespondToProvokation()
    {
        if (isProvoked)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance && onTargetReached != null)
            {
                onTargetReached.Invoke();
                transform.LookAt(target);
            }
                
        }
    }

    public void Provoke()
    {
        isProvoked = true;
    }

    void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasseRange);
    }
}
