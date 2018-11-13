using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparaScript : MonoBehaviour
{

    [SerializeField] GameObject prefabBala;
    [SerializeField] Transform ptoGeneracionBalas;
    [SerializeField] int fuerzaBala;
    [SerializeField] float tiempoEntreDisparos = 3f;
    float tiempoAtaque;

    private void Start()
    {
        tiempoAtaque = tiempoEntreDisparos;
    }

    private void Update()
    {
        IntentoDeAtaque();
    }

    private void IntentoDeAtaque()
    {
        tiempoAtaque += Time.deltaTime;
        if (tiempoAtaque >= tiempoEntreDisparos)
        {
            tiempoAtaque = 0;
            // Genera disparo, ataca, lanza
            Disparar();
        }
    }

    private void Disparar()
    {

        GameObject proyectil = Instantiate(
            prefabBala,
            ptoGeneracionBalas.position,
            ptoGeneracionBalas.rotation);

        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaBala);
    }
}
