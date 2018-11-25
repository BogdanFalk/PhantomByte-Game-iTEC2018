using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Projectile_Do_Dmg : MonoBehaviour {

    public int dmgToDo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
             
            if (col.gameObject.name == "lPlayer")
            {
                print("dmg player");
                if(col.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled)
                {
                    col.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    col.gameObject.GetComponent<L_Player_Status>().health -= dmgToDo;
                }
                
                Destroy(gameObject);
            }
 
       
    }
}
