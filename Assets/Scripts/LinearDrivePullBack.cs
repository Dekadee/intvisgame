using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LinearDrivePullBack : MonoBehaviour {

    public LinearMapping mapping;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(mapping.value > 0)
        {
            mapping.value -= ((mapping.value * 0.9f) + 0.1f) * Time.deltaTime * speed;
        }
	}
}
