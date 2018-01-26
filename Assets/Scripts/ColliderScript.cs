using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{


    public bool isIgnoringCol = false;
    public GameObject robot;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (robot)
        {
            // if (isIgnoringCol)

            if (robot.transform.position.y < this.transform.position.y)
            {
                Debug.Log("Ignore");

                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), robot.GetComponent<Collider>());

				isIgnoringCol = true;

            }
            else if (isIgnoringCol)
			{
                Debug.Log("Unignore");

                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), robot.GetComponent<Collider>(), false);
				isIgnoringCol = false;
            }
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Robot")
        {
            robot = col.gameObject;
            
        }

    }

   
}
