﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col)
	{
		Destroy(gameObject);
	}
}
