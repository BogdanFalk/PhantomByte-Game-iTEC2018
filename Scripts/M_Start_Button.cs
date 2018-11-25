using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class M_Start_Button : MonoBehaviour, IPointerDownHandler {


    public GameObject fader;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        print("swag");
        fader.GetComponent<L_Fader>().FadeIn();

        gameObject.GetComponent<Image>().enabled = false;
        StartCoroutine(FadeCor1());

    }

    IEnumerator FadeCor1()
    {
        print(Time.time);
        text.enabled = true;
        yield return new WaitForSeconds(2);
        print(Time.time);
        SceneManager.LoadScene(1);
    }
    
}
