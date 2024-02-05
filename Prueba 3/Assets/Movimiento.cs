using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using UnityEngine.SceneManagement; //del codigo
using UnityEngine.UI; //del codigo


public class Movimiento : MonoBehaviour
{

    

    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    [SerializeField] private AudioSource morirSonido; 
    [SerializeField] private AudioSource cambionivelSonido; //agregado para sonido cambio nivel
    private bool salto = false;

    [Header("Animacion")] private Animator animator;

    public Vector3 posicionInicio  { get; set; }

    
    private Vector3 respawnPoint; //del codigo

    public UnityEvent morirFinal; //para el scrip del panel 


    public List<Image> listaImgVidas = new List<Image>();  //3 lineas para controlador de vida
    public int contadorVidas = 0;
    public UnityEvent jugadorMurio;

    void Awake()
    {
        posicionInicio = transform.position;
   
    }



    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        respawnPoint = transform.position; // del codigo
        contadorVidas = listaImgVidas.Count;
       
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);

        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        enSuelo = collision.gameObject.CompareTag("enSuelo");
 // se cambian las lineas de if
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

    private void OnTriggerEnter2D(Collider2D collision) //adicionado
    {
        if(collision.tag == "morir")
        {
            transform.position = respawnPoint;
            morirSonido.Play();
        }
        else if(collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        

        if (collision.gameObject.CompareTag("cambionivel")){ //agregado para sonido cambio nivel
            cambionivelSonido.Play();  
            } 
        
    }

    


     


}
