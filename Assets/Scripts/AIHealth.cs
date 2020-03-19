using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    override public void DeacreaseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(this.gameObject);
    }
}
