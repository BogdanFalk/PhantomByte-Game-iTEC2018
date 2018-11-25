using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Pet_Turn : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("lPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<L_Player_Movement>().orientation=="left")
        {
            //gameObject.transform.position = new Vector3(-transform.position.x, transform.position.y, 0.09f);
            Quaternion quaternion = Quaternion.Euler(0f, 180f, 0);
            gameObject.transform.rotation = quaternion;
        }
        else
        {
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0.09f);
            Quaternion quaternion = Quaternion.Euler(0f, 0f, 0);
            gameObject.transform.rotation = quaternion;
        }
	}
}
