using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public LayerMask mask; 
    public float distancia = 10f; 

    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;

    void Start()
    {


    
     if (mask.value == 0) // Verifica si la máscara no está configurada
        {
            mask = LayerMask.GetMask("RycaseDetect"); 
            TextDetect.SetActive(false);// Asegúrate de que la capa existe
        }
       

  
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
            Deselect();
            SelectedObject(hit.transform);
            if (hit.collider.CompareTag("objInteractivo")) 
            {
                Debug.Log($"Raycast golpeó: {hit.collider.name} con el tag 'objInteractivo'");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Tecla 'E' presionada. Se puede activar o interactuar con el objeto.");

                    hit.collider.transform.GetComponent<ObjInteractivo>().ActivarObjeto();
                    
                }
            }
            else
            {
                Deselect();
                Debug.Log($"Raycast golpeó un objeto con un tag diferente: {hit.collider.tag}");
            }
        }
        else
        {
            Deselect();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.blue); 
            Debug.Log("Raycast no golpeó nada");
        }
    }
    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color=Color.green;
        ultimoReconocido = transform.gameObject;
    }

    void Deselect()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }


    void OnGUI()
    {
        Rect rect = new Rect(Screen.width/2, Screen.height/2,puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        if(ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }

}
