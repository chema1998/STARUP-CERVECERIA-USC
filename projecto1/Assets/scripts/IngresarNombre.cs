using UnityEngine;
using UnityEngine.UI;

public class IngresarNombre : MonoBehaviour
{
    // Renombrar el miembro a algo más descriptivo, por ejemplo, "IngresarNombrePanel"
    public GameObject IngresarNombrePanel;
    public GameObject SeleccionarPerfil;
    
    public void Open(GameObject panel)
    {
        SeleccionarPerfil.SetActive(false);

        // Usar el nuevo nombre del miembro
        IngresarNombrePanel.SetActive(true);
    }
}
