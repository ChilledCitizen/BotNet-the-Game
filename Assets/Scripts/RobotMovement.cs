﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour {

    public bool goingRight, isGrounded;
    public float movementSpeed;

    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public Vector2 location;


	// Use this for initialization
	void Start () {

        goingRight = true;
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        location = transform.position;

        if (goingRight == true && isGrounded)
        {
            rb.velocity = Vector2.right * movementSpeed;
        }
        if (goingRight == false && isGrounded)
        {
            rb.velocity = Vector2.left * movementSpeed;
        }

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag == "Wall")
        {
            if (goingRight == true)
            {
                goingRight = false;
            }
            else
            {
                goingRight = true;
            }
        }

       /* if (other.gameObject.tag == "Robot")
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }*/
    }

    /*void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Robot")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }*/
}
