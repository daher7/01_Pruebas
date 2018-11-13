using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovil : MonoBehaviour
{
    [SerializeField] int vida = 100;
    [SerializeField] int danyo = 25;

    bool haciaDerecha = true;
    [SerializeField] float speed = 1f;
    [SerializeField] int limDerecha = 50;
    [SerializeField] int limIzquierda = -50;
    int mueve = 0;
    [SerializeField] protected ParticleSystem psExplosion;

    void Update()
    {
        if (haciaDerecha)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            if (mueve >= limDerecha)
            {
                haciaDerecha = false;
                CambiarSentido();
            }
            mueve++;
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            if (mueve <= limIzquierda)
            {
                haciaDerecha = true;
                CambiarSentido();
            }
            mueve--;
        }
    }

    private void CambiarSentido()
    {
        if (haciaDerecha)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
 
    public void RecibirDanyo(int danyoRecibido)
    {
        vida -= danyoRecibido;
        if(vida <= 0)
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
