using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour {

    [SerializeField] float vidaCuchillo = 2.0f;
   
	void Start () {

    }
	
	void Update ()
    {
        DestruirCuchillo();
    }

    private void DestruirCuchillo()
    {
        Destroy(this.gameObject, vidaCuchillo);
    }
}
