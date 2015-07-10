using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	float horiz, vert; //floats to store axis value, which is 0-1
	void StoreAxis()
	{
		horiz = Input.GetAxis ("Horizontal") * 180f * Time.deltaTime; //store a stored axis in a float
		vert = Input.GetAxis ("Vertical") * 10f * Time.deltaTime;
	}
	void Update ()
	{	
		StoreAxis(); //axis values need to be updated every frame
		transform.Rotate (0, 0, -horiz);
		transform.Translate(0, vert, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20f, 20), Mathf.Clamp(transform.position.y, -20f, 21f));//Update last so movement doesn't override and cause character to push out of bounds
	}

}
