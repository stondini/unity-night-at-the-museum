using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(forward);
        this.transform.rotation = rotation;
	}
}
