using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSystemDoor
{
    private GameObject doorObject;
    private SystemDoor door;

    [SetUp]
    public void Setup()
    {
        doorObject = new GameObject("Door"); // Crear un GameObject para la puerta
        door = doorObject.AddComponent<SystemDoor>(); // Añadir el componente SystemDoor al GameObject
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(doorObject); // Limpiar objeto creado para las pruebas
    }

    [Test]
    public void SystemDoor_StateToggle()
    {
        // Inicialmente la puerta debería estar cerrada
        Assert.IsFalse(door.doorOpen);

        // Cambiar el estado de la puerta y comprobar que se ha actualizado correctamente
        door.ChangeDoorState();
        Assert.IsTrue(door.doorOpen);

        // Cambiar de nuevo el estado de la puerta y comprobar que vuelve al estado original
        door.ChangeDoorState();
        Assert.IsFalse(door.doorOpen);
    }

}