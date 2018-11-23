using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Camera_Smooth_Follow : MonoBehaviour {

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        offset.y = 0.7f;
        offset.x = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
           
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            targetPos.y /= 2;
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }

    
}
