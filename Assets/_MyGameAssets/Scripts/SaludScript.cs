using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludScript : MonoBehaviour {

    [SerializeField] int salud = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().RecibirSalud(salud);
            print("Te doy salud");
            Destroy(gameObject);
        }
    }
}
