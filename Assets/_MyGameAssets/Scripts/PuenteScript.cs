using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("El player ha entrado");
            Destroy(gameObject, 5f);
        }
    }
}
