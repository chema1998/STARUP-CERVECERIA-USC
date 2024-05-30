using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ProfileUIManager : MonoBehaviour
{
    public Dropdown profileDropdown;
    public InputField profileNameInput;
    public Text messageText;
    

    private void Start()
    {
        LoadProfileList();
    }

    private void LoadProfileList()
    {
        List<string> profiles = ProfileManager.GetProfileList();
        profileDropdown.ClearOptions();
        profileDropdown.AddOptions(profiles);
    }

    public void CreateProfile()
    {
        string profileName = profileNameInput.text;
        ProfileManager.CreateProfile(profileName, ProfileManager.GetProgressManager());
        LoadProfileList();
        messageText.text = "Perfil creado exitosamente.";
    }

    public void DeleteProfile()
    {
        string profileName = profileDropdown.options[profileDropdown.value].text;
        ProfileManager.DeleteProfile(profileName);
        LoadProfileList();
        messageText.text = "Perfil eliminado.";
    }

    public void LoadProfile()
    {
        string profileName = profileDropdown.options[profileDropdown.value].text;
        ProfileManager.LoadProfile(profileName);
    }
}
