using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargarEscena : MonoBehaviour
{
    public void Cargar(string nombre)
    {
       StartCoroutine(CargarAsincrona(nombre));
    }


   public void Carga2(string nombre)
    {
       StartCoroutine(CargarAsincrona2(nombre));
    }
  
    IEnumerator CargarAsincrona(string nombre)
    {
       yield return new WaitForSeconds(7.3f);

       AsyncOperation operacion = SceneManager.LoadSceneAsync(nombre);

       while(!operacion.isDone)
       {
       yield return null;
       }

    }

     IEnumerator CargarAsincrona2(string nombre)
    {
       yield return new WaitForSeconds(0.1f);

       AsyncOperation operacion = SceneManager.LoadSceneAsync(nombre);

       while(!operacion.isDone)
       {
       yield return null;
       }



   }

}

    