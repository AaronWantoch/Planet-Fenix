using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void DeacreaseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(this.gameObject);
        Debug.Log(health);
    }
}
