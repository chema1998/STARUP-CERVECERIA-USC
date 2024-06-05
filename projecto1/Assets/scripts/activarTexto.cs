using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarTexto : MonoBehaviour
{
    public GameObject texto;
    private bool playerNearby = false;  // Para verificar si el jugador está cerca

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;  // Marcar que el jugador está cerca
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;  // Marcar que el jugador ya no está cerca
            texto.SetActive(false); // Asegurarse de que el texto se desactiva cuando el jugador se aleja
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.T))
        {
            texto.SetActive(true);
        }
    }
}
