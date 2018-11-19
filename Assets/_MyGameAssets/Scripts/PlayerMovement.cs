using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 6.0f;
    [SerializeField] float xPos;
    bool irDerecha = true;
    Rigidbody rbPlayer;
    // VARIABLES PARA EL SALTO
    [SerializeField] float jumpForce = 300.0f;
    [SerializeField] float distanciaSuelo = 0.1f;
    // VARIABLES PARA EL DISPARO
    [SerializeField] GameObject prefabCuchillo;
    [SerializeField] Transform ptoGeneracionCuchillo;
    [SerializeField] float fuerzaDisparo;
    // VARIABLES PARA LA SALUD
    [SerializeField] int saludActual = 100;
    [SerializeField] int saludMaxima = 100;
    [SerializeField] int vidas = 3;
    [SerializeField] int vidasMaximas = 3;
    [SerializeField] Slider saludSlider;
    [SerializeField] UIScript uiScript;
    // VARIABLES PARA LA PUNTUACION
    [SerializeField] int puntuacionActual = 0;
    [SerializeField] Text textPuntuacion;
    // INVENCIBILIDAD
    public bool soyInvencible = false;
    [SerializeField] float tiempoInvencible = 10f;
    [SerializeField] protected ParticleSystem psPlayer;
    
    // ZONAS DE VIENTO
    public bool inWindZone = false;
    public GameObject windZone;
    // SONIDOS
    [SerializeField] AudioClip sonidoAbeja;
    AudioSource fuenteAudio;

    // Si usaramos un OverlapSphere necesitamos estas variables
    //[SerializeField] float comprobadorRadio = 0.07f;
    //[SerializeField] Transform comprobadorSuelo;
    //[SerializeField] LayerMask mascaraSuelo;
    //public bool enSuelo = true;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        // La salud inicial es la salud Máxima
        saludActual = saludMaxima;
        // Las vidas iniciales son las maximas
        vidas = vidasMaximas;
        // Para que aparezca la puntuacion inicial
        textPuntuacion.text = "" + puntuacionActual.ToString();
        // Para iniciar los sonidos
        fuenteAudio = GetComponent<AudioSource>();
        // Sistema de particulas
       
        
    }

    private void FixedUpdate()
    {
        //enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        print(enSuelo());
        if (Mathf.Abs(xPos) > 0.01f)
        {
            rbPlayer.velocity = new Vector2(xPos * speed, rbPlayer.velocity.y);
        }

        // Vamos a cambiar de Sentido
        if (xPos > 0.0f && !irDerecha)
        {
            DarLaVuelta();
        }
        else if (xPos < 0.0f && irDerecha)
        {
            DarLaVuelta();
        }
        // Comprobamos si estamos en zonas de viento
        if (inWindZone)
        {
            rbPlayer.AddRelativeForce(windZone.GetComponent<WindArea>().direccion * windZone.GetComponent<WindArea>().fuerza);
        }
    }

    void Update()
    {
        xPos = Input.GetAxis("Horizontal");
        // Salto
        if (enSuelo() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rbPlayer.AddForce(new Vector3(0, jumpForce));
        }
        if (Input.GetButtonDown("Jump"))
        {
            Disparar();
        }
    }
    // METODOS PROPIOS
    private void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabCuchillo,
            ptoGeneracionCuchillo.position,
            ptoGeneracionCuchillo.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerzaDisparo);
        fuenteAudio.clip = sonidoAbeja;
        fuenteAudio.Play();
    }

    private void DarLaVuelta()
    {
        irDerecha = !irDerecha;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }
    // Funcion para comprobar que esté en el suelo. Se trata de una funcion que devuelve un valor booleano
    private bool enSuelo()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanciaSuelo);
    }
    // Métodos para comprobar que está en zona de viento
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            windZone = other.gameObject;
            inWindZone = true;
            print("SOY EL VIENTO");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            inWindZone = false;
        }
    }
    // Funcion para recibir puntos
    public void IncrementarPuntuacion(int puntuacionGanada)
    {
        puntuacionActual += puntuacionGanada;
        textPuntuacion.text = "" + puntuacionActual.ToString();
    }
    // Funcion para recibir salud
    public void RecibirSalud(int saludSumada)
    {
        saludActual += saludSumada;
        if (saludActual > saludMaxima)
        {
            saludActual = saludMaxima;
        }
        saludSlider.value = saludActual;
    }
    // Funcion para recibir daño

    public void QuitarSalud(int danyo)
    {
        if (!soyInvencible)
        {
            saludActual -= danyo;
            if (saludActual <= 0)
            {
                vidas--;
                saludActual = saludMaxima;
                uiScript.RestarVida();
                if (vidas <= 0 && saludActual <= 0)
                {
                    //Morir();
                }
                print("Pierdes una vida");
            }
            saludSlider.value = saludActual;
        }
    }
    // Funcion para recibir vida
    public void RecibirVida(int vidaSumada)
    {
        vidas += vidaSumada;

        if (vidas > vidasMaximas)
        {
            vidas = vidasMaximas;
        }
        uiScript.SumarVida();
    }

    // Ser Invencible  
    public void RecibirInvulnerabilidad()
    {
        StartCoroutine(InvencibleRutina());
    }

    public IEnumerator InvencibleRutina()
    {
        soyInvencible = true;
       
        yield return new WaitForSeconds(tiempoInvencible);
       
        //psPlayer.enableEmission = false;
        soyInvencible = false;
    }
    // Mostrar vidas al UI
    public int GetVidas()
    {
        return this.vidas;
    }
    // Morir
    public void Morir()
    {
        saludActual = 0;
        saludSlider.value = saludActual;
        Destroy(gameObject);
    }
}
