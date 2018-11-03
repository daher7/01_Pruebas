using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    [SerializeField] float speed = 6.0f;
    [SerializeField] float xPos;
    bool irDerecha = true;
    Rigidbody rbPlayer;
    // VARIABLES PARA EL SALTO
    [SerializeField] float jumpForce = 300.0f;
    [SerializeField] float comprobadorRadio = 0.07f;
    [SerializeField] Transform comprobadorSuelo;
    [SerializeField] LayerMask mascaraSuelo;
    public bool enSuelo = true;

    void Start () {

        rbPlayer = GetComponent<Rigidbody>();
	}
	
	void Update () {

        xPos = Input.GetAxis("Horizontal");
        // Salto
        if (enSuelo && Input.GetButtonDown("Jump"))
        {
            rbPlayer.AddForce(new Vector3(0, jumpForce));
        }
	}

    private void FixedUpdate() {

        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        rbPlayer.velocity = new Vector2(xPos * speed, rbPlayer.velocity.y);

        // Vamos a cambiar de Sentido
        if(xPos > 0.0f && !irDerecha)
        {
            DarLaVuelta();
        } else if (xPos < 0.0f && irDerecha)
        {
            DarLaVuelta();
        }
    }

    private void DarLaVuelta()
    {
        irDerecha = !irDerecha;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        print("ONCOLLIDER:" + collision.gameObject.name);
    }
    */
}
