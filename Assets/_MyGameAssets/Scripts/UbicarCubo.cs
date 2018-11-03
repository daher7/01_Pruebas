using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicarCubo : MonoBehaviour {

    // Declaramos el Transform del objeto a quien pertenece el script (Cubo)
    Transform thisTransform;
    // Declaramos otro objeto ajeno al Script (Esfera)
    [SerializeField] GameObject otroObjeto;
    
	void Start () {
        // UBICAMOS EL CUBO (this)
        // Accedemos a su Transform
        thisTransform = GetComponent<Transform>();
        // Lo ubicamos en la posicion que deseamos
        thisTransform.position = new Vector3(2, 2, 2);

        // UBICAMOS A LA ESFERA (otro)
        // Accedemos a su Transform
        Transform otroTransform = otroObjeto.GetComponent<Transform>();
        // Lo ubicamos en la posicion que deseamos
        otroTransform.position = new Vector3(3, 3, 3);
	}
}
