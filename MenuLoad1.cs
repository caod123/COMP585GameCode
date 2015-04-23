using UnityEngine;
using System.Collections;

public class MenuLoad1 : MonoBehaviour {

	public void LoadLevelSelector (string level) {
		Application.LoadLevel (level);
	}

	void Update() {
		if(Input.GetKey("space"))
		{
			Application.LoadLevel(3);		
		}

		if(Input.GetKey(KeyCode.M))
		{
			Application.LoadLevel(0);		
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			Application.LoadLevel(0);		
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			Application.LoadLevel(3);		
		}
	}
}
