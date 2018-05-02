using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    private bool locked = true;

    // Create a boolean value called "opening" that can be checked in Update() 
    private bool opening = false;

    [SerializeField]
    private AudioClip openingSoundFile;

    [SerializeField]
    private AudioClip lockedSoundFile;

    private float startTime = 0f;

    void Update() {
        // If the door is opening and it is not fully raised
        // Animate the door raising up
        if (opening) {
            GameObject leftDoor = GameObject.Find("Left_Door");
            GameObject rightDoor = GameObject.Find("Right_Door");

            Quaternion leftStartRotation = Quaternion.Euler(-90f, 0f, 90f);
            Quaternion rightStartRotation = Quaternion.Euler(-90f, 0f, -90f);
            Quaternion endRotation = Quaternion.Euler(-90f, -90f, 90f);
            leftDoor.transform.rotation = Quaternion.Slerp(leftStartRotation, endRotation, startTime / 5f);
            rightDoor.transform.rotation = Quaternion.Slerp(rightStartRotation, endRotation, startTime / 5f);
            startTime += Time.deltaTime;
        }
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        if (!locked)
        {
            opening = true;
            // Disable the BoxCollider to prevent ray casting after the door is open
            // and allow entering into the temple.
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<AudioSource>().clip = openingSoundFile;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            // (optionally) Else
            // Play a sound to indicate the door is locked
            gameObject.GetComponent<AudioSource>().clip = lockedSoundFile;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
        locked = false;
    }
}
