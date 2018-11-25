using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L_EventSystem_Controller : MonoBehaviour {

    Scene currentScene;
    // Use this for initialization
    [Header("Level Attributes")]

    public List<GameObject> CheckpointsObj;
    public List<Vector2> CheckpointsCoords;
    public List<GameObject> Collectables;
    public bool[] shouldStopOnQuest = { true, true, false, false };

    [Header("Reset Attributes")]
    public Vector3 playerInitialPos;
    public Vector3 mob1; public Vector3 mob2; public Vector3 boss;
    public List<Vector3> parallaxInitialPos;
    public List<GameObject> parallaxs;

    public List<string> quest0;
    public List<string> quest1;


    void Start () {

        currentScene = SceneManager.GetActiveScene();
        //quest0.Add("PANDA : Your journey starts here my friend! After some talk with the panda blah blah blah blah");
        quest0.Add("PANDA : Your journey starts here my friend!");
        quest0.Add("After some talk with the panda; he gives you the first choise of many that would follow");
        quest0.Add("Restore the land without all the new abominations and cleanse the world");
        quest0.Add("OR...");
        quest0.Add("Save the right monsters and merge the two worlds toghether");
        quest0.Add("Press G to leave.");

        //ADD TEXT for second zen
        quest1.Add("PANDA : Now that you made your choice...");
        quest1.Add("PANDA : I shall give you this new power and go to restore the OLD WORLD");
        quest1.Add("YOU: I will return some day master PANDA with hope for the NEW WORLD");
        quest1.Add("Press G to leave.");
        


        playerInitialPos = GameObject.Find("lPlayer").transform.position;
        if (currentScene.name == "1")
            mob1 = GameObject.Find("lMob1").transform.position;
        if(currentScene.name == "2")
        {
            mob1 = GameObject.Find("lMob1").transform.position;
            mob2 = GameObject.Find("lMob1 (1)").transform.position;
            boss = GameObject.Find("Boss").transform.position;
        }

        foreach (var parallax in GameObject.FindGameObjectsWithTag("Parallax"))
        {
            parallaxInitialPos.Add(parallax.transform.position);
            parallaxs.Add(parallax);
        }

        foreach (var checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")) 
        {
            CheckpointsObj.Add(checkpoint);
        }

        foreach(var checkpointObj in CheckpointsObj)
        {
            CheckpointsCoords.Add(new Vector2(checkpointObj.GetComponent<Transform>().position.x, checkpointObj.GetComponent<Transform>().position.y));
        }

        foreach (var collectable in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            Collectables.Add(collectable);
        }



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetScene()
    {
        int i = 0;
        if (currentScene.name == "1")
        {
            GameObject.Find("Fader").GetComponent<L_Fader>().FadeIn();
            
            GameObject.Find("lPlayer").GetComponent<L_Player_Status>().health = 100;
            GameObject.Find("lPlayer").GetComponent<L_Player_Status>().hunger = 50;
            GameObject.Find("lPlayer").GetComponent<L_Player_Status>().restorePower = 0;
            GameObject.Find("lPlayer").transform.position = playerInitialPos;

            GameObject.Find("lMob1").transform.position = mob1;
            GameObject.Find("lMob1").GetComponent<L_Mob_Status>().health = 100;
            GameObject.Find("lMob1").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("lMob1").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("lMob1").GetComponent<EdgeCollider2D>().enabled = true;
            GameObject.Find("lMob1").GetComponent<L_Mob1_Shoot>().enabled = true;

            GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob1 = 0;
        }
        else if(currentScene.name == "2")
        {
            GameObject.Find("Fader").GetComponent<L_Fader>().FadeIn();
            
            GameObject.Find("lPlayer").GetComponent<L_Player_Status>().health = 100;
            GameObject.Find("lPlayer").GetComponent<L_Player_Status>().hunger = 50;
            GameObject.Find("lPlayer").GetComponent<L_Player_Status>().restorePower = 0;
            GameObject.Find("lPlayer").transform.position = playerInitialPos;

            GameObject.Find("lMob1").transform.position = mob1;
            GameObject.Find("lMob1").GetComponent<L_Mob_Status>().health = 100;
            GameObject.Find("lMob1").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("lMob1").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("lMob1").GetComponent<EdgeCollider2D>().enabled = true;
            GameObject.Find("lMob1").GetComponent<L_Mob1_Shoot>().enabled = true;
        
           


            GameObject.Find("lMob1 (1)").transform.position = mob2;
            GameObject.Find("lMob1 (1)").GetComponent<L_Mob_Status>().health = 100;
            GameObject.Find("lMob1 (1)").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("lMob1 (1)").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("lMob1 (1)").GetComponent<EdgeCollider2D>().enabled = true;
            GameObject.Find("lMob1 (1)").GetComponent<L_Mob1_Shoot>().enabled = true;

            GameObject.Find("Boss").transform.position = boss;
            GameObject.Find("Boss").GetComponent<L_Mob_Status>().health = 100;
            GameObject.Find("Boss").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Boss").GetComponent<CircleCollider2D>().enabled = true;
          
            GameObject.Find("Boss").GetComponent<L_Mob1_Shoot>().enabled = true;

            //GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob2 = 0;
            //GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob2 = 0;
            //GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob2 = 0;
            //GameObject.Find("lGameChoises").GetComponent<L_GameChoises>().mob2 = 0;
        }

        foreach (var parallax in parallaxs)
        {
            parallax.transform.position = parallaxInitialPos[i];
        }
        
        StartCoroutine(FirstCoroutine());
    }

    IEnumerator FirstCoroutine()
    {
        print(Time.time);
       

        yield return new WaitForSeconds(2);


        print(Time.time);
        GameObject.Find("Fader").GetComponent<L_Fader>().FadeOut();

    }
}
