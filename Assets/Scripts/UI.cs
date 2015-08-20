using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	float deltaTime = 0.0f;
	protected GUIStyle guiStyle = new GUIStyle(); //create a new variable
	public static GUIStyle style = new GUIStyle();

	public static bool ShowUI, debugmode;
	public Transform Spawn;
	private GameObject canvas, LevelS;
	public static Canvas CanvasReferance;//Store referance to Canvas before deactivating it so Reactication is possible
	private AudioSource Music;
	public bool RedKey, BlueKey, GreenKey, YellowKey;
	public float time;
	
	void Start(){
		//
		debugmode = false; //Change to true for access to all levels from the menu scene
		//
		Music = GetComponent<AudioSource>();
		if(Application.loadedLevelName == "Menu") {
			ShowUI = false;
		}
		if (FindObjectsOfType(GetType()).Length > 2)//Prevent copies being made, no time to look into Singletons 
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject); //Dont destroy GameManager
		canvas = GameObject.Find ("Canvas");
		LevelS= GameObject.Find ("Canvas/CanvasButtons");
		DontDestroyOnLoad (canvas);
		CanvasReferance = canvas.GetComponent<Canvas> ();
		CanvasReferance.enabled = true;
		LevelS.active = false;
	}
	
	void OnLevelWasLoaded() {
		ShowUI = true;
		if(Application.loadedLevelName != "Menu"){
			Spawn = GameObject.Find ("Spawn point").transform; // Find Gameobjects transform
		}
	}

	public void BeginGame(){
		Application.LoadLevel (1);
		CanvasReferance.enabled = false;
	}

	public void LevelButton(){
		if (LevelS.active == false) {
			LevelS.active = true;
		} 
		else if (LevelS.active == true) {
			LevelS.active = false;
		} 

	}
	

	void Update(){
	}

	void OnGUI(){
		guiStyle.fontSize = 10;guiStyle.normal.textColor = Color.white;guiStyle.alignment = TextAnchor.UpperLeft;
		//change the font size + colour
		GUI.Label (new Rect (Screen.width - 45, Screen.height- 15, Screen.width, Screen.height), "ver.1.18", guiStyle);
		if(debugmode==true){//DEBUG ONLY
			deltaTime += (Time.deltaTime -deltaTime) * 0.1f;

			Rect rect = new Rect(0, 0, Screen.width, Screen.height* 2 / 80);
			style.alignment = TextAnchor.UpperLeft;//Place text top left of screen
			style.fontSize = Screen.height * 2 / 80;//Screen.height*2/80
			style.normal.textColor = new Color (0.0f, 0.0f, 0.5f, 1.0f);//Blue
			float fps = 1.0f / deltaTime;//Calculates fps
			if(fps < 10)
				style.normal.textColor = new Color (0.5f, 0.0f, 0.0f, 1.0f);//Red
			else
				style.normal.textColor = new Color (0.0f, 0.5f, 0.0f, 1.0f);//Green
			string text = string.Format("{0:0.} fps", fps);// Store FPS in text string f
			GUI.Label(rect, text, style);
			style.normal.textColor = new Color (0.8f, 0.8f, 0.8f, 1.0f);//Green

			GUI.Label (new Rect (Screen.width / 2 - 45, Screen.height / 2-30, Screen.width, Screen.height), "DEBUG MODE");
			wintrigger.Level=10;
		}//
		if (ShowUI == true && gameObject.GetComponent<AudioSource> () != null) {
			Music.enabled = true;
			GUI.Label (new Rect (5, 20, Screen.width, Screen.height), "Level: " + Application.loadedLevel + "/" + 10, guiStyle);
			GUI.Label (new Rect (Screen.width - 70, 15, Screen.width, Screen.height), "Deaths:" + Enemydetection.PlayerDeaths);
			return;
		}
		else
			Music.enabled = false;

		//		if (ShowUI == false) {
//			CanvasReferance = canvas.GetComponent<Canvas> ();
//			Music.enabled = false;
//			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 20), "Start")) {
//				ShowUI = true;
//				Application.LoadLevel (1);
//				CanvasReferance.enabled = false;
//			}
//			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 20), "Level")) {
//				CanvasReferance.enabled = !CanvasReferance.enabled;
//			}
//		}
	}
}
