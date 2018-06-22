using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristFollower : MonoBehaviour {

    public GameObject wrist;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(wrist.transform.position.x+0.01f, wrist.transform.position.y + 0.02f, wrist.transform.position.z + 0.03336927f);
        this.transform.rotation = wrist.transform.rotation;
		
	}
}
