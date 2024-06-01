using UnityEngine;
using UnityEngine.UI;

public class ActivarRecetas : MonoBehaviour
{
    // Referencia al botón y al panel
    public Button myButton;
    public GameObject myPanel;

    // Variable estática para controlar si el menú de pausa está activo
    private static bool menuPausaActivo = false;

    private bool isPanelActive; // Variable para mantener el estado del panel

    void Start()
    {
        // Sincronizar el estado del panel con la variable isPanelActive
        isPanelActive = myPanel.activeSelf;

        // Añadir el listener al botón para que llame al método TogglePanelButton cuando se haga clic
        myButton.onClick.AddListener(TogglePanelButton);
    }

    void Update()
    {
        // Verificar si se presiona la tecla M
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Solo alternar si el menú de pausa no está activo
            if (!menuPausaActivo)
            {
                TogglePanel();
            }
        }
    }

    // Método para alternar el estado del panel desde el botón
    void TogglePanelButton()
    {
        // Solo alternar si el menú de pausa no está activo
        if (!menuPausaActivo)
        {
            // Invertir el estado del panel
            isPanelActive = !isPanelActive;
            // Aplicar el estado al panel
            myPanel.SetActive(isPanelActive);
        }
    }

    // Método para alternar el estado del panel con la tecla M
    void TogglePanel()
    {
        // Invertir el estado del panel
        isPanelActive = !isPanelActive;
        // Aplicar el estado al panel
        myPanel.SetActive(isPanelActive);
    }

    // Método estático para activar o desactivar el menú de pausa desde el otro script
    public static void SetMenuPausaActivo(bool activo)
    {
        menuPausaActivo = activo;
    }
}
