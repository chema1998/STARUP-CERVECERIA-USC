using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public ProgressManager progressManager; // Asigna el ProgressManager en el Inspector
    public PlayerProgressLoader progressLoader; // Asigna el PlayerProgressLoader en el Inspector
    public static string currentProfileName;

    private static string profileListKey = "ProfileList";

    // Añadir un perfil a la lista
    public static void AddProfileToList(string profileName)
    {
        List<string> profiles = GetProfileList();
        profiles.Add(profileName);
        SaveProfileList(profiles);
    }

    // Eliminar un perfil de la lista
    public static void RemoveProfileFromList(string profileName)
    {
        List<string> profiles = GetProfileList();
        profiles.Remove(profileName);
        SaveProfileList(profiles);
    }

    // Obtener la lista de perfiles
    public static List<string> GetProfileList()
    {
        string json = PlayerPrefs.GetString(profileListKey, "{\"profiles\":[]}");
        ProfileList profileList = JsonUtility.FromJson<ProfileList>(json);
        return profileList.profiles;
    }

    // Guardar la lista de perfiles
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
        return FindObjectOfType<ProfileManager>().progressManager;
    }

    // Métodos de creación, carga y eliminación de perfiles
    public void CreateProfile(string profileName)
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

    public void DeleteProfile(string profileName)
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

    public void LoadProfile(string profileName)
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

            currentProfileName = profileName; // Asignar el profileName actual
            progressLoader.LoadPlayerProgress(profileName);
            string profileData = PlayerPrefs.GetString(profileName);
            Debug.Log("Datos del perfil cargados: " + profileData);
            UnityEngine.SceneManagement.SceneManager.LoadScene("escenaPrincipal");
        }
        else
        {
            Debug.LogError("ProgressManager no asignado en ProfileManager.");
        }
    }

    void Start()
    {
        if (progressManager == null)
        {
            // Inicializa el ProgressManager si no está asignado
            progressManager = FindObjectOfType<ProgressManager>();
            if (progressManager == null)
            {
                Debug.LogError("ProgressManager no encontrado en la escena.");
            }
        }

        if (progressLoader == null)
        {
            // Inicializa el PlayerProgressLoader si no está asignado
            progressLoader = FindObjectOfType<PlayerProgressLoader>();
            if (progressLoader == null)
            {
                Debug.LogError("PlayerProgressLoader no encontrado en la escena.");
            }
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}




