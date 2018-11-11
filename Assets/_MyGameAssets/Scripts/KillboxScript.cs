using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 position = GameController.ObtenerPosicion();
            other.gameObject.transform.position = position;
        }
    }
}
