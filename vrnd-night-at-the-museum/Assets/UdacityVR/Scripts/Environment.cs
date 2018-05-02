using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

    public GameObject treePrefab;

    public GameObject pillarPrefab;

    public GameObject pillarSpotLightPrefab;

    public GameObject lightningLight;

    private float nextStormTime;

    private bool startStorm;

    private int maxLightnings = 9;

    private int lightningCount = 0;

	void Start () {
        // Place trees
        PlaceTrees();
        // Place pillas
        PlacePillars();

        startStorm = false;
        nextStormTime = Time.fixedTime + Random.Range(3.0f, 10.0f); // From 16 seconds to 60 seconds
        StartCoroutine(StartStormSound());
        StartCoroutine(StartStormLightning());
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime >= nextStormTime) {
            lightningCount = 0;
            startStorm = true;
            nextStormTime = Time.fixedTime + Random.Range(16.0f, 60.0f); // From 16 seconds to 60 seconds
        }
	}

    private IEnumerator StartStormSound()
    {
        while (true) {
            if (startStorm)
            {
                gameObject.GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                startStorm = false;
            }
            yield return null;
        }
    }

    private IEnumerator StartStormLightning()
    {
        bool enable = true;
        float waitRnd = 0;
        while (true)
        {
            if (startStorm)
            {
                Light lightning = lightningLight.GetComponent<Light>();
                while (lightningCount <= maxLightnings)
                {
                    if (enable)
                    {
                        // Random lightning intensity
                        lightning.intensity = Random.Range(1f, 10f);
                        waitRnd = Random.Range(0.05f, 0.1f);
                    }
                    else
                    {
                        waitRnd = Random.Range(0.05f, 0.8f);
                    }
                    lightning.enabled = enable;
                    yield return new WaitForSeconds(waitRnd);

                    enable = !enable;
                    lightningCount++;
                }
            }
            yield return null;
        }
    }
        

    private void PlaceTrees() {
        Quaternion rotation = Quaternion.Euler(-90.0f, 0f, 0f);
        float delta = 3.0f;
        for (int i = 0; i < 6; i++)
        {
            // Left green
            Instantiate(treePrefab, new Vector3(32f - (i * delta), 0f, 120f), rotation);
            Instantiate(treePrefab, new Vector3(32f, 0f, 123f + (i * delta)), rotation);
            Instantiate(treePrefab, new Vector3(29f - (i * delta), 0f, 138f), rotation);

            // Right green
            Instantiate(treePrefab, new Vector3(-32f + (i * delta), 0f, 120f), rotation);
            Instantiate(treePrefab, new Vector3(-32f, 0f, 123f + (i * delta)), rotation);
            Instantiate(treePrefab, new Vector3(-29f + (i * delta), 0f, 138f), rotation);
        }

        // The trees circle
        int nbTrees = 32;
        float centerX = -25f;
        float centerZ = 0f;
        float radius = 12.0f;
        for (int i = 0; i < nbTrees; i++)
        {
            // Create the entry and exit
            if ((i >= 11 && i <= 12) || (i >= 26 && i <= 27)) {
                continue;
            }
            float angle = (i * 2f * Mathf.PI) / (float)nbTrees;
            float x = centerX + (radius * Mathf.Cos(angle));
            float z = centerZ + (radius * Mathf.Sin(angle));
            Instantiate(treePrefab, new Vector3(x, 0f, z), rotation);
        }
    }

    private void PlacePillars()
    {
        Quaternion rotation = Quaternion.Euler(-90.0f, 0f, 90f);
        float delta = 7.0f;
        for (int i = 0; i < 6; i++)
        {
            Instantiate(pillarPrefab, new Vector3(-3.6f, 0f, 24f + (i * delta)), rotation);
            Instantiate(pillarPrefab, new Vector3(3.6f, 0f, 24f + (i * delta)), rotation);

            Instantiate(pillarSpotLightPrefab, new Vector3(-3.6f, 0f, 27.5f + (i * delta)), rotation);
            Instantiate(pillarSpotLightPrefab, new Vector3(3.6f, 0f, 27.5f + (i * delta)), rotation);
        }
    }
}
