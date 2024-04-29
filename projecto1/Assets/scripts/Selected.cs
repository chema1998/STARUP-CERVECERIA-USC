using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 3.0f; // Ajusta la distancia
    public Vector3 direccion = Vector3.forward; // Define la dirección del Raycast

    void Start()
    {
        mask = LayerMask.GetMask("RycaseDetect");
        Debug.Log("LayerMask set to: " + mask.value);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(direccion), out hit, distancia, mask))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            if (hit.collider.tag == "Obj interactivo prueva")
            {
                Debug.Log("Tag matched: " + hit.collider.tag);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E key pressed, activating object.");
                    hit.collider.transform.GetComponent<ObjetoInteractivo>().ActivarObjeto();
                }
            }
            else
            {
                Debug.Log("Tag did not match.");
            }
        }
        else
        {
            Debug.Log("No object hit by Raycast.");
        }
    }
}
