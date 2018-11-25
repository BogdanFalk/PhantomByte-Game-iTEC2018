using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Player_Shoot : MonoBehaviour {

    public Rigidbody2D lPlayerProjectile;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float projectileSpeed = 500;
    public float spawnDistance;
    private L_GameChoises gameScript;
   
    void Start () {
        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(gameScript.canShoot)
        if(coolDown+0.1f<Time.time)
        if(Input.GetKeyDown(KeyCode.C))
        {
            Fire();
        }
	}

    void Fire()
    {

        if (GameObject.Find("lPlayer").GetComponent<L_Player_Movement>().orientation == "right")
        {
            Rigidbody2D projectile = Instantiate(lPlayerProjectile, new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
        }
        else
        {
            Rigidbody2D projectile = Instantiate(lPlayerProjectile, new Vector3(transform.position.x - spawnDistance, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
        }

     

        coolDown = Time.time + attackSpeed;

    }
}
