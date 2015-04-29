using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		if (GameObject.FindGameObjectsWithTag ("Music").Length > 1)
			Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
