using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Player_Pet : MonoBehaviour {
    private L_GameChoises gameScript;
    public GameObject petObj;
    // Use this for initialization
    void Start () {
        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();
        petObj = transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		if(gameScript.canPet)
        {
            petObj.SetActive(true);
        }
        else
        {
            petObj.SetActive(false);
        }
	}
}
