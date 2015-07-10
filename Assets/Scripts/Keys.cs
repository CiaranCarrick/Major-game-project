using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {
	public Material color;

	public enum KeyColours
	{
		none,
		redKey,
		blueKey,
		yellowKey,
		greenkey
	};
	public KeyColours MyColour;

	void Start(){
		GetComponent<Renderer>().material = color;
		if (MyColour == KeyColours.redKey)
		{
		}
		if (MyColour == KeyColours.blueKey)
		{
		}
		if (MyColour == KeyColours.yellowKey)
		{
		}
		if (MyColour == KeyColours.greenkey)
		{
		}
	}
	void Update(){
		transform.Rotate (0, 60 * Time.deltaTime, 0);
	}
}
