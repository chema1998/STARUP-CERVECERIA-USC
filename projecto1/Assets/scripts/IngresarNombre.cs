using UnityEngine;
using UnityEngine.UI;

public class IngresarNombre : MonoBehaviour
{
    public GameObject IngresarNombrePanel;
    public GameObject SeleccionarPerfil;
    
    // Método para abrir un panel específico
    public void Open(GameObject panel)
    {
        IngresarNombrePanel.SetActive(false);
        SeleccionarPerfil.SetActive(false);

        panel.SetActive(true);
    }

    // Método para pasar del panel IngresarNombre al panel SeleccionarPerfil
    public void OnAcceptButtonClick()
    {
        IngresarNombrePanel.SetActive(false);
        SeleccionarPerfil.SetActive(true);
    }

    // Método para pasar del panel SeleccionarPerfil al panel IngresarNombre
    public void ShowIngresarNombrePanel()
    {
        SeleccionarPerfil.SetActive(false);
        IngresarNombrePanel.SetActive(true);
    }
}

