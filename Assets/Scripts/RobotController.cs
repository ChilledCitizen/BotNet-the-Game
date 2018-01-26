using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    public bool goingRight, isGrounded;
    public float movementSpeed, timer;
    private float deltaTime;
    public GameObject wallModel;
    public GameObject rampModel;

    public GameObject explosionModel;

    [HideInInspector]
    public Rigidbody rb;

    [HideInInspector]
    public Vector2 location;

    public GameController gameController;

    public GameController.ChoosenMode choosenMode;

    // Use this for initialization
    void Start()
    {

        goingRight = true;
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

    }

    // Update is called once per frame
    void Update()
    {

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


        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Door")
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
                transform.Rotate(0, 180, 0);

            }
            else
            {
                goingRight = true;
                transform.Rotate(0, 180, 0);

            }
        }

        if (other.gameObject.tag == "Robot")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
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

    void OnMouseDown()
    {
        switch (choosenMode)
        {
            case GameController.ChoosenMode.explosion:
                Explode();
                break;

            case GameController.ChoosenMode.ramp:
                MakeRamp();
                break;

            case GameController.ChoosenMode.wall:
                MakeWall();
                break;

            case GameController.ChoosenMode.nothing:
                break;

            default:
                Debug.LogError("Something went wrong");
                break;

        }
    }

    void Explode()
    {
        Debug.LogWarning("Boom");
        Instantiate(explosionModel,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    void MakeRamp()
    {


        Debug.LogWarning("Ramp");

        Instantiate(rampModel,new Vector3(transform.position.x,transform.position.y-0.35f,transform.position.z),Quaternion.identity);
        Destroy(gameObject);
        
    }

    void MakeWall()
    {
        Debug.LogWarning("Wall");
        Instantiate(wallModel,transform.position,Quaternion.identity);
        Destroy(gameObject);
        
    }



    IEnumerator DropFromLedge()
    {
        yield return new WaitForSeconds(timer);
    }

}
