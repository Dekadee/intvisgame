using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject ghostManager;

	// Use this for initialization
	void Awake () {
		if(GhostScript.instance == null)
        {
            Instantiate(ghostManager);
        }
        DynamicGI.UpdateEnvironment();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
