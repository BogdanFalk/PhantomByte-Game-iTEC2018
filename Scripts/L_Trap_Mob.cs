using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Trap_Mob : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Mob")
        {
            //collision.gameObject.GetComponent<L_Mob1_Shoot>().enabled = false;
            //collision.gameObject.GetComponent<L_Mob_Patrol_Horizontal>().enabled = false;
            if (collision.gameObject.name == "lMob1")
            {
                GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob1 = 1;
                collision.gameObject.GetComponent<L_Mob_Status>().GetComponent<SpriteRenderer>().enabled = false;
                collision.gameObject.GetComponent<L_Mob_Status>().GetComponent<CircleCollider2D>().enabled = false;
                collision.gameObject.GetComponent<L_Mob_Status>().GetComponent<EdgeCollider2D>().enabled = false;
                collision.gameObject.GetComponent<L_Mob_Status>().GetComponent<L_Mob1_Shoot>().enabled = false;
            }  
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
