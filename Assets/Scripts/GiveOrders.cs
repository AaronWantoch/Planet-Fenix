using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveOrders : MonoBehaviour
{
    [SerializeField] float followRange = 10f;

    FollowPlayer[] troops;
    // Start is called before the first frame update
    void Start()
    {
        troops = FindObjectsOfType<FollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            OrderToFollow();
        }
        if (Input.GetMouseButtonDown(2))
        {
            OrderToStop();
        }
    }

    private void OrderToStop()
    {
        foreach (FollowPlayer solider in troops)
        {
            solider.isMovingToTarget = false;
        }
    }

    private void OrderToFollow()
    {
        foreach(FollowPlayer solider in troops)
        {
            if (Vector3.Distance(transform.position, solider.transform.position) <= followRange)
            {
                solider.isMovingToTarget = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
}
