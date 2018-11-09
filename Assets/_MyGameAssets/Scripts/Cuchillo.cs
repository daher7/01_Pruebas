using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour {

    [SerializeField] float vidaCuchillo = 2.0f;
   
	void Start () {

        Invoke("DestruirCuchillo", vidaCuchillo);

    }
	
    private void DestruirCuchillo()
    {
        Destroy(gameObject);
    }
}
