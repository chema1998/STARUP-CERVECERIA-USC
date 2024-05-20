using System.Collections;
using UnityEngine;

public class SystemDoor : MonoBehaviour
{
    public bool doorOpen = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0.0f;
    public float smooth = 3.0f;

    public AudioClip openDoor;
    public AudioClip closeDoor;

    void Update()
    {
        Quaternion targetRotation = doorOpen ? Quaternion.Euler(0, doorOpenAngle, 0) : Quaternion.Euler(0, doorCloseAngle, 0);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

    public void ChangeDoorState()
    {
        doorOpen = !doorOpen;

        if (doorOpen)
        {
            PlayOpenDoorSound();
        }
        else
        {
            PlayCloseDoorSound();
        }
    }

    private void PlayOpenDoorSound()
    {
        if (openDoor != null)
        {
            AudioSource.PlayClipAtPoint(openDoor, transform.position, 1f);
        }
        else
        {
            Debug.LogWarning("Open door sound clip is not assigned.");
        }
    }

    private void PlayCloseDoorSound()
    {
        if (closeDoor != null)
        {
            AudioSource.PlayClipAtPoint(closeDoor, transform.position, 1f);
        }
        else
        {
            Debug.LogWarning("Close door sound clip is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerDoor"))
        {
            ChangeDoorState();
        }
    }
}
