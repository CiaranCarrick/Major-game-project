using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public static bool ShowUI;
	public Transform Spawn;
	private GameObject canvas;
	private Canvas CanvasReferance;//Store referance to Canvas before deactivating it so Reactication is possible
	AudioSource Music;
	public bool RedKey, BlueKey, GreenKey, YellowKey;

	void Start(){
		if (wintrigger.Level== 0) {
			ShowUI = false;
		}
		DontDestroyOnLoad (gameObject);
		canvas = GameObject.Find ("Canvas");
		Music = GetComponent<AudioSource>();
	}


	void OnLevelWasLoaded() {
		ShowUI = true;
		Spawn = GameObject.Find ("Spawn point").transform;
		}
	

	void OnGUI(){
			if (ShowUI == true && gameObject.GetComponent<AudioSource> () != null) {
					Music.enabled = true;
					GUI.Label (new Rect (5, 15, Screen.width, Screen.height), "Level: " + wintrigger.Level + "/" + 10);
					GUI.Label (new Rect (Screen.width - 60, 15, Screen.width, Screen.height), "Deaths:" + Enemydetection.PlayerDeaths);
					return;
			}
			if (ShowUI == false) {
					if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 20), "Start")) {
							ShowUI = true;
							wintrigger.Level = 1;
							Application.LoadLevel (wintrigger.Level);
					}
						if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 20), "Level")) {
							CanvasReferance = canvas.GetComponent<Canvas> ();
							CanvasReferance.enabled = !CanvasReferance.enabled;
						}
			}
	}
	
	
}
