using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DropoffHand : MonoBehaviour {

    [SerializeField]
    public List<string> names;

    public GameObject pickupPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Hand>())
        {
            Hand hand = other.gameObject.GetComponent<Hand>();
            List<Hand.AttachedObject> delet = new List<Hand.AttachedObject>(hand.AttachedObjects);
            foreach(Hand.AttachedObject obj in delet)
            {
                if (names.Contains(obj.attachedObject.tag))
                {
                    
                    hand.DetachObject(obj.attachedObject);
                    //Destroy(pickupPoint);
                    SteamVR_Fade.Start(new Color(0f, 0f, 0f, 1), 6);
                    GameObject.Find("SceneLoader").GetComponent<SteamVR_LoadLevel>().Trigger();

                }
            }
        }
    }
}
