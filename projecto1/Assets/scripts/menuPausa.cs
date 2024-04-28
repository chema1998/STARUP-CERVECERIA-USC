using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject botonMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    private bool juegopausado = false;
    public void Pausa()
    {
        juegopausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        botonMenu.SetActive(true);
    }
    public void Reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        botonMenu.SetActive(false);
    }

    public void Reiniciar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }

    public void Cerrar()
    {
        Debug.Log("cerrando juego");
        Application.Quit();
    }

    
}
