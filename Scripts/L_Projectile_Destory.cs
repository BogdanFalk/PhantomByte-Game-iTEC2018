using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Projectile_Destory : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Destoryer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Destoryer()
    {
        yield return new WaitForSeconds(2f);
        DestroyObject(gameObject);
    }

}
