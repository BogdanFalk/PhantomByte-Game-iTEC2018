using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class L_Player_Status : MonoBehaviour {
    [Header("Player Status Attributes")]
    public int hunger;
    public int restorePower;
    public bool alive;
    public bool shielded;


    [Header("Player Life Attributes")]
    public float undergroundHeightKill;


    private Slider hungerBar;
    private Slider restorePowerBar;

    // Use this for initialization
    void Start () {
        hunger = 100;
        restorePower = 0;
        restorePowerBar = GameObject.Find("lCanvasSliderRestorePower").GetComponent<Slider>();
        hungerBar = GameObject.Find("lCanvasSliderHunger").GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
        restorePowerBar.value = restorePower;
        hungerBar.value = hunger;
        if(hunger==0||gameObject.transform.position.y<undergroundHeightKill)
        {
            killPlayer();
        }
	}

    void killPlayer()
    {
        gameObject.transform.position = gameObject.GetComponent<L_Player_Movement>().spawnCoors;
    }
}
