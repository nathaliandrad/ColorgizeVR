﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBallHitsEffect : MonoBehaviour
{ // test
    // ANIMATION SCRIPT

    public Material roomMaterial;
    public bool canAddForce;

    public void Start()
    {
        canAddForce = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (SetUpText.instance.gameCanStart)
        {
            // Adding force to the ball in the middle of the room to bounce every time it gets hit
            if (collision.gameObject.name == "38_prop_ball")
            {
                if (canAddForce)
                {
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 250f);
                    canAddForce = false;
                }
            }

            if (collision.gameObject.GetComponent<Animator>())
            {
                collision.gameObject.GetComponent<Animator>().SetBool("colliding", true);
            }
            else
            {
                collision.transform.parent.GetComponent<Animator>().SetBool("colliding", true);
            }
        }
    }
}
