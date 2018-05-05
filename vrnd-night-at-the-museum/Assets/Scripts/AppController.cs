using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour {

    public GameObject pinPointPrefab;

    public GameObject wayPointsContainer; 

    private List<GameObject> mountains;

	// Use this for initialization
	void Start () {
        //Camera.main.transform.parent.transform.position = new Vector3(4.75f, 0.4f, -4);
        Camera.main.transform.parent.transform.position = new Vector3(0f, 0.4f, -4);

        this.mountains = new List<GameObject>();
        foreach (MountainData data in MountainData.MOUNTAINS) {
            Debug.Log("Mountain: " + data);
            GameObject mountain = Instantiate(pinPointPrefab, new Vector3(data.x, data.y, data.z), Quaternion.identity);
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

    private void setAltitudeTo(float altitudeY)
    {
        for (int index = 0; index < wayPointsContainer.transform.childCount; index++)
        {
            GameObject waypoint = wayPointsContainer.transform.GetChild(index).gameObject;
            Vector3 currentPos = waypoint.transform.position;
            waypoint.transform.position = new Vector3(currentPos.x, altitudeY, currentPos.z);
        }
    }

    public void setAltitudeTo1000m() {
        setAltitudeTo(0.3f);
    }

    public void setAltitudeTo2000m() {
        setAltitudeTo(0.4f);
    }

    public void setAltitudeTo3000m() {
        setAltitudeTo(0.6f);
    }
}
