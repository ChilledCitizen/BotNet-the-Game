using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour {

    public bool goingRight, isGrounded;
    public float movementSpeed, timer;
    private float deltaTime;

    [HideInInspector]
    public Rigidbody rb;

    [HideInInspector]
    public Vector2 location;


	// Use this for initialization
	void Start () {

        goingRight = true;
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
		
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

    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.tag == "Wall")
        {
            /*Collider col = other.gameObject.GetComponent<Collider>();

            Vector3 contactPoint = other.contacts[0].point;
            Vector3 center = col.bounds.center;

            bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;
            */

            if (goingRight == true)
            {
                goingRight = false;
                transform.Rotate(0,180,0);
                
            }
            else 
            {
                goingRight = true;
                transform.Rotate(0,180,0);
                
            }
        }

       if (other.gameObject.tag == "Robot")
        {
            Physics.IgnoreCollision(GetComponent<SphereCollider>(), other.gameObject.GetComponent<SphereCollider>());
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;


        }
    }

    void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "Floor")
        {

            StartCoroutine(DropFromLedge());
            isGrounded = false;
        }

    }

    IEnumerator DropFromLedge()
    {
        yield return new WaitForSeconds(timer);
    }

}
