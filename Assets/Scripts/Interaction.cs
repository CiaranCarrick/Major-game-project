using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	public AudioSource hitsound; 
	AudioClip hitclip;
	public GameObject[] Activekeys;
	public GameObject keys;
	UI ui;//referance
	void Start(){
		Activekeys = GameObject.FindGameObjectsWithTag("Key");
		keys = GameObject.Find ("GM");
		ui = keys.GetComponent<UI> ();
		resetkeys ();
		hitsound = gameObject.AddComponent<AudioSource> ();//
		hitclip = (AudioClip)Resources.Load ("Sounds/Pickup_Coin148");// Loading the tracks from Resources
		hitsound.clip = hitclip; //Assigning the hit clip to the AudioSource Component
		hitsound.volume = 0.2f;

	}

	public void resetkeys(){
			ui.RedKey = false;
			ui.YellowKey = false;
			ui.GreenKey = false;
			ui.BlueKey = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		hitsound.Play();
		if (other.gameObject.GetComponent<Keys>() != null)
		 {
			if(other.gameObject.GetComponent<Keys>().MyColour == Keys.KeyColours.redKey)
			{
				ui.RedKey = true;
				other.gameObject.SetActive(false);
			}
			if(other.gameObject.GetComponent<Keys>().MyColour == Keys.KeyColours.blueKey)
			{
				ui.BlueKey = true;
				other.gameObject.SetActive(false);
			}
			if(other.gameObject.GetComponent<Keys>().MyColour == Keys.KeyColours.greenkey)
			{
				ui.GreenKey = true;
				other.gameObject.SetActive(false);
			}
			if(other.gameObject.GetComponent<Keys>().MyColour == Keys.KeyColours.yellowKey)
			{
				ui.YellowKey = true;
				other.gameObject.SetActive(false);
			}
		}
	}
	public void Reset(){
			for (int i = 0; i < Activekeys.Length; i++) {
					Activekeys [i].SetActive (true);
			}
			ui.RedKey = false;
			ui.YellowKey = false;
			ui.GreenKey = false;
			ui.BlueKey = false;
			transform.position = ui.Spawn.position;
			transform.rotation = ui.Spawn.rotation;
		}


	void Update(){
	}
}
