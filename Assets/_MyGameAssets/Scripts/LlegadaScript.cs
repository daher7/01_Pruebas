﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(385, 4.3f, 0);
        }
    }

}
