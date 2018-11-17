using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    [SerializeField] int danyoEnemigo = 20;
    [SerializeField] int danyoPlayer = 25;
    [SerializeField] float vidaCuchillo = 1.0f;

    private void Start()
    {
        Destroy(gameObject, vidaCuchillo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            other.gameObject.GetComponent<EnemigoScript>().RecibirDanyo(danyoEnemigo);
            DestruirCuchillo();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            print("ME HAN DADO");
            other.gameObject.GetComponent<PlayerMovement>().QuitarSalud(danyoPlayer);
            DestruirCuchillo();
        }
    }

    private void DestruirCuchillo()
    {
        Destroy(gameObject);
    }
}
