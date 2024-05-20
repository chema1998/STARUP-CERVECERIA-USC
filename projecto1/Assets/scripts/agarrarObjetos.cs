using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarObjetos : MonoBehaviour
{
    public GameObject cubo;
    public Transform mano;
    public Transform posicion;

    public bool activo;

    void Update()
    {
        if (activo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AgarrarCubo();
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SoltarCubo();
        }        
    }

    public void AgarrarCubo()
    {
        cubo.transform.SetParent(mano);
        cubo.transform.position = mano.position;
        cubo.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SoltarCubo()
    {
        cubo.transform.SetParent(null);
        cubo.GetComponent<Rigidbody>().isKinematic = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activo = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activo = false;
        }
    }
}
