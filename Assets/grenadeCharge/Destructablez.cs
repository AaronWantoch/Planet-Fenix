using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructablez : MonoBehaviour
{

    public void Destroyed()
    {
       
        Destroy(gameObject,3f);
        // Instantiate destroyed version on same place and rotation of the gameobject 
    }
}
