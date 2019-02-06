using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRotating : MonoBehaviour {

    private bool rotate = false;

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            canvas.SetActive(true);
        }
       
	}

    public void startRotation()
    {
        rotate = true;
    }
}
