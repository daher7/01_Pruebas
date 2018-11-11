using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    // Declaracion de constantes
    private const string XPOS = "xPos";
    private const string YPOS = "yPos";
   

    // Guardamos la posicion del jugador
    public static void AlmacenarPosicion(Vector2 posicion)
    {
        PlayerPrefs.SetFloat(XPOS, posicion.x);
        PlayerPrefs.SetFloat(YPOS, posicion.y);
        PlayerPrefs.Save();
    }
    public static Vector2 ObtenerPosicion()
    {
        // Validamos que previamente haya un guardado
        Vector2 posicion;
        if (PlayerPrefs.HasKey(XPOS) && PlayerPrefs.HasKey(YPOS))
        {
            float x = PlayerPrefs.GetFloat(XPOS);
            float y = PlayerPrefs.GetFloat(YPOS);
            posicion = new Vector2(x, y);
            print(x + ":" + y);
        }
        else
        {
            posicion = Vector2.zero;
        }
        return posicion;
    }
}
