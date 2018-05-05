using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {

    public GameObject mountainPrefab;

    public MountainData mountainData;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click() {
        WebView.Show(mountainData.docURL);
    }
}
