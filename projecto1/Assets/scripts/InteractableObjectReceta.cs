using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public float interactionDistance = 3.0f; // Distancia a la cual se mostrará el texto de interacción
    public Text interactionText; // Referencia al componente de texto de la UI

    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        // Encuentra el objeto del jugador por su etiqueta
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'Player'. Asegúrate de que tu jugador tenga esta etiqueta.");
        }

        // Asegúrate de que el texto de interacción esté desactivado al inicio
        if (interactionText != null)
        {
            interactionText.enabled = false;
        }
        else
        {
            Debug.LogError("El texto de interacción no está asignado. Arrastra el componente de texto al campo 'interactionText' en el inspector.");
        }
    }

    void Update()
    {
        if (player == null || interactionText == null)
        {
            return; // Si el jugador o el texto de interacción no están asignados, no hacer nada
        }

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance)
        {
            interactionText.enabled = true; // Mostrar el texto de interacción

            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Aquí puedes añadir la lógica que quieras que ocurra cuando se presione Q
                Debug.Log("Presionaste Q cerca del objeto!");
            }
        }
        else
        {
            interactionText.enabled = false; // Ocultar el texto de interacción
        }
    }
}
