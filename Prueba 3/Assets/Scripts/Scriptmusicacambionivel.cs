using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptmusicacambionivel : MonoBehaviour
{

    [SerializeField] private AudioSource cambionivelSonido; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision) //adicionado
    {
       
        if (collision.gameObject.CompareTag("cambionivel")){ //agregado para sonido cambio nivel
            cambionivelSonido.Play();  
            } 
        
    }
}
