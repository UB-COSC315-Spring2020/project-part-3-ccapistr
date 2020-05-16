﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    [SerializeField]
    private Text pickUpText;

    private bool pickUpAllowed;
    //public Transform interactionTransform;

    // Use this for initialization
    private void Start()
    {

    }

    public virtual void Interact()
    {
        //this is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            pickUpText.gameObject.SetActive(false);
            Interact();
            //PickUp();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
    /**
    private void PickUp()
    {
        Destroy(gameObject);
    }
    */
}