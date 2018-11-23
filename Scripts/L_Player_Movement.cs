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
    public float movement = 0f;
    private Rigidbody2D rigidBody;

    [Header("Object Interactions")]
    public GameObject[] grounds;
    public GameObject[] checkpoints;
    public List<Collider2D> groundsRB2D;
    public List<Collider2D> checkpointsRB2D;

    public bool collectEnable;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();


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


    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            GameObject.Find("lCamera").GetComponent<L_Camera_Smooth_Follow>().offset.x = 0.5f;
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            GameObject.Find("lCamera").GetComponent<L_Camera_Smooth_Follow>().offset.x = -0.5f;
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

        foreach (var collectable in GameObject.Find("lEventSystem").GetComponent<L_EventSystem_Controller>().Collectables)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (col.gameObject.name == "lCollectableShield")
                {
                    gameObject.GetComponent<L_Player_Status>().shielded = true;
                }
                col.gameObject.SetActive(false);
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
