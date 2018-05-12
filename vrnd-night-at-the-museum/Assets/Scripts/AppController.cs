using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppController : MonoBehaviour {

    public GameObject pinPointPrefab;

    public List<GameObject> wayPoints; 

	public GameObject videoStationPrefab;

	public GameObject pictureStationPrefab;

    private List<GameObject> pinPoints;

	private GameObject videoStation;
    
	private MediaManager mediaManager;

	private bool isMediaManagerRunning = false;
    
	// Use this for initialization
	void Start () {
        //Camera.main.transform.parent.transform.position = new Vector3(4.75f, 0.4f, -4);
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

		mediaManager = this.GetComponent<MediaManager>();
		isMediaManagerRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject pinPoint in this.pinPoints) {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0f;
            Quaternion rotation = Quaternion.LookRotation(forward);
			pinPoint.transform.rotation = rotation;
            // Disable pinPoint if the web view is displayed
			pinPoint.SetActive(!mediaManager.IsDisplayed());
        }
        // Disable waypoint if the web view is displayed
		foreach (GameObject wayPoint in wayPoints)
        {
			wayPoint.SetActive(!mediaManager.IsDisplayed());
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
		Debug.Log(this+":"+pinPoint.name+":"+isMediaManagerRunning+":"+videoStation);
		videoStation.SetActive(false);
		if (!isMediaManagerRunning)
		{
			PinPoint script = pinPoint.GetComponent<PinPoint>();
			Data data = script.GetData();
			Debug.Log(data.ToString());
			if (data.mediaType == Data.MEDIA_TYPE_WEBPAGE)
			{
				//webViewObject.LoadURL(data.docURL.Replace(" ", "%20"));
				//webViewObject.SetVisibility(true);
			}
			else if (data.mediaType == Data.MEDIA_TYPE_VIDEO)
			{
				VideoStation vsScript = videoStation.GetComponent<VideoStation>();
				vsScript.LoadAndDisplay(
					new Vector3(pinPoint.transform.position.x, pinPoint.transform.position.y + (1.28f / 2f), pinPoint.transform.position.z),
					data.contentURL
				);
				isMediaManagerRunning = true;            
			}
			else if (data.mediaType == Data.MEDIA_TYPE_PICTURE)
			{

			}
		} else {
			isMediaManagerRunning = false;
		}
    }
}
