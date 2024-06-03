using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrucionesScript : MonoBehaviour
{
    public GameObject instrucciones; // Panel de instrucciones
    public KeyCode toggleKey = KeyCode.I; // Tecla para mostrar/ocultar las instrucciones

    void Start()
    {
        // Asegúrate de que el panel de instrucciones esté oculto al inicio
        instrucciones.SetActive(false);
    }

    void Update()
    {
        // Comprueba si se ha presionado la tecla definida
        if (Input.GetKeyDown(toggleKey))
        {
            // Alterna la visibilidad del panel de instrucciones
            instrucciones.SetActive(!instrucciones.activeSelf);
        }
    }
}
