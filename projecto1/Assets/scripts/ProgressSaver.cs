using UnityEngine;

public class ProgressSaver : MonoBehaviour
{
    public ProgressManager progressManager; // Asigna el ProgressManager en el Inspector

    void OnDisable()
    {
        // Este m�todo se llama cuando el GameObject se desactiva
        // En este caso, se llamar� cuando el jugador salga de la escena

        // Llama al m�todo de guardado del progreso
        progressManager.SavePlayerProgress("NombrePerfil");
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
