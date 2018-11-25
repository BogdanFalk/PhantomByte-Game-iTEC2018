using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Mob1_Shoot : MonoBehaviour {

    public Rigidbody2D lTurretProjectile;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float projectileSpeed = 500;
    public float spawnDistance;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (coolDown + 0.1f < Time.time)
            {
                Fire();
            }
    }

    void Fire()
    {

        
         if (gameObject.GetComponent<L_Mob_Patrol_Horizontal>().direction == -1)
        {
            Rigidbody2D projectile = Instantiate(lTurretProjectile, new Vector3(transform.position.x - spawnDistance, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileSpeed);
        }
        else
        {
            Rigidbody2D projectile = Instantiate(lTurretProjectile, new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            projectile.GetComponent<Rigidbody2D>().AddForce(-Vector2.left * projectileSpeed);
        } 
        coolDown = Time.time + attackSpeed;

    }
}
