using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour {

    [SerializeField] float vidaCuchillo = 2.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemigo")) {
            print("Eres mi ENEMIGO");
        } else if (other.gameObject.CompareTag("Player")) {
            print("ME HAN DADO");
        }
        Destroy(gameObject, vidaCuchillo);
    }
}
