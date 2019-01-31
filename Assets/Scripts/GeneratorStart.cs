using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GeneratorStart : MonoBehaviour {

    [SerializeField]
    private LinearMapping mapping;

    [SerializeField]
    private Light[] lights;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(mapping.value > 0)
        {
            //Play sound here
        }
        if(mapping.value > 0.85)
        {
            foreach(Light light in lights)
            {
                light.enabled = true;
            }
            GetComponent<AudioSource>().Play();
        }
	}
}
