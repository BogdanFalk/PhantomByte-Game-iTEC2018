using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Mob_Status : MonoBehaviour {

    [Header("Mob Status Attributes")]
    public int health;
    // Use this for initialization
    void Start () {
        health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(health<1)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            gameObject.GetComponent<L_Mob1_Shoot>().enabled = false;
            GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob1 = -1;
        }
	}
}
