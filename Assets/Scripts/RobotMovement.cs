using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour {

    public bool goingRight, isGrounded;
    public float movementSpeed, timer;
    private float deltaTime;

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

    void OnCollision2DEnter(Collision2D other)
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
                
            }
            else 
            {
                goingRight = true;
            }
        }

       if (other.gameObject.tag == "Robot")
        {
            Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), other.gameObject.GetComponent<PolygonCollider2D>());
        }
    }

    private void OnCollision2DStay(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollision2DExit(Collision2D other)
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
