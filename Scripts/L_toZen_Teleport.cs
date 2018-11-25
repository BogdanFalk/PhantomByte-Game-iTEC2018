using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L_toZen_Teleport : MonoBehaviour {

    // Use this for initialization
    public int levelToGoTo;
    private L_GameChoises gameScript;
    public Image fader;
    public Text faderText;
    public Scene currentScene;
	void Start () {
        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();
        fader = GameObject.Find("Fader").GetComponent<Image>();
        faderText = GameObject.Find("Text").GetComponent<Text>();
        currentScene = SceneManager.GetActiveScene();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        
        if (col.collider.gameObject.name == "lPlayer")
        {
            
            fader.GetComponent<L_Fader>().FadeIn();
            StartCoroutine(FirstCoroutineZen1());
            
        }
                

        
    }


    IEnumerator FirstCoroutineZen1()
    {
        print(Time.time);
        faderText.enabled = true;
        yield return new WaitForSeconds(2);
        if (gameScript.zenQuest == 1)
            SceneManager.LoadScene(1); //Level 1
        if (gameScript.zenQuest == 2 && currentScene.name == "01")
            SceneManager.LoadScene(4); //Level 2
        if (currentScene.name == "2")
            SceneManager.LoadScene(5); //Level 3
        if (gameScript.zenQuest == 1 && currentScene.name == "1")
            SceneManager.LoadScene(3); //second quest Zen Garden "01"
        if (gameScript.zenQuest == 0)
            SceneManager.LoadScene(2); //first Zen Garden


   

    }
}
