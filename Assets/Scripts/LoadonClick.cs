using UnityEngine;
using System.Collections;

public class LoadonClick : MonoBehaviour {

	void Awake(){
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
	public void LoadScene(int Level_){
		UI.CanvasReferance.enabled = !UI.CanvasReferance.enabled;
		wintrigger.Level = Level_;
		Application.LoadLevel(Level_);

	}
}
