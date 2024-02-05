using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manzana : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text textoManzana;
    [SerializeField] private AudioSource collectionSoundEffect;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("manzana"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            textoManzana.text = "Manzanas: " + cherries;
        }
    }
}