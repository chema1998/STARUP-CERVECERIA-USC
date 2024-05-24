using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Transform playerTransform; // Asigna el transform del jugador en el Inspector

    
    public void SavePlayerProgress(string profileName)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // Encuentra el GameObject del jugador
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform; // Obtiene el Transform del jugador
            if (playerTransform != null)
            {
                Vector3 playerPosition = playerTransform.position; // Accede a la posición del jugador
                // Continúa con la lógica de guardado del progreso...
            }
            else
            {
                Debug.LogError("El Transform del jugador es nulo.");
            }
        }
        else
        {
            Debug.LogError("No se pudo encontrar el GameObject del jugador.");
        }
    }
}
