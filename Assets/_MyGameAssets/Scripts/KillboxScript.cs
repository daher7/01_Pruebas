using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 position = GameController.ObtenerPosicion();
            other.gameObject.GetComponent<PlayerMovement>().QuitarSalud(50);
            other.gameObject.transform.position = position;
        }
    }
}
