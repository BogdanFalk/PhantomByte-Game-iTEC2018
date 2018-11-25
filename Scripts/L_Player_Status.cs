using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class L_Player_Status : MonoBehaviour {
    [Header("Player Status Attributes")]
    private L_GameChoises gameScript;
    public int hunger;
    public int restorePower;
    public int health;
    public int traps;

    public bool alive;
    public bool shielded;
    

    [Header("Player Life Attributes")]
    public float undergroundHeightKill;


    //private Slider hungerBar;
    //private Slider restorePowerBar;

    // Use this for initialization
    void Start () {
        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();
       
        if(gameScript.canTrap)
        {
            traps = gameScript.traps;

        }
        else
        {
            traps = 0;
        }
        
        
        if(gameScript.canPet)
        {
            //INSERT NEW INSTANCE OF PET :3
        }


        health = 100;

        //restorePowerBar = GameObject.Find("lCanvasSliderRestorePower").GetComponent<Slider>();
        //hungerBar = GameObject.Find("lCanvasSliderHunger").GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
        //if (restorePowerBar)
        //{
        //    restorePowerBar.value = restorePower;
        //}
        //if (hungerBar)
        //{
        //    hungerBar.value = hunger;
        //}
        if(hunger==0||gameObject.transform.position.y<undergroundHeightKill)
        {
            print("killed by fall");
            print("or fall");
            GameObject.Find("lLevelManager").GetComponent<L_EventSystem_Controller>().ResetScene();
        }
        if(health==0||health<0)
        {
            GameObject.Find("lLevelManager").GetComponent<L_EventSystem_Controller>().ResetScene();
        }
	}

}
