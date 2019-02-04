using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class FlashlightToggle : MonoBehaviour {

    private GameObject handObj;
    private Hand hand;

	// Use this for initialization
	void Start () {
        handObj = GameObject.Find("RightHand");
        hand = handObj.GetComponent<Hand>();
	}
	
	// Update is called once per frame
	void Update () {
        if (SteamVR_Input.__actions_default_in_ToggleFlashlight.GetChanged(SteamVR_Input_Sources.RightHand))
        {
            if (hand.AttachedObjects.Count > 0 )
            {
                bool b = false;
                foreach(Hand.AttachedObject obj in hand.AttachedObjects)
                {
                    if(obj.attachedObject.tag.Equals("Flashlight"))
                    {
                        b = true;
                    }
                }
                if (!b)
                {
                    return;
                }
                if (GetComponent<Light>().intensity != 0)
                {
                    GetComponent<Light>().intensity = 0;
                }
                else
                {
                    GetComponent<Light>().intensity = 1;
                }
                GetComponent<AudioSource>().Play();
            }
        }
        if(hand.AttachedObjects.Count == 0)
        {
            GetComponent<Light>().intensity = 0;
        }
    }
}
