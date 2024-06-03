using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreadorDeCerveza : MonoBehaviour
{
    public Dropdown maltaDropdown;
    public Dropdown lupuloDropdown;
    public Dropdown levaduraDropdown;
    public Dropdown saborDropdown;
    public Dropdown nombreCervezaDropdown;
    public Image cervezaImagen;

    private Dictionary<string, string> combinacionesDeCerveza;
    private Dictionary<string, Sprite> imagenesDeCerveza;

    private void Start()
    {
        // Inicializar las combinaciones de cerveza
        combinacionesDeCerveza = new Dictionary<string, string>
        {
            { "PilsnerCascadeAleCítrico", "Prendida" },
            { "ViennaCentennialLagerHerbal", "Carmesi" },
            { "MunichCitraBrettanomycesFrutal", "Lecter" },
            { "PaleAleSimcoeKölschCaramelo", "Sauer" },
            { "CrystalAleSimcoeKölschCaramelo", "Tramadora" },
            { "CrystalAmarilloWeissbierTostado", "BienHechor" },
        };

        // Inicializar las imágenes de cerveza
        imagenesDeCerveza = new Dictionary<string, Sprite>
        {
            { "Prendida", Resources.Load<Sprite>("Imagenes/LataAzulUSCFF") },
            { "Carmesi", Resources.Load<Sprite>("Imagenes/LataRojaUSCFF") },
            { "Lecter", Resources.Load<Sprite>("Imagenes/LataAmarillaUSCFF") },
            { "Sauer", Resources.Load<Sprite>("Imagenes/LataVerdeUSCFF") },
            { "Tramadora", Resources.Load<Sprite>("Imagenes/LataNegraUSCFF") },
            { "BienHechor", Resources.Load<Sprite>("Imagenes/LataGrisUSCFF") },
            { "Cerveza Desconocida", Resources.Load<Sprite>("Imagenes/CervezaDesconocida") },
        };

        // Añadir listeners a los dropdowns
        maltaDropdown.onValueChanged.AddListener(delegate { ActualizarNombreCerveza(); });
        lupuloDropdown.onValueChanged.AddListener(delegate { ActualizarNombreCerveza(); });
        levaduraDropdown.onValueChanged.AddListener(delegate { ActualizarNombreCerveza(); });
        saborDropdown.onValueChanged.AddListener(delegate { ActualizarNombreCerveza(); });

        // Inicializar el nombre de la cerveza
        ActualizarNombreCerveza();
    }

    void ActualizarNombreCerveza()
    {
        // Obtener las selecciones de los dropdowns
        string maltaSeleccionada = maltaDropdown.options[maltaDropdown.value].text;
        string lupuloSeleccionado = lupuloDropdown.options[lupuloDropdown.value].text;
        string levaduraSeleccionada = levaduraDropdown.options[levaduraDropdown.value].text;
        string saborSeleccionado = saborDropdown.options[saborDropdown.value].text;

        // Crear la clave para buscar en el diccionario
        string clave = maltaSeleccionada + lupuloSeleccionado + levaduraSeleccionada + saborSeleccionado;

        // Buscar el nombre de la cerveza en el diccionario
        string nombreCerveza;
        if (combinacionesDeCerveza.TryGetValue(clave, out nombreCerveza))
        {
            // Actualizar el Dropdown de nombre de la cerveza
            nombreCervezaDropdown.ClearOptions();
            nombreCervezaDropdown.AddOptions(new List<string> { nombreCerveza });

            // Actualizar la imagen de la cerveza
            if (imagenesDeCerveza.TryGetValue(nombreCerveza, out Sprite cervezaSprite))
            {
                cervezaImagen.sprite = cervezaSprite;
            }
        }
        else
        {
            // Si no se encuentra la combinación, mostrar una opción y una imagen por defecto
            nombreCervezaDropdown.ClearOptions();
            nombreCervezaDropdown.AddOptions(new List<string> { "Cerveza Desconocida" });
            cervezaImagen.sprite = imagenesDeCerveza["Cerveza Desconocida"];
        }
    }
}
