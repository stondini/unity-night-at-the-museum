using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoofPrefab;

    [SerializeField]
    private AudioClip soundFile;

    public GameObject door;

    private bool collected = false;

	void Update()
	{
		//Not required, but for fun why not try adding a Key Floating Animation here :)
        gameObject.transform.Rotate(new Vector3(0f, 0f, 32f) * Time.deltaTime);
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy
        if (!collected)
        {
            collected = true; // To avoid multiple clicks and so earn more coins ;)

            // Instantiate the CoinPoof Prefab where this coin is located
            // Make sure the poof animates vertically
            GameObject keyPoof = Instantiate(keyPoofPrefab, gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
            keyPoof.GetComponent<AudioSource>().clip = soundFile;
            keyPoof.GetComponent<AudioSource>().Play();

            // Destroy this coin. Check the Unity documentation on how to use Destroy
            Destroy(gameObject, 0.5f);

            // Call the Unlock() method on the Door
            Door doorScript = door.GetComponent<Door>();
            doorScript.Unlock();
        }
    }

}
