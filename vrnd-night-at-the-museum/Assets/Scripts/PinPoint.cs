using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPoint : MonoBehaviour {

    public GameObject icon;

    public Data data;

	// Use this for initialization
	void Start () {
		Renderer iconRenderer = icon.GetComponent<Renderer>();      
		Debug.Log(data.name);
		if (data.type == Data.MOUNTAIN)
        {
			Debug.Log(Resources.Load("Materials/MountainIcon", typeof(Material)).name);
			iconRenderer.material = Resources.Load("Materials/MountainIcon", typeof(Material)) as Material;
        }
        else if (data.type == Data.CITY)
        {
			Debug.Log(Resources.Load("Materials/CityIcon", typeof(Material)).name);
			iconRenderer.material = Resources.Load("Materials/CityIcon", typeof(Material)) as Material;
        }
        else if (data.type == Data.ATTRACTION)
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click() {
		if (data.type == Data.MOUNTAIN)
		{
			WebView.Show(data.docURL);
		} else if (data.type == Data.CITY) {
			
		} else if (data.type == Data.ATTRACTION) {
			
		}
    }
}
