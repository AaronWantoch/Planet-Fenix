using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public void Shoot(object sender, Weapon.ShootingEventArgs args)
    {
        RaycastHit hit;

        if (Physics.Raycast(args.fromWhere.position, args.fromWhere.forward, out hit, args.range))
            args.hit = hit;
        else
            args.hit = new RaycastHit();
    }

    public void DealDamage(object sender, Weapon.ShootingEventArgs args)
    {
        Health health;
        if (args.hit.collider != null)
        {
            if(health = args.hit.collider.GetComponentInParent<Health>())
                health.DeacreaseHealth(args.damage);
        }
    }
}
