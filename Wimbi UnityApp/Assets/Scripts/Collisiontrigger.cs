using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisiontrigger : MonoBehaviour {

    /// <summary>
    /// Detect collisions with the wrist
    /// Track which fingers are bent, send to GestureManager which manages all states
    /// </summary>
    public GestureManager gestManager;
	


    void OnTriggerEnter(Collider collisionInfo)
    {
        Debug.Log(collisionInfo);
        if (collisionInfo.transform.name.Contains("R_pinky_end"))
        {
            gestManager.pinkyBent = true;
            Debug.Log("caught Pinky");
        }
        else if (collisionInfo.transform.name.Contains("R_ring_end"))
        {
            gestManager.ringBent = true;
            Debug.Log("caught Ring");


        }
        else if (collisionInfo.transform.name.Contains("R_middle_end"))
        {
            gestManager.middleBent = true;
            Debug.Log("caught Middle");



        }
        else if (collisionInfo.transform.name.Contains("R_index_end"))
        {
            gestManager.indexBent = true;
            Debug.Log("caught Index");


        }
        //else if (collisionInfo.transform.name == "R_thumb_end")
        //{
        //    gestManager.currentHandState |= GestureManager.fingerState.thumbFolded;
        //}


        //print("Contact with " + collisionInfo.transform.name);
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.transform.name == "R_pinky_end")
        {
            gestManager.pinkyBent = false;

        }
        else if (collisionInfo.transform.name == "R_ring_end")
        {
            gestManager.ringBent = false;

        }
        else if (collisionInfo.transform.name == "R_middle_end")
        {
            gestManager.middleBent = false;


        }
        else if (collisionInfo.transform.name == "R_index_end")
        {
            gestManager.indexBent = false;
        }
        //else if (collisionInfo.transform.name == "R_thumb_end")
        //{
        //    gestManager.currentHandState &= ~GestureManager.fingerState.thumbFolded;
        //}

    }



    }
