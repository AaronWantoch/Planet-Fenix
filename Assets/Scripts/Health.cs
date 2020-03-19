using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int health = 100;

    public abstract void DeacreaseHealth(int damage);
}
