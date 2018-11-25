using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_GameChoises : MonoBehaviour {

    // Use this for initialization

    public int mob1;
    public int mob2;
    public int mob3;
    public int mob4;

    public int traps;

    public bool canShoot;
    public bool canTrap;
    public bool canShield;
    public bool canPet;
    public int zenQuest;


    private void Awake()
    {
        canShoot = false;
        canTrap = false;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
