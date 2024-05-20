using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapaControllerButton : MonoBehaviour
{
    public GameObject buttonOff;
    public GameObject buttonOn;
    public GameObject tapaObject;
    public GameObject baseButtonObject;

    public Transform openPositionTransform;
    public Transform closedPositionTransform;

    public bool tapaState = false;  
    
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (tapaObject.GetComponent<BoxCollider>() == null)
        {
            tapaObject.AddComponent<BoxCollider>();
        }

        if (baseButtonObject.GetComponent<BoxCollider>() == null)
        {
            baseButtonObject.AddComponent<BoxCollider>();
        }

        SetTapaState(tapaState);
    }

    void SetTapaState(bool s)
    {
        tapaState = s; // Actualizar el estado de la tapa

        buttonOn.SetActive(s);
        buttonOff.SetActive(!s);

        if (s)
        {
            tapaObject.transform.rotation = openPositionTransform.rotation;
        }
        else
        {
            tapaObject.transform.rotation = closedPositionTransform.rotation;
        }
    }

    public void Opentapa()
    {
        Debug.Log("tapa abierta");
        SetTapaState(true);
    }

    public void Closedtapa()
    {
        Debug.Log("tapa cerrada");
        SetTapaState(false);
    }
}
