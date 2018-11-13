using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{

    [SerializeField] int vida = 100;
    //[SerializeField] int danyo = 25;
    [SerializeField] protected ParticleSystem psExplosion;

    public void RecibirDanyo(int danyoRecibido)
    {
        vida -= danyoRecibido;
        if (vida <= 0)
        {
            vida = 0;
            Morir();
        }
    }

    public void Morir()
    {
        ParticleSystem ps = Instantiate(psExplosion, transform.position, Quaternion.identity);
        ps.Play();
        Destroy(gameObject);
    }
}
