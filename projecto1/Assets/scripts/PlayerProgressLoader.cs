using UnityEngine;

public class PlayerProgressLoader : MonoBehaviour
{
    public Transform playerTransform; // Asigna el transform del jugador en el Inspector

    public void LoadPlayerProgress(string profileName)
    {
        float playerPositionX = PlayerPrefs.GetFloat(profileName + "_PlayerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat(profileName + "_PlayerPositionY");
        float playerPositionZ = PlayerPrefs.GetFloat(profileName + "_PlayerPositionZ");
        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
        playerTransform.position = playerPosition;
    }
}
