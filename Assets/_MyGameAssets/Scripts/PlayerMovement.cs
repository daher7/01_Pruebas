using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    [SerializeField] float speed = 6.0f;
    [SerializeField] float xPos;
    [SerializeField] float jumpForce = 300.0f;
    bool irDerecha = true;
    Rigidbody rbPlayer;
    // VARIABLES PARA EL SALTO
    [SerializeField] float radioPies = 0.2f;
    [SerializeField] Transform posPies;
    [SerializeField] LayerMask floorLayer;
    bool saltando = false;

    void Start () {

        rbPlayer = GetComponent<Rigidbody>();
	}
	
	void Update () {

        xPos = Input.GetAxis("Horizontal");
        // Salto
        if (saltando && Input.GetButtonDown("Jump"))
        {
            rbPlayer.AddForce(new Vector2(0, jumpForce));
        }
	}

    private void FixedUpdate() {

        saltando = Physics2D.OverlapCircle(posPies.position, radioPies, floorLayer);
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

    private void OnCollisionStay(Collision collision)
    {
        print("ONCOLLIDER:" + collision.gameObject.name);
    }
}
