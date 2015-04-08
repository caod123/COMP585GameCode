using UnityEngine;
using System.Collections;

public class MenuLoad : MonoBehaviour {

	public void LoadLevelSelector (string level) {
		Application.LoadLevel (level);
	}
}
