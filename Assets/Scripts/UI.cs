using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	protected GUIStyle guiStyle = new GUIStyle(); //create a new variable
	public static bool ShowUI, debugmode;
	public Transform Spawn;
	private GameObject canvas;
	public static Canvas CanvasReferance;//Store referance to Canvas before deactivating it so Reactication is possible
	private AudioSource Music;
	public bool RedKey, BlueKey, GreenKey, YellowKey;
	public float time;

	
	void Start(){
		
		debugmode = false; //Change to true for access to all levels from the menu scene
		if(Application.loadedLevelName == "Menu") {
			ShowUI = false;
		}
		if (FindObjectsOfType(GetType()).Length > 2)//Prevent copies being made, no time to look into Singletons 
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject); //Dont destroy GameManager
		canvas = GameObject.Find ("Canvas");
		DontDestroyOnLoad (canvas);
		Music = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded() {
		ShowUI = true;
		if(Application.loadedLevelName != "Menu"){
			Spawn = GameObject.Find ("Spawn point").transform; // Find Gameobjects transform
		}
	}
	//
	//Keeps track of time and updates finished time to array to be viewed on the main menu

	void Update(){
	}

	void OnGUI(){
		guiStyle.fontSize = 10;guiStyle.normal.textColor = Color.white;//change the font size + colour
		GUI.Label (new Rect (Screen.width - 45, Screen.height- 15, Screen.width, Screen.height), "ver.1.18", guiStyle);

		if(debugmode==true){

			GUI.Label (new Rect (Screen.width / 2 - 45, Screen.height / 2 - 20, Screen.width, Screen.height), "DEBUG MODE");
			wintrigger.Level=10;
		}
		if (ShowUI == true && gameObject.GetComponent<AudioSource> () != null) {
			Music.enabled = true;
			GUI.Label (new Rect (5, 15, Screen.width, Screen.height), "Level: " + Application.loadedLevel + "/" + 10);
			GUI.Label (new Rect (Screen.width - 70, 15, Screen.width, Screen.height), "Deaths:" + Enemydetection.PlayerDeaths);
			return;
		}
		if (ShowUI == false) {
			CanvasReferance = canvas.GetComponent<Canvas> ();
			Music.enabled = false;
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 20), "Start")) {
				ShowUI = true;
				Application.LoadLevel (1);
				CanvasReferance.enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 20), "Level")) {
				CanvasReferance.enabled = !CanvasReferance.enabled;
			}
		}
	}
}
