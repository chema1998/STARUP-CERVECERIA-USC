using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Estos campos deben estar asignados desde el Inspector
    [SerializeField] private GameObject botonPausa;  // El botón para abrir el menú de pausa
    [SerializeField] private GameObject botonMenu;  // El menú de pausa que contiene las opciones

    // Variable para controlar si el juego está pausado
    private bool juegopausado = false;

    // Variable estática para controlar si el menú de recetas está activo
    public static bool menuRecetasActivo = false;

    // Inicializa el estado del menú y el botón de pausa
    private void Start()
    {
        // Si el campo es null, intenta encontrar el objeto
        if (botonPausa == null)
        {
            botonPausa = GameObject.Find("NombreDelBotonDePausa");  // Reemplaza con el nombre real
        }

        if (botonMenu == null)
        {
            botonMenu = GameObject.Find("NombreDelMenuDePausa");  // Reemplaza con el nombre real
        }

        botonMenu.SetActive(false);  // Asegúrate de que el menú esté oculto al inicio
        botonPausa.SetActive(true);  // El botón de pausa debe estar activo al inicio
    }
    
    // Método para alternar el estado de pausa
    private void TogglePausa()
    {
        // Verificar si el menú de recetas está activo
        if (menuRecetasActivo)
        {
            return;
        }

        if (juegopausado)
        {
            Reanudar();
        }
        else
        {
            Pausa();
        }
    }

    // Método para manejar la tecla Escape
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausa();  // Alternar entre pausa y reanudación
        }
    }

    // Método para pausar el juego y mostrar el menú
    public void Pausa()
    {
        juegopausado = true;
        Time.timeScale = 0f;  // Pausa el tiempo del juego
        botonPausa.SetActive(false);  // Desactiva el botón de pausa
        botonMenu.SetActive(true);  // Activa el menú de pausa para mostrar las opciones
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor.
        Cursor.visible = true; // Puntero visible

        // Informar al otro script que el menú de pausa está activo
        ActivarRecetas.menuPausaActivo = true;
    }

    // Método para reanudar el juego y ocultar el menú
    public void Reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;  // Reanuda el tiempo del juego
        botonPausa.SetActive(true);  // Activa el botón de pausa nuevamente
        botonMenu.SetActive(false);  // Oculta el menú de pausa
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor.
        Cursor.visible = false; // Ocultar puntero

        // Informar al otro script que el menú de pausa no está activo
        ActivarRecetas.menuPausaActivo = false;
    }

    // Método para reiniciar la escena actual
    public void Reiniciar()
    {
        juegopausado = false;
        Time.timeScale = 1f;  // Restaura el tiempo del juego antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Carga la escena actual
    }

    // Método para cerrar el juego
    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();  // Cierra la aplicación
    }
}
