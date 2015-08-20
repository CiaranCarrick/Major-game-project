using UnityEngine;
using System.Collections;

public class wintrigger : MonoBehaviour {
	GameObject Player;
	public static int Level=1;
	public Color myColour;
	public Interaction interaction;
	private GameObject canvas, Background, GM, TimeUI;
	private Colour colour;
	UITime ui; //instance of UI script
	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM");
		TimeUI = GameObject.Find ("TimeUI");
		if (TimeUI != null) {//If is exists
			ui = TimeUI.GetComponent<UITime> ();
		}
		Player = GameObject.Find ("Player");
		GetComponent<Renderer>().material.color = myColour;
		interaction = Player.GetComponent<Interaction> ();
		Background = GameObject.Find ("Quad");
		colour = Background.GetComponent<Colour> ();
		colour.Changecolour (Level-1);
		Level = Application.loadedLevel;
	}
	
	
	void OnTriggerEnter2D(Collider2D other){
		if(Level==10)
		{   
			Application.LoadLevel ("Menu");  
			Destroy(GM);
			Destroy(Background);
		}
		
		else if(Level<=10){
			ui.LevelTime();
			Level++;
			interaction.resetkeys();
			Application.LoadLevel(Level);
			return;
		}
	}
	
	void Update(){
		if(Input.GetKeyDown("p"))
		{
			Destroy(Background);
			Application.LoadLevel("Menu");
		}
	}
}
