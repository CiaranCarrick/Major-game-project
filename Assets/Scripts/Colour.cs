using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour {
	public Color[] BackColors = new Color[10];

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		BackColors[0]=new Color(201f/255f, 196f/255f, 212f/255f,1);
		BackColors [1] = BackColors [0];
		BackColors[2]=new Color(186f/255f, 136f/255f, 123f/255f,1);
		BackColors[3]=new Color(186f/255f, 136f/255f, 123f/255f,1);
		BackColors[4]=new Color(163f/255f, 147f/255f, 165f/255f,1);
		BackColors[5]=new Color(163f/255f, 147f/255f, 165f/255f,1);
		BackColors[6]=new Color(195f/255f, 104f/255f, 81f/255f,1);
		BackColors[7]=new Color(163f/255f, 147f/255f, 165f/255f,1);
		BackColors[8]=new Color(186f/255f, 136f/255f, 123f/255f,1);
		BackColors[9]=new Color(154f/255f, 53f/255f, 27f/255f,1);
	}

	public void Changecolour(int level_){
		GetComponent<Renderer> ().material.color = BackColors [level_];
	}

	// Update is called once per frame
	void Update () {
	}
}
