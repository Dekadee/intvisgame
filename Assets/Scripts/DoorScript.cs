﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class DoorScript : MonoBehaviour
    {

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

        private Interactable interactable;

        //-------------------------------------------------
        void Awake()
        {
            interactable = this.GetComponent<Interactable>();
        }

        private GameObject handObj;
        private Hand hand;

        // Use this for initialization
        void Start()
        {
            handObj = GameObject.Find("RightHand");
            hand = handObj.GetComponent<Hand>();
        }


        //-------------------------------------------------
        // Called when a Hand starts hovering over this object
        //-------------------------------------------------
        private void OnHandHoverBegin(Hand hand)
        {

        }


        //-------------------------------------------------
        // Called when a Hand stops hovering over this object
        //-------------------------------------------------
        private void OnHandHoverEnd(Hand hand)
        {

        }


        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand2)
        {
           if(SteamVR_Input.__actions_default_in_GrabPinch.GetStateDown(hand2.handType))
           {
                if (hand.AttachedObjects.Count > 0)
                {
                    foreach (Hand.AttachedObject obj in hand.AttachedObjects)
                    {
                        if (obj.attachedObject.tag.Equals("Flashlight"))
                        {
                            SteamVR_Fade.Start(new Color(0f, 0f, 0f, 1), 6);
                            StartCoroutine(PlayAudio());
                            return;
                        }
                    }
                }

               
           }
        }

        IEnumerator PlayAudio()
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            GetComponent<SteamVR_LoadLevel>().Trigger();
        }


        //-------------------------------------------------
        // Called when this GameObject becomes attached to the hand
        //-------------------------------------------------
        private void OnAttachedToHand(Hand hand)
        {

        }


        //-------------------------------------------------
        // Called when this GameObject is detached from the hand
        //-------------------------------------------------
        private void OnDetachedFromHand(Hand hand)
        {

        }


        //-------------------------------------------------
        // Called every Update() while this GameObject is attached to the hand
        //-------------------------------------------------
        private void HandAttachedUpdate(Hand hand)
        {

        }


        //-------------------------------------------------
        // Called when this attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusAcquired(Hand hand)
        {
        }


        //-------------------------------------------------
        // Called when another attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusLost(Hand hand)
        {
        }
    }
}
