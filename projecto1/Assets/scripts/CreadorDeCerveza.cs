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

    private Dictionary<string, string> combinacionesDeCerveza;

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

            // 1. "Pilsner - Cascade - Ale - Cítrico", "Prendida" },
            // 2. "Vienna - Centennial - Lager - Herbal", "Carmesi" },
            // 3. "MunichCitra - Brettanomyces - Frutal", "Lecter" },
            // 4. "PaleAle - Simcoe - Kölsch - Caramelo", "Sauer" },
            // 5. "Crystal - AleSimcoe - Kölsch - Caramelo", "Tramadora" },
            // 6. "Crystal - Amarillo - Weissbier - Tostado", "BienHechor" },
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
        }
        else
        {
            // Si no se encuentra la combinación, mostrar una opción por defecto
            nombreCervezaDropdown.ClearOptions();
            nombreCervezaDropdown.AddOptions(new List<string> { "Cerveza Desconocida" });
        }
    }
}

