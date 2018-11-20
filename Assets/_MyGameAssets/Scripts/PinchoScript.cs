using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchoScript : MonoBehaviour {
    [SerializeField] int danyo = 20;
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerMovement>().QuitarSalud(20);
            GetComponent<AudioSource>().Play();

            //OPCION 1
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);

            //OPCION 2
            //CREAS UN GO PADRE VACIO Y METES EL MODELO 3D COMO HIJO
            Destroy(transform.GetChild(0).gameObject);
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
    }
}
