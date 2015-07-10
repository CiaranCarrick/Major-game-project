using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float Speed;
	Vector3 rotatedirection;
	public bool counterclockwise;
	public float turntime, turntimer=2f;


	// Use this for initialization
	void Start () {
		if (counterclockwise) {
			rotatedirection = new Vector3 (0, 0, Speed);
		} else
			rotatedirection = new Vector3 (0, 0, -Speed);
	}
	
	// Update is called once per frame
	void Update () {
		turntime +=Time.deltaTime;
		transform.Rotate(rotatedirection * Time.deltaTime); //NOTE:Translate is less intense on CPU, also prevents object from colliding via translate movement
		if (turntime >= turntimer) {
			rotatedirection = -rotatedirection;//Everytime an if is called the directions is reversed
			turntime = 0;
		}
	}
}
