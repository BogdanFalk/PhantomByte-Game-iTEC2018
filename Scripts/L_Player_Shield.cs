using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Player_Shield : MonoBehaviour {
    private L_GameChoises gameScript;
    public GameObject shieldObj;
    public float regenSpeed;
    public float coolDown;
    // Use this for initialization
    void Start () {
        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();
        shieldObj = transform.GetChild(0).gameObject;
        shieldObj.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        print(gameScript.canShield);
        if (gameScript.canShield)
            if (coolDown + 0.1f < Time.time)
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Shield();
                }
    }

    void Shield()
    {
        shieldObj.GetComponent<SpriteRenderer>().enabled = true;
        coolDown = Time.time + regenSpeed;
    }
}
