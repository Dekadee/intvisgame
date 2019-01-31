using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GeneratorHatch : MonoBehaviour {

    [SerializeField]
    private Collider handleCol;
    [SerializeField]
    private LinearMapping mapping;
    [SerializeField]
    private AudioSource audioHatch;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(mapping.value > 0.5)
        {
            handleCol.enabled = true;
        }
        else
        {
            handleCol.enabled = false;
        }
	}
}
