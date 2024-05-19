using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestAgarrarOBJ
{
    private (GameObject cubo, Transform mano, agarrarObjetos script) Setup()
    {
        // Crear un GameObject para simular el cubo
        GameObject cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Rigidbody cuboRigidbody = cubo.AddComponent<Rigidbody>(); // Añadir Rigidbody al cubo para que tenga física
        cuboRigidbody.isKinematic = true; // Hacer el Rigidbody kinematic para que no sea afectado por la física al agarrarlo

        // Crear un GameObject para simular la mano
        GameObject manoObject = new GameObject("Mano");
        Transform mano = manoObject.transform;

        // Añadir el script agarrarObjetos al cubo
        agarrarObjetos script = cubo.AddComponent<agarrarObjetos>();
        script.mano = mano; // Asignar la mano al script
        script.cubo = cubo;

        return (cubo, mano, script);
    }

    private IEnumerator GrabCube(agarrarObjetos script)
    {
        // Activar la interacción con el cubo
        script.activo = true;

        // Invocar el método para agarrar el cubo
        script.AgarrarCubo();

        yield return new WaitForSeconds(0.2f); // Esperar un momento para que se complete la acción
    }

    private IEnumerator ReleaseCube(agarrarObjetos script)
    {
        // Invocar el método para soltar el cubo
        script.SoltarCubo();

        yield return new WaitForSeconds(0.2f); // Esperar un momento para que se complete la acción
    }

    private void AssertCubeGrabbed(Transform mano, GameObject cubo)
    {
        Assert.IsTrue(mano.childCount > 0, "El cubo debería estar en la mano.");
        Assert.AreEqual(cubo.transform.parent, mano, "El cubo no está correctamente en la mano.");
        Assert.IsTrue(Vector3.Distance(cubo.transform.position, mano.position) < 0.5f, "La posición del cubo no coincide con la posición de la mano.");
    }

    private void AssertCubeReleased(Transform mano, GameObject cubo)
    {
        Assert.IsTrue(mano.childCount == 0, "El cubo debería haber sido soltado.");
    }

    [UnityTest]
    public IEnumerator CuboCanBeGrabbedAndReleased()
    {
        // Configuración inicial
        var (cubo, mano, script) = Setup();

        // Esperar un frame para asegurar que todo se inicialice correctamente
        yield return null;

        // Agarrar el cubo
        yield return GrabCube(script);

        // Verificar que el cubo esté en la mano
        AssertCubeGrabbed(mano, cubo);

        // Soltar el cubo
        yield return ReleaseCube(script);

        // Verificar que el cubo haya sido soltado
        AssertCubeReleased(mano, cubo);

        // Limpiar objetos creados para las pruebas
        Object.DestroyImmediate(cubo);
        Object.DestroyImmediate(mano.gameObject);
    }
}
