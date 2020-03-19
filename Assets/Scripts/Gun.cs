using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Gun : Weapon
{
    [SerializeField] GameObject hitFX;
    [SerializeField] Transform fromWhereShoot;

    [SerializeField] int damage = 10;
    [SerializeField] float range = 10f;
    [SerializeField] float timeBetweenShoots = 1f;

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
    Shooting shooting;
    ShootingEventArgs eventArgs;

    event EventHandler<ShootingEventArgs> onShoot;

    bool canShoot = true;

    private void Start()
    {
        shooting = GetComponent<Shooting>();

        onShoot += shooting.Shoot;
        onShoot += shooting.DealDamage; //assigning methods to onShoot event


        eventArgs = new ShootingEventArgs(damage, range, fromWhereShoot);
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire") && onShoot != null)
        {
            StartBlassting();
        }
    }

    IEnumerator BlockShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShoots);
        canShoot = true;
    }

    public void StartBlassting()
    {
        if (!canShoot)
            return;
        onShoot.Invoke(this, eventArgs);
        ProcessRaycast();
        StartCoroutine(BlockShooting());
    }

    private void ProcessRaycast()
    {
        hit = eventArgs.hit; //takeing raycast hit from event args (set in shooting.Shoot function)

        if (hit.collider == null) //if it didn't hit
            return;

        InstantiateHitFX();
        EnemyAI enemy = hit.collider.GetComponentInParent<EnemyAI>();
        if (enemy)
            enemy.Provoke();

    }

    private void InstantiateHitFX()
    {
        Instantiate(hitFX, hit.point, Quaternion.identity);
    }

    private void OnDestroy()
    {
        if (onShoot != null)
        {
            onShoot -= shooting.Shoot;
            onShoot -= shooting.DealDamage;
        }

    }
}
