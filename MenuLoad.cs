using UnityEngine;
using System.Collections;

public class MenuLoad : MonoBehaviour {

	public void LoadLevelSelector (string level) {
		Application.LoadLevel (level);
	}

	void Update() {
		if(Input.GetKey("space"))
		{
			Application.LoadLevel(1);		//Load Level 0 (same Level) to make a restart
		}
	}
}
