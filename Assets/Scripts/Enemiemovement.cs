using UnityEngine;
using System.Collections;

public class Enemiemovement : MonoBehaviour {
	public Transform[] Patrolpoints;
	public int currentpoint;
	float waitTime;
	public float speed, rotationspeed=0.4f, waitTimer=1f, RotationTime; //float to store the speed at which our gameobject moves
	void Start()
	{
		transform.position = Patrolpoints [0].position;
		currentpoint = 0;
	}
	void Update ()
	{
		waitTime += Time.deltaTime;
		if (transform.position == Patrolpoints [currentpoint].position) {
			currentpoint++;
			waitTime=0;
			if (currentpoint >= Patrolpoints.Length) {
				currentpoint = 0;
			}
		}
		if (waitTime >= RotationTime) {
			TurnMe();
		}
		if (waitTime >= waitTimer) {
			transform.position = Vector2.MoveTowards (transform.position, Patrolpoints [currentpoint].position, speed * Time.deltaTime);// REMOVE FOR IDLE ROTATION
		}
	}	
	

	void TurnMe(){ 
		Vector3 Dir = Patrolpoints [currentpoint].position - transform.position;
		// Normalize it so that it's a unit direction Vector
		Dir.Normalize ();
		//ROTATE Enemy ship towards player
		float Zangle = Mathf.Atan2 (Dir.y, Dir.x) *Mathf.Rad2Deg - 90f; // Draws an angle facing the players position
		Quaternion AngleRotation = Quaternion.Euler (0, 0, Zangle);// Which axis the rotation will take place, in this case the X-Axis
		transform.rotation = Quaternion.RotateTowards (transform.rotation, AngleRotation, rotationspeed); //How fast enemy rotates towards player

	}
}
