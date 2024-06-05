using UnityEngine;

public class FactoryAudioController : MonoBehaviour
{
    public AudioSource factoryAudioSource; // El AudioSource para el audio de la fábrica

    private void Start()
    {
        // Configurar el audio para que se reproduzca en bucle
        if (factoryAudioSource != null)
        {
            factoryAudioSource.loop = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Reproducir el audio de la fábrica
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
            // Detener el audio de la fábrica
            if (factoryAudioSource != null)
            {
                factoryAudioSource.Stop();
            }
        }
    }
}