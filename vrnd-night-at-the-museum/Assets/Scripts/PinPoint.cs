﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPoint : MonoBehaviour {

    public GameObject icon;

	private Data data;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update() {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(forward);
        rotation.x = -rotation.x;
        this.transform.rotation = rotation;
    }

	public Data GetData() {
		return data;
	}

	public void SetData(Data data) {
		this.data = data;
		Renderer iconRenderer = icon.GetComponent<Renderer>();
        if (data.type == Data.TYPE_MOUNTAIN)
        {
            iconRenderer.material = Resources.Load("Materials/MountainIcon", typeof(Material)) as Material;
        }
		else if (data.type == Data.TYPE_CITY)
        {
            iconRenderer.material = Resources.Load("Materials/CityIcon", typeof(Material)) as Material;
        }
		else if (data.type == Data.TYPE_ATTRACTION)
        {
            iconRenderer.material = Resources.Load("Materials/AttractionIcon", typeof(Material)) as Material;
        }
		else if (data.type == Data.TYPE_PICTURE)
        {
            iconRenderer.material = Resources.Load("Materials/PictureIcon", typeof(Material)) as Material;
        }
	}
}
