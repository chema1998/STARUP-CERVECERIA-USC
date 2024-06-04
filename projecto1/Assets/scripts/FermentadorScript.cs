using UnityEngine;

public class FermentadorScript : MonoBehaviour
{
    public ParticleSystem liquidParticleSystem; // Sistema de part�culas de la cerveza
    public Transform spawnPoint; // Punto de salida de la cerveza
    public AudioSource audioSource; // Fuente de audio para el sonido de la cerveza

    private ParticleSystem currentParticleSystem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentParticleSystem == null)
            {
                currentParticleSystem = Instantiate(liquidParticleSystem, spawnPoint.position, spawnPoint.rotation);
                currentParticleSystem.Play();
                // Reproducir el sonido si hay un AudioSource asignado
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
            else
            {
                currentParticleSystem.Stop();
                Destroy(currentParticleSystem.gameObject, 1f); // Destruir despu�s de 1 segundo para permitir que las part�culas se desvanezcan
                currentParticleSystem = null;
                // Detener el sonido si hay un AudioSource asignado
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}
