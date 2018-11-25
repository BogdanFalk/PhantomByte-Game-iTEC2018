using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Fader : MonoBehaviour {

    public float fadeSpeed;

    public Image screen;

    public bool change;
    // Use this for initialization
    void Start()
    {
        screen.CrossFadeAlpha(0, fadeSpeed, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeIn()
    {
        print("JES");
        GetComponent<Image>().CrossFadeAlpha(1f, fadeSpeed, false);
    }

    public void FadeOut()
    {
        print("Bye");
        GetComponent<Image>().CrossFadeAlpha(0f, fadeSpeed, false);

    }



}
