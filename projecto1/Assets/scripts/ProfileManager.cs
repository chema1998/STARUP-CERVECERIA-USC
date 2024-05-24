using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public static ProgressManager progressManager;
    public static PlayerProgressLoader progressLoader;

    private static string profileListKey = "ProfileList";

    public static void AddProfileToList(string profileName)
    {
        List<string> profiles = GetProfileList();
        profiles.Add(profileName);
        SaveProfileList(profiles);
    }

    public static void RemoveProfileFromList(string profileName)
    {
        List<string> profiles = GetProfileList();
        profiles.Remove(profileName);
        SaveProfileList(profiles);
    }

    public static List<string> GetProfileList()
    {
        string json = PlayerPrefs.GetString(profileListKey, "{\"profiles\":[]}");
        ProfileList profileList = JsonUtility.FromJson<ProfileList>(json);
        return profileList.profiles;
    }

    private static void SaveProfileList(List<string> profiles)
    {
        ProfileList profileList = new ProfileList { profiles = profiles };
        string json = JsonUtility.ToJson(profileList);
        PlayerPrefs.SetString(profileListKey, json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class ProfileList
    {
        public List<string> profiles;
    }

    public static ProgressManager GetProgressManager()
    {
        return progressManager;
    }

    public static void CreateProfile(string profileName, ProgressManager progressManager)
    {
        if (string.IsNullOrEmpty(profileName))
        {
            Debug.LogError("El nombre del perfil no puede estar vacío.");
            return;
        }

        if (PlayerPrefs.HasKey(profileName))
        {
            Debug.LogError("El perfil ya existe.");
            return;
        }

        progressManager.SavePlayerProgress(profileName);
        PlayerPrefs.SetString(profileName, "Perfil creado");
        PlayerPrefs.Save();
        AddProfileToList(profileName);
        Debug.Log("Perfil creado exitosamente: " + profileName);
    }

    public static void DeleteProfile(string profileName)
    {
        if (string.IsNullOrEmpty(profileName))
        {
            Debug.LogError("El nombre del perfil no puede estar vacío.");
            return;
        }

        if (!PlayerPrefs.HasKey(profileName))
        {
            Debug.LogError("El perfil no existe.");
            return;
        }

        PlayerPrefs.DeleteKey(profileName);
        PlayerPrefs.Save();
        RemoveProfileFromList(profileName);
        Debug.Log("Perfil eliminado: " + profileName);
    }

    public static void LoadProfile(string profileName)
    {
        if (progressManager != null && progressLoader != null)
        {
            if (string.IsNullOrEmpty(profileName))
            {
                Debug.LogError("El nombre del perfil no puede estar vacío.");
                return;
            }

            if (!PlayerPrefs.HasKey(profileName))
            {
                Debug.LogError("El perfil no existe.");
                return;
            }

            progressLoader.LoadPlayerProgress(profileName);
            string profileData = PlayerPrefs.GetString(profileName);
            Debug.Log("Datos del perfil cargados: " + profileData);
            UnityEngine.SceneManagement.SceneManager.LoadScene("escenaPrincipal");
        }
        else
        {
            Debug.LogError("ProgressManager o ProgressLoader no asignados en ProfileManager.");
        }
    }

    void Start()
    {
        if (progressManager == null)
        {
            progressManager = FindObjectOfType<ProgressManager>();
            if (progressManager == null)
            {
                Debug.LogError("ProgressManager no encontrado en la escena.");
            }
        }

        if (progressLoader == null)
        {
            progressLoader = FindObjectOfType<PlayerProgressLoader>();
            if (progressLoader == null)
            {
                Debug.LogError("PlayerProgressLoader no encontrado en la escena.");
            }
        }
    }
}






