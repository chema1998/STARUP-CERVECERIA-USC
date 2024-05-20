using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemDoor : MonoBehaviour
{
    public bool doorOpen = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0.0f;
    public float smooth = 3.0f;

    public AudioClip openDoor;
    public AudioClip closeDoor;

    public void ChangeDoorState()
    {
        doorOpen = !doorOpen;
    }

    void Update()
    {
        Quaternion targetRotation = doorOpen ? Quaternion.Euler(0, doorOpenAngle, 0) : Quaternion.Euler(0, doorCloseAngle, 0);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerDoor"))
        {
            AudioSource.PlayClipAtPoint(closeDoor, transform.position, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerDoor"))
        {
            AudioSource.PlayClipAtPoint(openDoor, transform.position, 1f);
        }
    }
}
