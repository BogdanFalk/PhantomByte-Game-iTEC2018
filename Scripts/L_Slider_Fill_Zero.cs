using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Slider_Fill_Zero : MonoBehaviour {
    public GameObject sliderKnob;
    public GameObject playerS;
    public int type;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            gameObject.GetComponent<Slider>().value = playerS.GetComponent<L_Player_Status>().health;
        }
        else {
            gameObject.GetComponent<Slider>().value = playerS.GetComponent<L_Player_Status>().restorePower;
        }
        
        if (gameObject.GetComponent<Slider>().value == 0)
        {
            sliderKnob.SetActive(false);
        }
        else
        {
            sliderKnob.SetActive(true);
        }
    }
}
