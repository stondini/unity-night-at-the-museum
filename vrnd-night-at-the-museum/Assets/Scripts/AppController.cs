using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour {

    public GameObject alpsTerrain;

    public GameObject mountainPrefab;

    private List<GameObject> mountains;

	// Use this for initialization
	void Start () {
        this.mountains = new List<GameObject>();
        foreach (MountainData data in MountainData.MOUNTAINS) {
            Debug.Log("Mountain: " + data);
            GameObject mountain = Instantiate(mountainPrefab, new Vector3(data.x, data.y, data.z), Quaternion.identity);
            TextMesh text = mountain.GetComponentInChildren<TextMesh>();
            text.text = data.name + "\n" + data.altitude + "m";
            this.mountains.Add(mountain);
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject mountain in this.mountains) {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0f;
            //Vector3 relativePos = Camera.current.transform.position - mountain.transform.position;
            Quaternion rotation = Quaternion.LookRotation(forward);
            mountain.transform.rotation = rotation;
        }
	}
}
