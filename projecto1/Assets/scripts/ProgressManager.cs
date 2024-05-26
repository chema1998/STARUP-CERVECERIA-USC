using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public GameObject player;

    public void SavePlayerProgress(string profileName)
    {
        if (player != null)
        {
            Vector3 position = player.transform.position;
            PlayerPrefs.SetFloat(profileName + "_pos_x", position.x);
            PlayerPrefs.SetFloat(profileName + "_pos_y", position.y);
            PlayerPrefs.SetFloat(profileName + "_pos_z", position.z);
            PlayerPrefs.Save();
            Debug.Log("Progreso guardado para el perfil: " + profileName);
        }
        else
        {
            Debug.LogError("No se pudo encontrar el GameObject del jugador.");
        }
    }

    public void LoadPlayerProgress(string profileName)
    {
        if (player != null)
        {
            float x = PlayerPrefs.GetFloat(profileName + "_pos_x", player.transform.position.x);
            float y = PlayerPrefs.GetFloat(profileName + "_pos_y", player.transform.position.y);
            float z = PlayerPrefs.GetFloat(profileName + "_pos_z", player.transform.position.z);
            player.transform.position = new Vector3(x, y, z);
            Debug.Log("Progreso del jugador cargado.");
        }
        else
        {
            Debug.LogError("No se pudo encontrar el GameObject del jugador.");
        }
    }
}

