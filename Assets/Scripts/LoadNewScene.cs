using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {


    [SerializeField]
    public string sceneName;

    public void onDoorInteraction()
    {
        SceneManager.LoadScene(sceneName);

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
