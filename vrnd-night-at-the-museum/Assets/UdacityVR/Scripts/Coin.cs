using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
    public GameObject coinPoofPrefab;

    public AudioClip soundFile;

    public GameObject earnedCoinsText;

    private bool collected = false;

    private static int earnedCoins = 0;

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(32f, 32f, 32f) * Time.deltaTime);
    }

    public void OnCoinClicked()
    {
        if (!collected)
        {
            collected = true; // To avoid multiple clicks and so earn more coins ;)
            earnedCoins++;

            // Instantiate the CoinPoof Prefab where this coin is located
            // Make sure the poof animates vertically
            GameObject coinPoof = Instantiate(coinPoofPrefab, gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
            coinPoof.GetComponent<AudioSource>().clip = soundFile;
            coinPoof.GetComponent<AudioSource>().Play();

            // Destroy this coin. Check the Unity documentation on how to use Destroy
            Destroy(gameObject, 0.5f);

            string text = earnedCoins + " Coin";
            if (earnedCoins > 1)
            {
                text = text + "s";
            }
            earnedCoinsText.GetComponent<UnityEngine.UI.Text>().text = text;
        }
    }
}
