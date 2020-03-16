using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitFX;

    [SerializeField] int damage = 10;
    [SerializeField] float range = 10f;

    public class ShootingEventArgs // class in class
    {
        public int damage;
        public float range;
        public Transform fromWhere;
        public RaycastHit hit;

        public ShootingEventArgs(int d, float r, Transform t) //costructor
        {
            damage = d;
            range = r;
            fromWhere = t;
        }
    }

    RaycastHit hit;
    Transform camera;
    Shooting shooting;
    ShootingEventArgs eventArgs;

    event EventHandler<ShootingEventArgs> onShoot;
    
    private void Start()
    {
        shooting = GetComponent<Shooting>();

        onShoot += shooting.Shoot;
        onShoot += shooting.DealDamage; //assigning methods to onShoot event

        camera = FindObjectOfType<Camera>().transform;

        eventArgs = new ShootingEventArgs(damage, range, camera);
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire") && onShoot != null)
        {
            onShoot.Invoke(this, eventArgs);
            ProcessRaycast();
        }
    }

    private void ProcessRaycast()
    {
        hit = eventArgs.hit; //takeing raycast hit from event args (set in shooting.Shoot function)

        if (hit.collider == null) //if it didn't hit
            return;

        InstantiateHitFX();

    }

    private void InstantiateHitFX()
    {
        Instantiate(hitFX, hit.point, Quaternion.identity);
    }

    private void OnDestroy()
    {
        onShoot -= shooting.Shoot;
        onShoot -= shooting.DealDamage;
    }
}
