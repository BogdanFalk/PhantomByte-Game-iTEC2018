using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_EventSystem_Controller : MonoBehaviour {

    // Use this for initialization

    public List<GameObject> CheckpointsObj;
    public List<Vector2> CheckpointsCoords;
    public List<GameObject> Collectables;

	void Start () {
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
}
