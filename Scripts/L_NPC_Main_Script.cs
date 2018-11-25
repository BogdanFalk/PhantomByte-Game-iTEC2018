using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_NPC_Main_Script : MonoBehaviour {

    bool popUpTextShow;
    public bool fadeOutPop = false;
    public bool fadeInPop = false;

    void Start () {
        popUpTextShow = true;

	}
	
	// Update is called once per frame
	void Update () {
       // print(GameObject.Find(gameObject.name + "popUpText").transform.GetComponent<SpriteRenderer>().material.color.a);
        

        if (popUpTextShow)
        {
            if (fadeOutPop)
            {
                fadeOutPop = false;
                StartCoroutine(FadeTo(0.0f, 1.0f));
            }
            if (fadeInPop)
            {
                fadeInPop = false;
                StartCoroutine(FadeTo(1.0f, 1.0f));
            }
        }
	}

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = GameObject.Find(gameObject.name+"popUpText").transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            GameObject.Find(gameObject.name + "popUpText").transform.GetComponent<SpriteRenderer>().material.color = newColor;
            

            yield return null;
        }

        
    }

    void switchFade(int i)
    {
        if(i==0)
        {
            fadeOutPop = true;
        }
        else
        {
            fadeInPop = false;
        }
    }

    void hidePopUpText()
    {
        popUpTextShow = false;
        
    }
}


//if (GameObject.Find(gameObject.name + "popUpText").transform.GetComponent<SpriteRenderer>().material.color.a == 1f)
//            {
//                fadeInPop = false;
//                fadeOutPop = true;
                
//            }
//            if (GameObject.Find(gameObject.name + "popUpText").transform.GetComponent<SpriteRenderer>().material.color.a< 0.1f)
//            {
//                fadeOutPop = false;
//                fadeInPop = true;
               
//            }