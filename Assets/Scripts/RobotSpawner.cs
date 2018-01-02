using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour {

    public int amountOfRobots;
    public float spawnRate, deltaTime;
    public GameObject robot;

	// Use this for initialization
	void Start () {

        deltaTime = spawnRate;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (amountOfRobots > 0)
        {
            deltaTime -= Time.deltaTime;
        }
        

        if (deltaTime <= 0 && amountOfRobots > 0)
        {
            Instantiate(robot);
            deltaTime = spawnRate;
            amountOfRobots--;
        }

		
	}
}
