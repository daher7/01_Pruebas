using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonScript : MonoBehaviour {

    [SerializeField] int vidaOtorgada = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().RecibirVida(vidaOtorgada);
            print("Te Doy una vida");
            Destroy(gameObject);
        }
    }
}
