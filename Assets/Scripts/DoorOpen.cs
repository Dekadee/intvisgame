using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animation>().Play("DoorOpen");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
