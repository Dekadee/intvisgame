using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GhostScript.instance.AddGhost(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        GhostScript.instance.RemoveGhost(this.gameObject);
    }
}
