using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactableactivate : MonoBehaviour {
	public GameObject[] buttons;
	private void Start()
	{
		buttons = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			buttons[i] = transform.GetChild (i).gameObject;
		}
	}
	void Update () {
		for (int i = 0; i < wintrigger.Level; i++) {
			buttons [i].GetComponent<Button> ().interactable = true; 
		}
		
	}
	
}

