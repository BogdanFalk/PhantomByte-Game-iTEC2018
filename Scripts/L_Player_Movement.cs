using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Player_Movement : MonoBehaviour
{

    [Header("Player Movement Attributes")]
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public Vector3 spawnCoors;
    public bool grounded;
    public bool shouldMove = true;
    public float movement = 0f;
    public int questTextIterator = 0;
    public string currentQuestName;
    private Rigidbody2D rigidBody;

    [Header("Object Interactions")]
    public Camera mainCamera;
    public GameObject[] grounds;
    public GameObject[] checkpoints;
    public List<Collider2D> groundsRB2D;
    public List<Collider2D> checkpointsRB2D;

    public List<Vector2> questsLocations;
    public List<string> questTexts;


    public bool canInteract;
    public bool collectEnable;
   
    public L_EventSystem_Controller eventController;
    public GameObject interactNPC;
    private bool roleplayed;
    private GameObject currentQuest;
    private L_GameChoises gameScript;
    public string orientation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        gameScript = GameObject.Find("lGameChoises").GetComponent<L_GameChoises>();

        grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (var ground in grounds)
        {
            groundsRB2D.Add(ground.GetComponent<Collider2D>());
        }

        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        foreach (var checkpoint in checkpoints)
        {
            checkpointsRB2D.Add(checkpoint.GetComponent<Collider2D>());
        }

        foreach (var quest in GameObject.FindGameObjectsWithTag("Quest"))
        {
            questsLocations.Add(quest.transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if(orientation=="left")
        {
            Quaternion quaternion = Quaternion.Euler(0f, 180f, 0);
            gameObject.transform.rotation = quaternion;
        }
        else
        {
            Quaternion quaternion = Quaternion.Euler(0f, 0f, 0);
            gameObject.transform.rotation = quaternion;
        }
        if (shouldMove)
        {
            if (movement > 0f)
            {
                orientation = "right";
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
               // GameObject.Find("lCamera").GetComponent<L_Camera_Smooth_Follow>().offset.x = 0.5f;
            }
            else if (movement < 0f)
            {
                orientation = "left";
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
                //GameObject.Find("lCamera").GetComponent<L_Camera_Smooth_Follow>().offset.x = -0.5f;
            }
            else
            {
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }
            if (Input.GetButtonDown("Jump") && grounded)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && canInteract && shouldMove)
        {
            //interactNPC.SetActive(false);
            print("Roleplay Text");
            
            shouldMove = false;
    
            canInteract = false;



            GameObject.Find("lCanvasText" + currentQuestName + "Text").GetComponent<UnityEngine.UI.Text>().enabled = true;
            GameObject.Find("lCanvasText" + currentQuestName).GetComponent<UnityEngine.UI.Image>().enabled = true;
            switch (currentQuestName)
            {
                case "lQuest0":
                    {
                        questTexts = GameObject.Find("lEventSystem").GetComponent<L_EventSystem_Controller>().quest0;
                        break;
                    }
                case "lQuest1":
                    {
                        questTexts = GameObject.Find("lEventSystem").GetComponent<L_EventSystem_Controller>().quest1;
                        break;
                    }
                default:
                    break;
            }
            questTextIterator = 0;
            
        }

        if(Input.GetKeyDown(KeyCode.F) && !roleplayed && !shouldMove)
        {

                GameObject.Find("lCanvasText" + currentQuestName + "Text").GetComponent<UnityEngine.UI.Text>().enabled = true;
                GameObject.Find("lCanvasText" + currentQuestName).GetComponent<UnityEngine.UI.Image>().enabled = true;
                GameObject.Find("lCanvasText" + currentQuestName + "Text").GetComponent<UnityEngine.UI.Text>().text = questTexts[questTextIterator];
               
            
            if (questTexts[questTextIterator] == "Press G to leave.")
            {
                roleplayed = true;
            }
            questTextIterator++;


        }
        if (Input.GetKeyDown(KeyCode.G) && roleplayed)
        {
            //interactNPC.SetActive(false);
            if(currentQuest.name=="lQuest0")
            {
                print("Roleplay Text OVER!!");
                shouldMove = true;
                print("lCanvasText" + currentQuestName);
                GameObject.Find("lCanvasText" + currentQuestName + "Text").GetComponent<UnityEngine.UI.Text>().enabled = false;
                GameObject.Find("lCanvasText" + currentQuestName).GetComponent<UnityEngine.UI.Image>().enabled = false;
                roleplayed = false;
                print(currentQuest.transform.GetChild(0).name);
                currentQuest.transform.GetChild(0).GetComponent<Collider2D>().isTrigger = true;
                currentQuest.transform.GetChild(1).GetComponent<Collider2D>().isTrigger = true;
                mainCamera.GetComponent<L_Camera_Smooth_Follow>().follow = true;

                //EVENT AT END OF 1st GARDEN
                gameScript.canShoot = true;
                gameScript.canTrap = true;
                gameScript.traps = 4;
                
            }
            else
            {
                print("Roleplay Text OVER!!");
                shouldMove = true;
                print("lCanvasText" + currentQuestName);
                GameObject.Find("lCanvasText" + currentQuestName + "Text").GetComponent<UnityEngine.UI.Text>().enabled = false;
                GameObject.Find("lCanvasText" + currentQuestName).GetComponent<UnityEngine.UI.Image>().enabled = false;
                roleplayed = false;
                print(currentQuest.transform.GetChild(0).name);
                currentQuest.transform.GetChild(0).GetComponent<Collider2D>().isTrigger = true;
                currentQuest.transform.GetChild(1).GetComponent<Collider2D>().isTrigger = true;
                mainCamera.GetComponent<L_Camera_Smooth_Follow>().follow = true;
                //Event at end of 2nd Garden
                if(gameScript.mob1==1)
                {
                    gameScript.canPet = true;
                }
                else
                {
                    gameScript.canShield = true;
                }
            }
            gameScript.zenQuest++;

        }



        foreach (var quest in GameObject.FindGameObjectsWithTag("Quest"))
        {    
           
            if (gameObject.transform.position.x > quest.transform.position.x)
            {
                currentQuest = quest;
                currentQuestName = quest.name;
                mainCamera.GetComponent<L_Camera_Smooth_Follow>().follow = false;

                quest.transform.GetChild(0).transform.position = new Vector3(mainCamera.transform.position.x - 8f, 0);
                quest.transform.GetChild(1).transform.position = new Vector3(mainCamera.transform.position.x + 9f, 0);

                quest.transform.GetChild(0).GetComponent<Collider2D>().isTrigger = false;
                quest.transform.GetChild(1).GetComponent<Collider2D>().isTrigger = false;

            }
        }
        


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "NPC")
        foreach ( var npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if(col == npc.GetComponent<Collider2D>())
            {
                canInteract = true;
                interactNPC = npc;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag=="NPC")
        foreach (var npc in GameObject.FindGameObjectsWithTag("NPC"))
        {
            if (col == npc.GetComponent<Collider2D>())
            {
                canInteract = false;
                interactNPC = null;
            }
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {

        foreach (var checkpoint in checkpointsRB2D)
        {
            if (col == checkpoint)
            {
                checkpoint.gameObject.SetActive(false);
                spawnCoors = checkpoint.gameObject.GetComponent<Transform>().position;
            }

        }
        
        //if(eventController.Collectables.Count!=0)
        foreach (var collectable in eventController.Collectables)
        {
            if (col == collectable.GetComponent<Collider2D>())
            {
                print("Collected");
                //if (Input.GetKeyDown(KeyCode.F))
                //{
                if (col.gameObject.name == "lCollectableShield")
                {
                    gameObject.GetComponent<L_Player_Status>().shielded = true;
                }
                col.gameObject.SetActive(false);
                //}
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        foreach (var ground in groundsRB2D)
        {
            if (col.collider == ground)
                grounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        foreach (var ground in groundsRB2D)
        {
            if (col.collider == ground)
                grounded = false;

        }
    }

}
