using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Slider_Fill_Zero : MonoBehaviour {
    public GameObject sliderKnob;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
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
