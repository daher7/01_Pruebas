using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchoScript : MonoBehaviour
{
    [SerializeField] int danyo = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().QuitarSalud(20);
            print("Te hago pupita");
        }
    }
}
