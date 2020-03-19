using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;
    float countdown;
    bool hasExploded = false;

    public GameObject explosionEffect;

    public float blastRadius = 5f;
    public float explosionForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime; // after 3 seconds explode
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

  void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation); // make the effect spawn at the position of our object
        // added a script to the ffect so it destroys itself too instead of beeing there all time

        
       
      
       

       Collider [] colliders = Physics.OverlapSphere(transform.position,blastRadius); // in radius of parameter objects & store them into an Array

        foreach(Collider nearbyObject in colliders)
        {
          Rigidbody rb =  nearbyObject.GetComponent<Rigidbody>(); 
            if(rb != null) // if there is a rigidbody on the object in the radius
            {
                rb.AddExplosionForce(explosionForce,transform.position,blastRadius); 

            }
         Destructablez destroi =   nearbyObject.GetComponent<Destructablez>();  // If the object has Destructablez script call destroy
             if(destroi != null)
            {
                destroi.Destroyed();
            }


        }
        Destroy(gameObject); // grenade boom
        Debug.Log("Boom");
       
    }




}
