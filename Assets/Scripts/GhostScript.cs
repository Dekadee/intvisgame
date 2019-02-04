using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    private GameObject flashlightObj;
    private Transform flashlight;
    private Light lightInt;

    private List<GameObject> ghostObjs = new List<GameObject>();

    public static GhostScript instance = null;

    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
       // DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        //ghostObjs = GameObject.FindGameObjectsWithTag("Ghost");
        flashlightObj = GameObject.Find("FlashlightLight");
        flashlight = flashlightObj.transform;
        lightInt = flashlightObj.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject obj in ghostObjs)
        {
            obj.GetComponent<Renderer>().material.SetVector("_LightPos", flashlight.position);
            obj.GetComponent<Renderer>().material.SetVector("_LightDir", flashlight.forward);
            obj.GetComponent<Renderer>().material.SetFloat("_LightInt", lightInt.intensity);
        }
    }

    public void AddGhost(GameObject ghost)
    {
        ghostObjs.Add(ghost);
    }

    public void RemoveGhost(GameObject ghost)
    {
        ghostObjs.Remove(ghost);
    }
}
