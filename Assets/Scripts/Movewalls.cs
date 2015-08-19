using UnityEngine;
using System.Collections;

public class Movewalls : MonoBehaviour {

	Vector3 direction; //vector to store our direction
	public Vector3 dest1;
	public Vector3 dest2;
	public float speed = 4f; //float to store the speed at which our gameobject moves
	void Start()
	{
		direction = new Vector3 (speed, speed, 0); //assign the starting speed of x axis in direction
	}
	void Update ()
	{
		transform.position += direction * Time.deltaTime; //add the direction vector onto the gameobject position vector multiplied by Time (1 second) and speed (4 times per second)
		if (dest1.x > 0) {
			if (transform.position.x >= dest1.x) { //check if the x position of our gameobject is greater than or equal to dest1 x position
				direction = new Vector3 (-speed, 0, 0); //update direction to move negatively on x axis
			}
			else if (transform.position.x <= dest2.x) { //check if the x position of our gameobject is greater than or equal to dest1 x position
				direction = new Vector3 (speed, 0, 0); //update direction to move negatively on x axis
			}
		}
		if (dest1.y > 0) {
			if (transform.position.y >= dest1.y) { //check if the y position of our gameobject is greater than or equal to dest1 x position
				direction = new Vector3 (0, -speed, 0); //update direction to move negatively on x axis
			}
			else if (transform.position.y <= dest2.y) { //check if the position of our gameobject is greater than or equal to dest1 x position
				direction = new Vector3 (0, speed, 0); //update direction to move negatively on x axis
			}
		}
	}
}
