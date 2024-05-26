using UnityEngine;

public class PlayerProgressLoader : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No se pudo encontrar el GameObject del jugador.");
        }
    }

    public void LoadPlayerProgress(string profileName)
    {
        if (player != null)
        {
            float x = PlayerPrefs.GetFloat(profileName + "_x", player.transform.position.x);
            float y = PlayerPrefs.GetFloat(profileName + "_y", player.transform.position.y);
            float z = PlayerPrefs.GetFloat(profileName + "_z", player.transform.position.z);

            player.transform.position = new Vector3(x, y, z);
            Debug.Log("Progreso cargado para el perfil: " + profileName);
        }
        else
        {
            Debug.LogError("No se pudo cargar el progreso. Jugador no encontrado.");
        }
    }
}
