using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Player_Place_Trap : MonoBehaviour {

    public Rigidbody2D lPlayerTrap;
    public float coolDown;
    public float attackSpeed = 0.5f;
    private L_GameChoises gameScript;

    // Use this for initialization
    void Start () {
        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameScript.canTrap)
        if (coolDown + 0.5f < Time.time)
        if (Input.GetKeyDown(KeyCode.V)&&(gameObject.GetComponent<L_Player_Status>().traps>0))
        {
            Trap();
            gameObject.GetComponent<L_Player_Status>().traps--;
            gameScript.traps--;
        }
	}

    void Trap()
    {
        Rigidbody2D trap = Instantiate(lPlayerTrap, new Vector3(transform.position.x, transform.position.y-2f, transform.position.z), transform.rotation) as Rigidbody2D;
        coolDown = Time.time + attackSpeed;
    }
}
