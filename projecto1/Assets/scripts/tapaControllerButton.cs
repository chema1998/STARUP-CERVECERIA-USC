using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapaControllerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonOff;
    public GameObject buttonOn;
    public GameObject tapaObject;
    public GameObject baseButtonObject;

    public Transform openPositionTransform;
    public Transform closedPositionTransform;



    public bool tapaState = false;  
    
    void Start()
    {
        tapaObject.AddComponent<BoxCollider>();
        baseButtonObject.AddComponent<BoxCollider>();

        SetTapaState(tapaState);
    }

    void SetTapaState(bool s)
    {
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

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.O))
        {
            Opentapa();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Closedtapa();
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
