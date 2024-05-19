using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewBehaviourScriptTests
{
    [UnityTest]
    public IEnumerator SelectObject_WithValidObject_HighlightsObject()
    {
        // Arrange
        GameObject testObject = new GameObject();
        NewBehaviourScript script = testObject.AddComponent<NewBehaviourScript>();
        Renderer renderer = testObject.AddComponent<MeshRenderer>();

        // Act
        script.SelectObject(testObject.transform);

        // Assert
        Color expectedColor = Color.green;
        Color actualColor = renderer.material.color;
        Assert.AreEqual(expectedColor, actualColor, "Object should be highlighted in green when selected.");

        yield return null;
    }

    [UnityTest]
    public IEnumerator Deselect_WithSelectedObject_ResetsColor()
    {
        // Arrange
        GameObject testObject = new GameObject();
        NewBehaviourScript script = testObject.AddComponent<NewBehaviourScript>();
        Renderer renderer = testObject.AddComponent<MeshRenderer>();
        script.SelectObject(testObject.transform);

        // Act
        script.Deselect();

        // Assert
        Color expectedColor = Color.white;
        Color actualColor = renderer.material.color;
        Assert.AreEqual(expectedColor, actualColor, "Object color should be reset to white when deselected.");

        yield return null;
    }
}
