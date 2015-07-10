using UnityEngine;
using System.Collections;

public class LoadonClick : MonoBehaviour {

	public void LoadScene(int Level_){
		wintrigger.Level = Level_;
		Application.LoadLevel(Level_);

	}
}
