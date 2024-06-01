using UnityEngine;
using UnityEngine.UI;

public class ActivarRecetas : MonoBehaviour
{
    // Referencia al botón y al panel
    public Button myButton;
    public GameObject myPanel;

    // Variable estática para controlar si el menú de pausa está activo
    public static bool menuPausaActivo = false;

    private bool isPanelActive; // Variable para mantener el estado del panel

    void Start()
    {
        // Sincronizar el estado del panel con la variable isPanelActive
        isPanelActive = myPanel.activeSelf;

        // El botón está activo al inicio
        myButton.gameObject.SetActive(true);

        // Añadir el listener al botón para que llame al método TogglePanelButton cuando se haga clic
        myButton.onClick.AddListener(TogglePanelButton);
    }

    void Update()
    {
        // Verificar si se presiona la tecla R
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
            TogglePanel();
        }
    }

    // Método para alternar el estado del panel
    void TogglePanel()
    {
        // Verificar si el menú de pausa está activo
        if (menuPausaActivo)
        {
            return;
        }

        // Invertir el estado del panel
        isPanelActive = !isPanelActive;
        // Aplicar el estado al panel
        myPanel.SetActive(isPanelActive);

        // Activar o desactivar el puntero del mouse
        if (isPanelActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Desactivar el botón cuando el panel está activo
        myButton.gameObject.SetActive(!isPanelActive);

        // Informar al otro script sobre el estado del panel
        MenuPausa.menuRecetasActivo = isPanelActive;
    }

    // Método para verificar si el panel está activo
    public bool IsPanelActive()
    {
        return isPanelActive;
    }
}
