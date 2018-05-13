using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikipediaStation : MonoBehaviour {

	public RawImage image;

	public Text text;

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
		image.texture = Resources.Load<Texture2D>(contentURL);
		TextAsset textAsset = Resources.Load<TextAsset>(contentURL);
		Debug.Log(textAsset);
		Debug.Log(contentURL + ":" + textAsset);
		text.text = textAsset.text;
		gameObject.transform.position = position;      
		gameObject.SetActive(true);
	}
}
