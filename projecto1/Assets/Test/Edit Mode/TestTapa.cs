using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestTapa
{
    private GameObject tapaControllerObject;
    private tapaControllerButton tapaController;
    private GameObject buttonOff;
    private GameObject buttonOn;
    private GameObject tapaObject;
    private GameObject baseButtonObject;
    private GameObject openPosition;
    private GameObject closedPosition;

    [SetUp]
    public void SetUp()
    {
        // Creación de los objetos necesarios para la prueba
        tapaControllerObject = new GameObject();
        tapaController = tapaControllerObject.AddComponent<tapaControllerButton>();
        buttonOff = new GameObject();
        buttonOn = new GameObject();
        tapaObject = GameObject.CreatePrimitive(PrimitiveType.Cube); // Usamos un cubo como tapaObject para simplificar la prueba
        baseButtonObject = new GameObject();
        openPosition = new GameObject();
        closedPosition = new GameObject();

        // Configuración de las transformaciones
        openPosition.transform.rotation = Quaternion.Euler(0, 0, 90);
        closedPosition.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Asignación de los objetos al controlador
        tapaController.buttonOff = buttonOff;
        tapaController.buttonOn = buttonOn;
        tapaController.tapaObject = tapaObject;
        tapaController.baseButtonObject = baseButtonObject;
        tapaController.openPositionTransform = openPosition.transform;
        tapaController.closedPositionTransform = closedPosition.transform;

        // Inicialización del controlador
        tapaController.Initialize();
    }

    [TearDown]
    public void TearDown()
    {
        // Limpieza de los objetos después de cada prueba
        Object.DestroyImmediate(tapaControllerObject);
        Object.DestroyImmediate(buttonOff);
        Object.DestroyImmediate(buttonOn);
        Object.DestroyImmediate(tapaObject);
        Object.DestroyImmediate(baseButtonObject);
        Object.DestroyImmediate(openPosition);
        Object.DestroyImmediate(closedPosition);
    }

    [Test]
    public void TestInitialState()
    {
        // Verifica que el estado inicial es correcto
        Assert.IsFalse(tapaController.tapaState);
        Assert.IsFalse(buttonOn.activeSelf);
        Assert.IsTrue(buttonOff.activeSelf);

        // Compara las rotaciones usando aproximación de Euler angles
        Assert.IsTrue(Mathf.Approximately(tapaObject.transform.rotation.eulerAngles.z, closedPosition.transform.rotation.eulerAngles.z));
    }

    [Test]
    public void TestOpenTapa()
    {
        // Abre la tapa y verifica el estado
        tapaController.Opentapa();
        Assert.IsTrue(tapaController.tapaState);
        Assert.IsTrue(buttonOn.activeSelf);
        Assert.IsFalse(buttonOff.activeSelf);

        // Compara las rotaciones usando un umbral de tolerancia
        float threshold = 0.01f; // Umbral de tolerancia para la comparación de rotaciones
        float angleDifference = Quaternion.Angle(tapaObject.transform.rotation, openPosition.transform.rotation);
        Assert.LessOrEqual(angleDifference, threshold, $"Diferencia de ángulo: {angleDifference}");

        // Verifica específicamente el ángulo Z si es necesario
        Assert.IsTrue(Mathf.Approximately(tapaObject.transform.rotation.eulerAngles.z, openPosition.transform.rotation.eulerAngles.z));
    }

    [Test]
    public void TestCloseTapa()
    {
        // Cierra la tapa y verifica el estado
        tapaController.Opentapa(); // Primero abre la tapa
        tapaController.Closedtapa(); // Luego cierra la tapa
        Assert.IsFalse(tapaController.tapaState);
        Assert.IsFalse(buttonOn.activeSelf);
        Assert.IsTrue(buttonOff.activeSelf);

        // Compara las rotaciones usando aproximación de Euler angles
        Assert.IsTrue(Mathf.Approximately(tapaObject.transform.rotation.eulerAngles.z, closedPosition.transform.rotation.eulerAngles.z));
    }

    [UnityTest]
    public IEnumerator TestTapaWithEnumeratorPasses()
    {
        // Usa yield para omitir un frame y permitir que Unity procese las actualizaciones
        yield return null;
    }
}
