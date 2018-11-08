using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonScript : MonoBehaviour {

    [SerializeField] int speedRotation = 2;
    [SerializeField] int vidaOtorgada = 1;
    Transform trCorazon;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1 * speedRotation));
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, -1 * speedRotation));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().RecibirVida(vidaOtorgada);
            print("Te Doy una vida");
            Destroy(gameObject);
        }
    }
}
