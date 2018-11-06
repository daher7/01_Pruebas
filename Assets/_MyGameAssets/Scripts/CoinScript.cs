using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    [SerializeField] int puntos = 10;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Te doy puntos");
            other.gameObject.GetComponent<PlayerMovement>().IncrementarPuntuacion(puntos);
            Destroy(gameObject);
        }
    }
}       

