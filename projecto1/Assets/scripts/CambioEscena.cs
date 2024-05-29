using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Este método cambia la escena actual a la escena cuyo nombre se pasa como parámetro
    public void CambiarEscena(string escenaPrincipal)
    {
        // Verificar si el nombre de la escena no está vacío o nulo
        if (!string.IsNullOrEmpty(escenaPrincipal))
        {
            // Cargar la escena con el nombre proporcionado
            SceneManager.LoadScene(escenaPrincipal);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no puede ser nulo o vacío.");
        }
    }


    public void CambioEscenaIngrNom(string IngresarNombre)
    {
        // Verificar si el nombre de la escena no está vacío o nulo
        if (!string.IsNullOrEmpty(IngresarNombre))
        {
            // Cargar la escena con el nombre proporcionado
            SceneManager.LoadScene(IngresarNombre);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no puede ser nulo o vacío.");
        }
    }

    public void CambioEscenaMenu(string Menu)
    {
        // Verificar si el nombre de la escena no está vacío o nulo
        if (!string.IsNullOrEmpty(Menu))
        {
            // Cargar la escena con el nombre proporcionado
            SceneManager.LoadScene(Menu);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no puede ser nulo o vacío.");
        }
    }

}