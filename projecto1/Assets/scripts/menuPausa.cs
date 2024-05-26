using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Estos campos deben estar asignados desde el Inspector
    [SerializeField] private GameObject botonPausa;  // El botón para abrir el menú de pausa
    [SerializeField] private GameObject botonMenu;  // El menú de pausa que contiene las opciones

    // Variable para controlar si el juego está pausado
    private bool juegopausado = false;

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
        Cursor.lockState = CursorLockMode.None; //Bloquea el cursor en el centro de la pantalla.
        Cursor.visible = true; // Puntero visible
    }

    // Método para reanudar el juego y ocultar el menú
    public void Reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;  // Reanuda el tiempo del juego
        botonPausa.SetActive(true);  // Activa el botón de pausa nuevamente
        botonMenu.SetActive(false);  // Oculta el menú de pausa
        Cursor.lockState = CursorLockMode.None; //Bloquea el cursor en el centro de la pantalla.
        Cursor.visible = false; // Ocultar puntero
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
