using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_move : MonoBehaviour {


    private Rigidbody2D rigidBody;
    public float speed;
    public float direction = 1;
    public float timeToPatrol;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print(gameObject.name);
        if(gameObject.name=="PT (7)")
        {
            
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, direction * speed);
            if (gameObject.transform.position.y > 11.8 - 4.25893)
                direction = -1;
            if (gameObject.transform.position.y < -15 - 4.25893)
                direction = 1;
                
        }
        if (gameObject.name == "PT (10)")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, direction * speed);
            if (gameObject.transform.position.y > -0.49 - 4.25893)
                direction = -1;
            if (gameObject.transform.position.y < -15.5 - 4.25893)
                direction = 1;
        }
       

    }
    
}
