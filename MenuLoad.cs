using UnityEngine;
using System.Collections;

public class MenuLoad : MonoBehaviour {

	public GUIText HiScoreText; 			//GUI HiScore

	void Start() {
		if (!PlayerPrefs.HasKey ("hiscore"))
			PlayerPrefs.SetInt ("hiscore", 0);
		HiScoreText.text = "HISCORE: " + PlayerPrefs.GetInt ("hiscore"); 			//Update the GUI Score
	}

	public void LoadLevelSelector (string level) {
		Application.LoadLevel (level);
	}

	void Update() {
		if(Input.GetKey("space"))
		{
			Application.LoadLevel(2);		//Load Level 0 (same Level) to make a restart
		}
	}
}
