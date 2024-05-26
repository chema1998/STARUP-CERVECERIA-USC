using UnityEngine;

public class ProgressSaver : MonoBehaviour
{
    public ProgressManager progressManager; // Asigna el ProgressManager en el Inspector

    void OnDisable()
    {
        // Este método se llama cuando el GameObject se desactiva
        // En este caso, se llamará cuando el jugador salga de la escena

        // Llama al método de guardado del progreso
        progressManager.SavePlayerProgress("NombrePerfil");
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
