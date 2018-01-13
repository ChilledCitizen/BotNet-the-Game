using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour {


	public bool goingUp;
	public Sprite upArrow, forwardArrow;
	public BoxCollider stairs;

	// Use this for initialization
	void Start () {

			if(!stairs)
			{
				stairs = GetComponentInChildren<BoxCollider>();
			}

			stairs.enabled = false;
		
		
	}
	

	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseDown()
	{
		if(!goingUp)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = upArrow;
			stairs.enabled = true;
			//stairs.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			goingUp = true;
		}
		else if(goingUp)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = forwardArrow;			
			stairs.enabled = false;
			goingUp = false;
		}
	}
}
