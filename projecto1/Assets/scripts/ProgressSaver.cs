using UnityEngine;

public class ProgressSaver : MonoBehaviour
{
    private string profileName;

    private void OnEnable()
    {
        profileName = ProfileManager.currentProfileName; // Asignar el profileName actual desde ProfileManager
    }

    private void OnDisable()
    {
        ProfileManager profileManager = FindObjectOfType<ProfileManager>();
        ProgressManager progressManager = FindObjectOfType<ProgressManager>();

        if (profileManager != null && progressManager != null && !string.IsNullOrEmpty(profileName))
        {
            progressManager.SavePlayerProgress(profileName);
        }
        else
        {
            Debug.LogError("No se pudo encontrar ProfileManager o ProgressManager.");
        }
    }
}

