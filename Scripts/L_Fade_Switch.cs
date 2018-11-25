using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Fade_Switch : MonoBehaviour {
    private void Start()
    {
        StartCoroutine(FirstCoroutine());
    }
  

    IEnumerator FirstCoroutine()
    {

        gameObject.GetComponent<L_NPC_Main_Script>().fadeInPop = true;

        yield return new WaitForSeconds(2);

        

        StartCoroutine(SecondCoroutine());

    }

    IEnumerator SecondCoroutine()
    {

        gameObject.GetComponent<L_NPC_Main_Script>().fadeOutPop = true; 

        yield return new WaitForSeconds(2);

        StartCoroutine(FirstCoroutine());

    }
}
