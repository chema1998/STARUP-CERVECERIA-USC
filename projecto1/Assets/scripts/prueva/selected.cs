using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public LayerMask mask;
    public float distancia = 10f;

    public Texture2D puntero;
    public GameObject TextDetect;
    private GameObject ultimoReconocido = null;

    void Start()
    {
        if (mask == 0)
        {
            mask = LayerMask.GetMask("RycaseDetect"); // Asegúrate de que la capa existe
        }
        TextDetect.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
            Deselect();
            SelectObject(hit.transform);

            if (hit.collider.CompareTag("Door"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<SystemDoor>().ChangeDoorState();
                }
            }
        }
        else
        {
            Deselect();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.blue);
        }
    }

    private void SelectObject(Transform transform)
    {
        var renderer = transform.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.green;
        }
        ultimoReconocido = transform.gameObject;
    }

    private void Deselect()
    {
        if (ultimoReconocido != null)
        {
            var renderer = ultimoReconocido.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.white;
            }
            ultimoReconocido = null;
        }
    }

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2 - puntero.width / 2, Screen.height / 2 - puntero.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        TextDetect.SetActive(ultimoReconocido != null);
    }
}
