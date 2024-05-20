using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    public void ActivarObjeto()
    {
        Debug.Log("Objeto destruido: " + gameObject.name); // Mensaje para indicar que el objeto fue destruido.
        Destroy(gameObject); // Destruye el objeto.
    }
}
