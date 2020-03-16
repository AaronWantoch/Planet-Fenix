using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwGrenade : Weapon
{
    public float throwForce = 50f;
    public GameObject grenadePrefab;
    private Vector3 mouseDirection;
    private float timeHeld;
    private int amo = 3;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = mouseDirection - transform.position;

        if (Input.GetMouseButtonDown(0))// left mouse button
        {
            timeHeld = Time.time;
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Amo: " + amo);
            timeHeld = Time.time - timeHeld ;
            if (timeHeld < 1)
            {
                timeHeld = 1; // if you are holding it down for too short its 1 by default because under 1 = shitty throw
            }
            throwit();
        }

    }

    void throwit()
    {
        if (amo > 0)
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * timeHeld * throwForce, ForceMode.VelocityChange);
            amo -= 1;
        }
        else
        {
            Debug.Log("Out of Ammo bitches");
        }
    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "AMO_GRENADE")
        {
            Destroy(hit.gameObject);
            amo += 1;
            // sound effect for pickup
        }
    }

    private void OnDestroy()
    {
        
    }
}
