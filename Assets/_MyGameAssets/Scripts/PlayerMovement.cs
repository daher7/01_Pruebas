using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 6.0f;
    [SerializeField] float xPos;
    bool irDerecha = true;
    Rigidbody rbPlayer;
    // VARIABLES PARA EL SALTO
    [SerializeField] float jumpForce = 300.0f;
    [SerializeField] float distanciaSuelo = 0.1f;
    // VARIABLES PARA EL DISPARO
    [SerializeField] GameObject prefabCuchillo;
    [SerializeField] Transform ptoGeneracionCuchillo;
    [SerializeField] float fuerzaDisparo;
    // VARIABLES PARA LA SALUD
    [SerializeField] int saludActual = 100;
    [SerializeField] int saludMaxima = 100;
    [SerializeField] int vidasMaximas = 3;
    // VARIABLES PARA LA PUNTUACION
    [SerializeField] int puntuacionActual = 0;

    // Si usaramos un OverlapSphere necesitamos estas variables
    //[SerializeField] float comprobadorRadio = 0.07f;
    //[SerializeField] Transform comprobadorSuelo;
    //[SerializeField] LayerMask mascaraSuelo;
    //public bool enSuelo = true;

    void Start()
    {

        rbPlayer = GetComponent<Rigidbody>();
        // La salud inicial es la salud Máxima
        saludActual = saludMaxima;
    }

    private void FixedUpdate()
    {
        //enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        print(enSuelo());
        rbPlayer.velocity = new Vector2(xPos * speed, rbPlayer.velocity.y);

        // Vamos a cambiar de Sentido
        if (xPos > 0.0f && !irDerecha)
        {
            DarLaVuelta();
        }
        else if (xPos < 0.0f && irDerecha)
        {
            DarLaVuelta();
        }
    }

    void Update()
    {

        xPos = Input.GetAxis("Horizontal");
        // Salto
        if (enSuelo() && Input.GetButtonDown("Vertical"))
        {
            rbPlayer.AddForce(new Vector3(0, jumpForce));
        }
        if (Input.GetButtonDown("Jump"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabCuchillo,
            ptoGeneracionCuchillo.position,
            ptoGeneracionCuchillo.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaDisparo);
    }

    private void DarLaVuelta()
    {
        irDerecha = !irDerecha;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
    // Funcion para comprobar que esté en el suelo. Se trata de una funcion que devuelve un valor booleano
    private bool enSuelo()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanciaSuelo);
    }

    // Funcion para recibir puntos
    public void IncrementarPuntuacion(int puntuacionGanada)
    {
        puntuacionActual += puntuacionGanada;
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        print("ONCOLLIDER:" + collision.gameObject.name);
    }
    */
}
