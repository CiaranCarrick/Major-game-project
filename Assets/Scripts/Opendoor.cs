using UnityEngine;
using System.Collections;

public class Opendoor : MonoBehaviour {
	public GameObject key;

	float width;
	//public float timer;
	public float mysize;
	public bool CloseHorizontal, Closefromleft;
	// Use this for initialization
	void Start () {
		mysize = 100;
		//timer = 0.1f;
		width = transform.localScale.x;
		GetComponent<Renderer>().material = key.GetComponent<Keys> ().color;

	}
	
	// Update is called once per frame
	void Update () {
		if (key.activeInHierarchy == false) {
			ActivateDoor ();
		} 

		else
			ActivateDoor ();

	}
	void ActivateDoor() {
		if (mysize >= 1&&key.activeInHierarchy == false) {
			mysize -= 2;
			DoorTransition();
			if(mysize<=1)
				transform.GetComponent<Collider2D>().enabled=false;
		}
		if (mysize <= 99 && key.activeInHierarchy == true) {
			mysize++;
			DoorTransition ();
			transform.GetComponent<Collider2D>().enabled=true;

		} else
			return;
	}
	void DoorTransition(){
		Vector3 pos = transform.position;
		Vector3 scale = transform.localScale;
		scale.x = (width / 100) * mysize;
		if (CloseHorizontal) {
			pos.x = transform.position.x - ((transform.localScale.x - scale.x) / 2);
			if (Closefromleft) {
				pos.x = transform.position.x + ((transform.localScale.x - scale.x) / 2);
			}
		} 
		else {
			if (Closefromleft) {
				pos.y = transform.position.y + ((transform.localScale.x - scale.x) / 2);
			} 
			else
				pos.y = transform.position.y - ((transform.localScale.x - scale.x) / 2);
		}
		//timer=0.1f;
		transform.position = pos;
		transform.localScale = scale;
	}
}
