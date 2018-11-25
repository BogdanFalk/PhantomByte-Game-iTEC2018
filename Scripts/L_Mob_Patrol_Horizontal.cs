using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Mob_Patrol_Horizontal : MonoBehaviour {

    private Rigidbody2D rigidBody;
    public float speed;
    public float direction = 1;
    public float timeToPatrol;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(FirstCoroutine());
    }
	
	// Update is called once per frame
	void Update () {
        rigidBody.velocity = new Vector2(direction * speed, rigidBody.velocity.y);
    }

    IEnumerator FirstCoroutine()
    {

        direction = -1;
        Quaternion quaternion = Quaternion.Euler(0f, 180f, 0);
        gameObject.transform.rotation = quaternion;
        yield return new WaitForSeconds(timeToPatrol);



        StartCoroutine(SecondCoroutine());

    }

    IEnumerator SecondCoroutine()
    {

        direction = 1;
        Quaternion quaternion = Quaternion.Euler(0f, 0f, 0);
        gameObject.transform.rotation = quaternion;
        yield return new WaitForSeconds(timeToPatrol);

        StartCoroutine(FirstCoroutine());

    }
}
