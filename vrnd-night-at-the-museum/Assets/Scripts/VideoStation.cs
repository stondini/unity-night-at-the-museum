using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(forward);
		rotation.x = - rotation.x;
        this.transform.rotation = rotation;
	}

	public void LoadAndDisplay(Vector3 position, string contentURL) {
		gameObject.transform.position = position;
		VideoPlayer videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.clip = Resources.Load(contentURL, typeof(VideoClip)) as VideoClip;
        videoPlayer.Play();
		gameObject.SetActive(true);
	}
}
