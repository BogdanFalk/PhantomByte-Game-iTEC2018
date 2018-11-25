using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Projectile_Do_Dmg_to_Mob : MonoBehaviour {

    public int dmgToDo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print(gameObject.name + " " + col.gameObject.name);



        if (col.gameObject.name == "lMob1")
        {
            print("dmg mob");
            col.gameObject.GetComponent<L_Mob_Status>().health -= dmgToDo;
            Destroy(gameObject);
        }

        if (col.gameObject.name == "lMob1 (1)")
        {
            print("dmg mob");
            col.gameObject.GetComponent<L_Mob_Status>().health -= dmgToDo;
            Destroy(gameObject);
        }

        if (col.gameObject.name == "Boss")
        {
            print("dmg mob");
            col.gameObject.GetComponent<L_Mob_Status>().health -= dmgToDo;
            Destroy(gameObject);
        }

        if (col.gameObject.name == "lMob1Projectile")
        {
            print("headlock");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }




    }
}
