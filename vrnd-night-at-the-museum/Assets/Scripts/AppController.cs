using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppController : MonoBehaviour {

    public GameObject pinPointPrefab;

    public List<GameObject> wayPoints; 

	public GameObject videoStationPrefab;

	public GameObject wikipediaStationPrefab;

	public GameObject pictureStationPrefab;

    private List<GameObject> pinPoints;

	private GameObject videoStation;

	private GameObject wikipediaStation;
    
	private bool isStationRunning = false;
    
	// Use this for initialization
	void Start () {
        Camera.main.transform.parent.transform.position = new Vector3(0f, 0.4f, -4);

        this.pinPoints = new List<GameObject>();
        foreach (Data data in Data.MOUNTAINS) {
            GameObject pinPoint = Instantiate(pinPointPrefab, new Vector3(data.x, data.y, data.z), Quaternion.identity);
			PinPoint ppScript = pinPoint.GetComponent<PinPoint>();
			ppScript.SetData(data);
			TextMesh text = pinPoint.GetComponentInChildren<TextMesh>();
			text.text = data.name + "\n" + data.shortInfo;

            // Setup event trigger
			EventTrigger evtTrigger = pinPoint.GetComponent<EventTrigger>();
			evtTrigger.triggers.Clear();
			EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
			entry.callback.AddListener((eventData) => this.PinPointClick(pinPoint));
			evtTrigger.triggers.Add(entry);

			this.pinPoints.Add(pinPoint);
        }

		videoStation = Instantiate(videoStationPrefab, Vector3.zero, Quaternion.identity);      
		videoStation.SetActive(false);

		wikipediaStation = Instantiate(wikipediaStationPrefab, Vector3.zero, Quaternion.identity);
		wikipediaStation.SetActive(false);

		isStationRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject pinPoint in this.pinPoints) {
            // Disable pinPoint if the web view is displayed
			pinPoint.SetActive(!isStationRunning);
        }
        // Disable waypoint if the web view is displayed
		foreach (GameObject wayPoint in wayPoints)
        {
			wayPoint.SetActive(!isStationRunning);
        }
	}

	void OnGUI()
    {
        if (Event.current.isMouse && Event.current.button == 0 && Event.current.clickCount > 0)
        {
			isStationRunning = false;
			videoStation.SetActive(false);
            wikipediaStation.SetActive(false);
        }
    }

	private void setAltitudeTo(float altitudeY)
    {
		foreach (GameObject wayPoint in wayPoints)
        {
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

	public void PinPointClick(GameObject pinPoint)
    {
		videoStation.SetActive(false);
		wikipediaStation.SetActive(false);
		if (!isStationRunning)
		{
			PinPoint script = pinPoint.GetComponent<PinPoint>();
			Data data = script.GetData();
			if (data.mediaType == Data.MEDIA_TYPE_WEBPAGE)
			{
				WikipediaStation wsScript = wikipediaStation.GetComponent<WikipediaStation>();

				Vector3 newPosition = pinPoint.transform.position + (Camera.main.transform.forward * 3.0f);

				wsScript.LoadAndDisplay(
					new Vector3(newPosition.x, 
					            3.0f, 
					            newPosition.z),
                    data.contentURL
                );
                isStationRunning = true; 
			}
			else if (data.mediaType == Data.MEDIA_TYPE_VIDEO)
			{
				VideoStation vsScript = videoStation.GetComponent<VideoStation>();
				vsScript.LoadAndDisplay(
					new Vector3(pinPoint.transform.position.x, 0.7f, pinPoint.transform.position.z),
					data.contentURL
				);
				isStationRunning = true;            
			}
		} else {
			isStationRunning = false;
		}
    }
}
