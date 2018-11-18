using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludScript : MonoBehaviour
{
    [SerializeField] int salud = 50;
    [SerializeField] protected ParticleSystem psSalud;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().RecibirSalud(salud);
            // Llamada al sistema de particulas
            ParticleSystem ps = Instantiate(
                psSalud,
                transform.position,
                Quaternion.identity);
            psSalud.Play();

            Destroy(gameObject);
        }
    }
}
