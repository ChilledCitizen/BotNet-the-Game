using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float timeOfExplosion;
    public float colliderExpansionRate = 1;
    private float deltaTime;

    public SphereCollider explosionCol;


    void Awake()
    {
        explosionCol = GetComponent<SphereCollider>();
    }

    void Update()
    {
        deltaTime += Time.deltaTime;


        explosionCol.radius = deltaTime * colliderExpansionRate;

        if (explosionCol.radius >= 1)
        {
            Destroy(gameObject);
        }
		
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Door")
        {
            Debug.Log("ExplosionHit");
            Destroy(col.gameObject);
        }
    }


	
}
