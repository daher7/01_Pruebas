using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPelota : MonoBehaviour {

    public bool inWindZone = false;
    public GameObject windZone;
    Rigidbody rb;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direccion * windZone.GetComponent<WindArea>().fuerza);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            windZone = other.gameObject;
            inWindZone = true;
            print("SOY EL VIENTO");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            inWindZone = false;
        }
    }
}
