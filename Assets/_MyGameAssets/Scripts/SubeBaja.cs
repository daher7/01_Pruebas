using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeBaja : MonoBehaviour {

    int mueve = 0;
    bool estaYendo = true;
    [SerializeField] float speed = 0.5f;
    [SerializeField] int vaHacia = 50;
    [SerializeField] int vaHasta = -50;

	void Update () {
               
        if (estaYendo)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            mueve++;
        } else {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            mueve--;
        }

        if (mueve > vaHacia)
        {
            estaYendo = false;

        } else if (mueve <= vaHasta) {

            estaYendo = true;
        }
	}
}
