using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRay : MonoBehaviour {

    public Camera cam;
    public bool hitToWall = false;
    public int radius;


	// Use this for initialization
	void Start () {

        cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {

        hitToWall = cam.GetComponent<CameraDraw>().PaintRay(gameObject.transform.position, gameObject, radius);

        if(hitToWall)
        {
            Destroy(gameObject);
        }

	}
}
