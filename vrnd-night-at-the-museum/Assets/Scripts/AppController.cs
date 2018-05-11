using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour {

    public GameObject pinPointPrefab;

    public GameObject wayPointsContainer; 

    private List<GameObject> pinPoints;

    private int clicks = 0;

	// Use this for initialization
	void Start () {
        //Camera.main.transform.parent.transform.position = new Vector3(4.75f, 0.4f, -4);
        Camera.main.transform.parent.transform.position = new Vector3(0f, 0.4f, -4);

        this.pinPoints = new List<GameObject>();
        foreach (Data data in Data.MOUNTAINS) {
            GameObject pinPoint = Instantiate(pinPointPrefab, new Vector3(data.x, data.y, data.z), Quaternion.identity);
			PinPoint script = pinPoint.GetComponent<PinPoint>();
			script.SetData(data);
			TextMesh text = pinPoint.GetComponentInChildren<TextMesh>();
			text.text = data.name + "\n" + data.shortInfo;
			this.pinPoints.Add(pinPoint);
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject pinPoint in this.pinPoints) {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0f;
            Quaternion rotation = Quaternion.LookRotation(forward);
			pinPoint.transform.rotation = rotation;
            // Disable pinPoint if the web view is displayed
			pinPoint.SetActive(!MediaManager.IsDisplayed());
        }
        // Disable waypoint if the web view is displayed
        for (int index = 0; index < wayPointsContainer.transform.childCount; index++)
        {
            GameObject wayPoint = wayPointsContainer.transform.GetChild(index).gameObject;
			wayPoint.SetActive(!MediaManager.IsDisplayed());
        }
	}

	private void setAltitudeTo(float altitudeY)
    {
        for (int index = 0; index < wayPointsContainer.transform.childCount; index++)
        {
			GameObject wayPoint = wayPointsContainer.transform.GetChild(index).gameObject;
			Vector3 currentPos = wayPoint.transform.position;
			wayPoint.transform.position = new Vector3(currentPos.x, altitudeY, currentPos.z);
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
