using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbejaScript : MonoBehaviour {

    [SerializeField] int danyoEnemigo = 20;
    [SerializeField] float vidaAbeja = 1.0f;

    private void Start()
    {
        Destroy(gameObject, vidaAbeja);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            other.gameObject.GetComponent<EnemigoScript>().RecibirDanyo(danyoEnemigo);
            DestruirAbeja();
        }
    }

    private void DestruirAbeja()
    {
        Destroy(gameObject);
    }
}
