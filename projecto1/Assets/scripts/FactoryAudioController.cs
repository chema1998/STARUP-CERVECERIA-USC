using UnityEngine;

public class FactoryAudioController : MonoBehaviour
{
    public AudioSource factoryAudioSource; // El AudioSource para el audio de la f�brica

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Reproducir el audio de la f�brica
            if (factoryAudioSource != null)
            {
                factoryAudioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale es el jugador
        if (other.CompareTag("Player"))
        {
            // Detener el audio de la f�brica
            if (factoryAudioSource != null)
            {
                factoryAudioSource.Stop();
            }
        }
    }
}
