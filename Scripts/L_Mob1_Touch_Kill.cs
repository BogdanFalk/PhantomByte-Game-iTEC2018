﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Mob1_Touch_Kill : MonoBehaviour {

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
            GameObject.Find("lLevelManager").GetComponent<L_EventSystem_Controller>().ResetScene();
        }
    }
}
