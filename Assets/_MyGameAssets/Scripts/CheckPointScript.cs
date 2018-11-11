using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("CHECKPOINT");
            GameController.AlmacenarPosicion(collision.gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
