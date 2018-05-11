using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPoint : MonoBehaviour {

    public GameObject icon;

    private Data data;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Data GetData() {
		return data;
	}

	public void SetData(Data data) {
		this.data = data;
		Renderer iconRenderer = icon.GetComponent<Renderer>();
        if (data.type == Data.MOUNTAIN)
        {
            iconRenderer.material = Resources.Load("Materials/MountainIcon", typeof(Material)) as Material;
        }
        else if (data.type == Data.CITY)
        {
            iconRenderer.material = Resources.Load("Materials/CityIcon", typeof(Material)) as Material;
        }
        else if (data.type == Data.ATTRACTION)
        {
            iconRenderer.material = Resources.Load("Materials/AttractionIcon", typeof(Material)) as Material;
        }
        else if (data.type == Data.PICTURE)
        {
            iconRenderer.material = Resources.Load("Materials/PictureIcon", typeof(Material)) as Material;
        }
	}

    public void Click() {
		if (data.type == Data.MOUNTAIN)
		{
			MediaManager.Show(data.docURL);
		} else if (data.type == Data.CITY) {
			
		} else if (data.type == Data.ATTRACTION) {
			
		} else if (data.type == Data.PICTURE)
        {

        }
    }
}
