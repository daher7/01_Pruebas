using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetos : MonoBehaviour {

    Transform esteTransform;
    Transform otroTransform;
    [SerializeField] GameObject otroObjeto;
    [SerializeField] float speed = 0.01f;

    private void Start()
    {
       // ACCEDEMOS A LA ESFERA (this)
       esteTransform = GetComponent<Transform>();
       // ACCEDEMOS AL CUBO (other)
       otroTransform = otroObjeto.GetComponent<Transform>();   
    }

    void Update ()
    {
        // Movemos a la esfera (this)
        esteTransform.Translate(new Vector3(0, 0, 1) * speed);
        // Movemos al cubo
        otroTransform.Translate(new Vector3(0, 0, -1) * speed);     
    }
}
