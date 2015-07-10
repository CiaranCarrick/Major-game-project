using UnityEngine;
using System.Collections;

public class wintrigger : MonoBehaviour {
	GameObject Player;
	public static int Level=0;
	public Color myColour;
	public Interaction interaction;
	GameObject GM;
	private GameObject canvas, Background;
	private Colour colour;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("GM");
		Player = GameObject.Find ("Player");
		GetComponent<Renderer>().material.color = myColour;
		interaction = Player.GetComponent<Interaction> ();
		Background = GameObject.Find ("Quad");
		colour = Background.GetComponent<Colour> ();
		colour.Changecolour (wintrigger.Level-1);
	}


	void OnTriggerEnter2D(Collider2D other){
		if(Level==10)
		{   
			Level=0;
			Application.LoadLevel (Level);  
			Destroy(GM);
			Destroy(Background);
		}

		else{
		Level++;
		interaction.resetkeys();
		Application.LoadLevel(Level);
		}


}
}
