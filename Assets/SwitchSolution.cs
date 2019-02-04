using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SwitchSolution : MonoBehaviour {

    [SerializeField]
    LinearMapping first;

    [SerializeField]
    LinearMapping second;

    [SerializeField]
    LinearMapping third;

    [SerializeField]
    GameObject teleportPoint;

    bool solution = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (solution)
            return;
		if(first.value > 0.95 && second.value < 0.05 && third.value > 0.95)
        {
            solution = true;
            teleportPoint.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
	}
}
