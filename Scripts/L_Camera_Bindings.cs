using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Camera_Bindings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(gameObject.transform.position.y);
        if(gameObject.transform.position.y<2.1)
        {
            transform.position = new Vector3(transform.position.x, 2.1f, -31.9603f);
        }
	}
}
