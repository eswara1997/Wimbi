using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GlobalManager : MonoBehaviour {
    public Coordinate dronePosition = new Coordinate();
    public Coordinate userHand = new Coordinate();
    public GameObject drone;
    public GameObject hand;
	
    
    // Use this for initialization
	void Start () {
         drone = GameObject.Find("PA_Drone");
         hand = GameObject.Find("userHand");
    }
	
	// Update is called once per frame
    //updates the coordinate position of drone and hand stored as "Coordinate" objects
	void Update () {
        
        dronePosition.X = drone.transform.position.x;
        dronePosition.Y = drone.transform.position.y;
        dronePosition.Z = drone.transform.position.z;
        
        userHand.X = hand.transform.position.x;
        userHand.Y = hand.transform.position.y;
        userHand.Z = hand.transform.position.z;

    }
}
