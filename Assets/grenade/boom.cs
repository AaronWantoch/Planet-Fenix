using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f); // destroys gameobject after 2f
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
