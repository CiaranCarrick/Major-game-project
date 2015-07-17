using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public static bool ShowUI, debugmode;
	public Transform Spawn;
	private GameObject canvas;
	public static Canvas CanvasReferance;//Store referance to Canvas before deactivating it so Reactication is possible
	AudioSource Music;
	public bool RedKey, BlueKey, GreenKey, YellowKey;
	
	void Start(){
		debugmode = false;
		if(Application.loadedLevelName == "Menu") {
			ShowUI = false;
		}
		DontDestroyOnLoad (gameObject);
		canvas = GameObject.Find ("Canvas");
		DontDestroyOnLoad (canvas);
		Music = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded() {
		ShowUI = true;
		if(Application.loadedLevelName != "Menu"){
			Spawn = GameObject.Find ("Spawn point").transform;
		}
	}
	
	
	void OnGUI(){
		if (debugmode == true) {
			GUI.Label (new Rect (Screen.width / 2 - 45, Screen.height / 2 - 20, Screen.width, Screen.height), "DEBUG MODE");
		}
		if (ShowUI == true && gameObject.GetComponent<AudioSource> () != null) {
			Music.enabled = true;
			GUI.Label (new Rect (5, 15, Screen.width, Screen.height), "Level: " + wintrigger.Level + "/" + 10);
			GUI.Label (new Rect (Screen.width - 60, 15, Screen.width, Screen.height), "Deaths:" + Enemydetection.PlayerDeaths);
			return;
		}
		if (ShowUI == false) {
			CanvasReferance = canvas.GetComponent<Canvas> ();

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 20), "Start")) {
				ShowUI = true;
				Application.LoadLevel (wintrigger.Level);
				CanvasReferance.enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 20), "Level")) {
				CanvasReferance.enabled = !CanvasReferance.enabled;
			}
		}
	}
	
	
}
