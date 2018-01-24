using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Robot" && col.gameObject.transform.position.y < transform.position.y)
		{
			Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "Robot" && col.gameObject.transform.position.y < transform.position.y)
		{
			Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
		}
	}
}
