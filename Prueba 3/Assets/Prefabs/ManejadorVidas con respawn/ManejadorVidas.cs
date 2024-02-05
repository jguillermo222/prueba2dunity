using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManejadorVidas : MonoBehaviour
{
    private Rigidbody2D rb2D;
    

    
    
    public UnityEvent jugadorMurio;
    [SerializeField] private AudioSource morirSonido;

    public Vector3 posicionInicio  { get; set; }
    private Vector3 respawnPoint; 
    public UnityEvent morirFinal;


    public List<Image> listaImgVidas = new List<Image>();
    public int contadorVidas = 0;


    void Awake()
    {
        posicionInicio = transform.position;
   
    }


    // Start is called before the first frame update
    void Start()
    {
        contadorVidas = listaImgVidas.Count;
        rb2D = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position; // del codigo
        contadorVidas = listaImgVidas.Count;
        
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("morir"))
        {
            contadorVidas--;
            listaImgVidas[contadorVidas].gameObject.SetActive(false);
            morirSonido.Play();
            Reinicio();

            if (contadorVidas == 0)
                jugadorMurio.Invoke();

        }
    }

    void Reinicio()
    {
         rb2D.velocity = Vector2.zero;
         rb2D.angularVelocity= 0;
         
         transform.position = respawnPoint; //se cambia posicionInicio por respawnPoint
        
         
    }



}
