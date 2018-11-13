using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    [SerializeField] int danyoEnemigo = 20;
    [SerializeField] float vidaCuchillo = 2.0f;

    private void Start()
    {
        Destroy(gameObject, vidaCuchillo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            other.gameObject.GetComponent<EnemigoMovil>().RecibirDanyo(danyoEnemigo);
            DestruirCuchillo();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            print("ME HAN DADO");
            DestruirCuchillo();
        }
    }

    private void DestruirCuchillo()
    {
        Destroy(gameObject);
    }
}
