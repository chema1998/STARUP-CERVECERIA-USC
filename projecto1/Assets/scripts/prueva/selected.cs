using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Máscara de capa para el raycast
    public LayerMask mask; // Define explícitamente como público para facilitar la configuración en el Inspector

    // Distancia del raycast para detectar objetos
    public float distancia = 10f; // Aumenta la distancia para una mejor detección

    void Start()
    {
        // Asegúrate de que la máscara esté correctamente configurada
        if (mask.value == 0) // Verifica si la máscara no está configurada
        {
            mask = LayerMask.GetMask("RycaseDetect"); // Asegúrate de que la capa existe
        }
    }

    void Update()
    {
        RaycastHit hit;

        // Lanza el raycast en la dirección hacia adelante
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            // Dibuja el rayo de depuración en color rojo
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);

            // Verifica si el objeto golpeado tiene el tag correcto
            if (hit.collider.CompareTag("objInteractivo")) // Usa CompareTag para eficiencia
            {
                Debug.Log($"Raycast golpeó: {hit.collider.name} con el tag 'objInteractivo'");

                // Si se presiona la tecla 'E', realiza alguna acción
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Aquí puedes activar o interactuar con el objeto
                    Debug.Log("Tecla 'E' presionada. Se puede activar o interactuar con el objeto.");
                    // Ejemplo: llama a un método del objeto golpeado
                    hit.collider.transform.GetComponent<ObjInteractivo>().ActivarObjeto();
                    
                }
            }
            else
            {
                Debug.Log($"Raycast golpeó un objeto con un tag diferente: {hit.collider.tag}");
            }
        }
        else
        {
            // Si el raycast no golpea nada
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.blue); // Color gris para rayos que no golpean nada
            Debug.Log("Raycast no golpeó nada");
        }
    }
}
