using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour {

    public GameObject pinPointPrefab;

    public GameObject wayPointsContainer; 

    private List<GameObject> mountains;

	// Use this for initialization
	void Start () {
        this.mountains = new List<GameObject>();
        foreach (MountainData data in MountainData.MOUNTAINS) {
            Debug.Log("Mountain: " + data);
            GameObject mountain = Instantiate(pinPointPrefab, new Vector3(data.x, data.y, data.z), Quaternion.identity);
            TextMesh text = mountain.GetComponentInChildren<TextMesh>();
            text.text = data.name + "\n" + data.altitude + "m";
            this.mountains.Add(mountain);
        }

        Application.OpenURL("www.google.com");
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

    public void setAltitudeTo1000m() {
        for (int index = 0; index < wayPointsContainer.transform.childCount; index++) {
            GameObject waypoint = wayPointsContainer.transform.GetChild(index).gameObject;
            Vector3 currentPos = waypoint.transform.position;
            waypoint.transform.position = new Vector3(currentPos.x, 0.2f, currentPos.z);
        }
    }

    public void setAltitudeTo2000m() {
        for (int index=0; index < wayPointsContainer.transform.childCount; index++) {
            GameObject waypoint = wayPointsContainer.transform.GetChild(index).gameObject;
            Vector3 currentPos = waypoint.transform.position;
            waypoint.transform.position = new Vector3(currentPos.x, 0.4f, currentPos.z);
        }
    }

    public void setAltitudeTo3000m() {
        for (int index = 0; index < wayPointsContainer.transform.childCount; index++) {
            GameObject waypoint = wayPointsContainer.transform.GetChild(index).gameObject;
            Vector3 currentPos = waypoint.transform.position;
            waypoint.transform.position = new Vector3(currentPos.x, 0.6f, currentPos.z);
        }
    }
}
