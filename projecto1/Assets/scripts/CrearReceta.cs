using UnityEngine;
using UnityEngine.UI;

public class CrearReceta : MonoBehaviour
{
    public Dropdown maltaDropdown;
    public Dropdown lupuloDropdown;
    public Dropdown levaduraDropdown;
    public Dropdown saborDropdown;
    public Button botonCrear;
    public Text textoResultado;

    private void Start()
    {
        // Añadir listener al botón de crear
        botonCrear.onClick.AddListener(CrearCerveza);
    }

    void CrearCerveza()
    {
        // Obtener las selecciones de los dropdowns
        string maltaSeleccionada = maltaDropdown.options[maltaDropdown.value].text;
        string lupuloSeleccionado = lupuloDropdown.options[lupuloDropdown.value].text;
        string levaduraSeleccionada = levaduraDropdown.options[levaduraDropdown.value].text;
        string saborSeleccionado = saborDropdown.options[saborDropdown.value].text;

        // Crear la descripción de la cerveza
        string descripcionCerveza = $"Cerveza creada con:\nMalta: {maltaSeleccionada}\nLúpulo: {lupuloSeleccionado}\nLevadura: {levaduraSeleccionada}\nSabor: {saborSeleccionado}";

        // Mostrar la descripción en la UI
        textoResultado.text = descripcionCerveza;
    }
}
