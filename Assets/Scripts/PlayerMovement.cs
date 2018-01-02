using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D rb2D;

    public GameObject testray;
    public bool grounded;

    public GameObject testray2;
    public bool headHit;

    public GameObject testray3;
    public bool frontHit;

    public GameObject ammoSpawn;
    public GameObject gunRotator;
    public GameObject ammo;

    public CameraDraw cameraDraw;

    public float jumpForce;
    public float movementSpeed; 

	// Use this for initialization
	void Start () {

        rb2D = GetComponent<Rigidbody2D>();
        cameraDraw = cam.GetComponent<CameraDraw>();
	}
	
	// Update is called once per frame
	void Update () {

        grounded = cameraDraw.DrawRay(testray.transform.position);
        headHit = cameraDraw.DrawRay(testray2.transform.position);
        frontHit = cameraDraw.DrawRay(testray3.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(transform.localScale.x * ammoSpawn.transform.right * 5, ForceMode2D.Impulse);
        }
               

        if(headHit == true && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        }


        if (grounded == true)
        {
            
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.gravityScale = 0;
        }

        if(grounded == false)
        {
            rb2D.gravityScale = 0.5f;

        }

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    
        if(Input.GetAxis("Horizontal") > 0)
        {
            if (frontHit == true)
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            }
            else
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
            transform.localScale = new Vector3(1, 1, 1);
        }else if(Input.GetAxis("Horizontal") < 0)       
        {
            if (frontHit == true)
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            }
            else
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime * -1);
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
