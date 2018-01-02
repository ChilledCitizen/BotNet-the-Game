using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{

    public GameObject ramp;
    public bool rampIsUp;
    public float rampAngle;

    // Use this for initialization
    void Start()
    {

        ramp = gameObject.GetComponentInChildren<BoxCollider>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        if (!ramp)
        {
            ramp = gameObject.GetComponentInChildren<BoxCollider>().gameObject;

        }

        if (rampIsUp)
        {
            //updateRampAngle(true);
            for(int i = 0; i < rampAngle; i++)
			{
				transform.Rotate(0,0,i);
			}
        }
        else
        {
            //updateRampAngle(false);
            for(int i = (int)rampAngle; i > 0; i--)
			{
				transform.Rotate(0,0,i);
			}
        }

    }

    public void updateRampAngle(bool Angled)
    {
        if (Angled)
        {
			for(int i = 0; i < rampAngle; i++)
			{
				transform.Rotate(0,0,i);
			}
        }
		else
		{
			for(int i = (int)rampAngle; i > 0; i--)
			{
				transform.Rotate(0,0,i);
			}
		}
    }

}
