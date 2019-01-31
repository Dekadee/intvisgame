using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GiveFlashlight : MonoBehaviour {

    [SerializeField]
    private GameObject flashlight;

    bool first = true;

	// Use this for initialization
	void Start () {
        GameObject g = Instantiate(flashlight);
        GetComponent<Player>().rightHand.AttachObject(g, GrabTypes.Grip, Hand.defaultAttachmentFlags | Hand.AttachmentFlags.DetachOthers);
        StartCoroutine(HideControllerForever());
        SteamVR_Fade.Start(new Color(0, 0, 0, 1), 0);
        SteamVR_Fade.Start(new Color(0, 0, 0, 0), 2);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator HideControllerForever()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Player>().rightHand.HideController(true);
    }
}
