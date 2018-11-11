using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Te doy el POWER");
            other.gameObject.GetComponent<PlayerMovement>().RecibirInvulnerabilidad();
            Destroy(gameObject);
        }
    }
}
