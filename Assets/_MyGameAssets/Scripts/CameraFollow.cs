using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] GameObject follow;
    [SerializeField] float smoothTime = 0.1f;
    // DEclaramos dos vectores para limitar la posicion de camara
    [SerializeField] Vector2 minCamPos, maxCamPos;
    private Vector2 velocity;
    
    void FixedUpdate()
    {
            float posX = Mathf.SmoothDamp(
            transform.position.x,
            follow.transform.position.x,
            ref velocity.x,
            smoothTime);

            float posY = Mathf.SmoothDamp(
                transform.position.y,
                follow.transform.position.y,
                ref velocity.y,
                smoothTime);

            // Vamos a cambiar la posicion de la camara situandola en el player
            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z);
    }
}
