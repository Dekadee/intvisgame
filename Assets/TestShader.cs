using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShader : MonoBehaviour {

    [SerializeField]
    Transform flashlight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.SetVector("_LightPos", flashlight.position);
        GetComponent<Renderer>().material.SetVector("_LightDir", flashlight.forward);
        GetComponent<Renderer>().material.SetFloat("_LightInt", 1.0f);
    }
}
