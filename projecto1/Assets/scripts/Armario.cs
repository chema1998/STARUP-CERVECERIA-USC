using UnityEngine;

public class Armario : MonoBehaviour
{
    public Transform puertaIzquierda;
    public Transform puertaDerecha;

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clic detectado"); // Confirmar que se detectó un clic
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit: " + hit.transform.name); // Mostrar qué objeto fue golpeado
                if (hit.transform == this.transform) // Asegurarse de que el clic es en el armario
                {
                    Debug.Log("Clic en el armario"); // Confirmar que se hizo clic en el armario
                    ToggleArmario();
                }
            }
        }
    }

    private void ToggleArmario()
    {
        if (isOpen)
        {
            Debug.Log("Cerrando el armario"); // Confirmar que se va a cerrar el armario
            puertaIzquierda.Rotate(0, -90, 0); // Ajustar según el modelo
            puertaDerecha.Rotate(0, 90, 0);
        }
        else
        {
            Debug.Log("Abriendo el armario"); // Confirmar que se va a abrir el armario
            puertaIzquierda.Rotate(0, 90, 0); // Ajustar según el modelo
            puertaDerecha.Rotate(0, -90, 0);
        }
        isOpen = !isOpen;
    }
}
