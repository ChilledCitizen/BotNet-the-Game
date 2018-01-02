using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float movementSpeed;

	// Use this for initialization
	void Start () {

        movementSpeed = movementSpeed / 10;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * movementSpeed);
        }

        else if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * movementSpeed);
        }


    }
}
