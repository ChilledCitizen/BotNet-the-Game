using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float movementSpeed;
    // private Vector3 currentPos;
    // private Vector3 lastPos;

    // Use this for initialization
    void Start()
    {

        movementSpeed = movementSpeed / 10;
    }

    // Update is called once per frame
    void Update()
    {

        // currentPos = transform.position;

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * movementSpeed);
        }

        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * movementSpeed);
        }
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * movementSpeed);

        }
        else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * movementSpeed);
        }




        //     if (lastPos != currentPos)
        //     {
        //         lastPos = currentPos;

        //     }






        // }


        // void OnCollisionEnter(Collision col)
        // {
        //     if (col.gameObject.tag == "Wall")
        //     {
        //         transform.position = new Vector3(lastPos.z,lastPos.y,lastPos.z);
        //     }
        // }

    }
}
