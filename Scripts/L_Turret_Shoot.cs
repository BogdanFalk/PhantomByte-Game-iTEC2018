using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Turret_Shoot : MonoBehaviour {

    public Rigidbody2D lTurretProjectile;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float projectileSpeed = 500;
    public float spawnDistance;
    public int angle;
    public Vector2 vForce;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        vForce = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        print(Time.time + 5f);
        if (coolDown + 0.1f < Time.time)
            {
                Fire();
            }
    }

    void Fire()
    {

        
            Rigidbody2D projectile = Instantiate(lTurretProjectile, new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            projectile.GetComponent<Rigidbody2D>().AddForce(vForce * projectileSpeed);

        coolDown = Time.time + attackSpeed;

    }
}
